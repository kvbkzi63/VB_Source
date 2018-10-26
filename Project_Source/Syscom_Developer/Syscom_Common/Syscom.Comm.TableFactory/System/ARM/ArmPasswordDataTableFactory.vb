Imports System.Data.SqlClient
Public Class ArmPasswordDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/7/5 上午 10:36:13
    Public Shared ReadOnly tableName as String="ARM_Password"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Employee_Code", "Password", "Password_org", "Modified_Date"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 50, 50, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = ArmPasswordDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Employee_Code") = New Object
        dataRow("Password") = New Object
        dataRow("Password_org") = New Object
        dataRow("Modified_Date") = New Object
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
            dt.Columns.Add("Password")
            dt.Columns.Add("Password_org")
            dt.Columns.Add("Modified_Date")
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
            dt.Columns.Add("Password")
            dt.Columns("Password").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Password_org")
            dt.Columns("Password_org").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Date")
            dt.Columns("Modified_Date").DataType = System.Type.GetType("System.DateTime")
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
            dt.Columns.Add("Password")
            dt.Columns.Add("Password_org")
            dt.Columns.Add("Modified_Date")
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

  Class ARMPasswordPt
    Private m_Employee_Code As String = "Employee_Code"
    Public ReadOnly Property Employee_Code() As System.String 
    Get
        Return m_Employee_Code
    End Get
    End Property

    Private m_Password As String = "Password"
    Public ReadOnly Property Password() As System.String 
    Get
        Return m_Password
    End Get
    End Property

    Private m_Password_org As String = "Password_org"
    Public ReadOnly Property Password_org() As System.String 
    Get
        Return m_Password_org
    End Get
    End Property

    Private m_Modified_Date As String = "Modified_Date"
    Public ReadOnly Property Modified_Date() As System.String 
    Get
        Return m_Modified_Date
    End Get
    End Property

  End Class

End Class
