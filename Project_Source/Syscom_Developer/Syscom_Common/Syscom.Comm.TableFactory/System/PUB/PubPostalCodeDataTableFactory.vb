Imports System.Data.SqlClient
Public Class PubPostalCodeDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:53
    Public Shared ReadOnly tableName as String="PUB_Postal_Code"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Postal_Code", "Postal_Name", "County_Name", "Town_Name"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             5, 10, 5, 5}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubPostalCodeDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Postal_Code") = New Object
        dataRow("Postal_Name") = New Object
        dataRow("County_Name") = New Object
        dataRow("Town_Name") = New Object
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
            dt.Columns.Add("Postal_Code")
            dt.Columns.Add("Postal_Name")
            dt.Columns.Add("County_Name")
            dt.Columns.Add("Town_Name")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Postal_Code")
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
            dt.Columns.Add("Postal_Code")
            dt.Columns("Postal_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Postal_Name")
            dt.Columns("Postal_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("County_Name")
            dt.Columns("County_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Town_Name")
            dt.Columns("Town_Name").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Postal_Code")
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
            dt.Columns.Add("Postal_Code")
            dt.Columns.Add("Postal_Name")
            dt.Columns.Add("County_Name")
            dt.Columns.Add("Town_Name")
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

  Class PUBPostalCodePt
    Private m_Postal_Code As String = "Postal_Code"
    Public ReadOnly Property Postal_Code() As System.String 
    Get
        Return m_Postal_Code
    End Get
    End Property

    Private m_Postal_Name As String = "Postal_Name"
    Public ReadOnly Property Postal_Name() As System.String 
    Get
        Return m_Postal_Name
    End Get
    End Property

    Private m_County_Name As String = "County_Name"
    Public ReadOnly Property County_Name() As System.String 
    Get
        Return m_County_Name
    End Get
    End Property

    Private m_Town_Name As String = "Town_Name"
    Public ReadOnly Property Town_Name() As System.String 
    Get
        Return m_Town_Name
    End Get
    End Property

  End Class

End Class
