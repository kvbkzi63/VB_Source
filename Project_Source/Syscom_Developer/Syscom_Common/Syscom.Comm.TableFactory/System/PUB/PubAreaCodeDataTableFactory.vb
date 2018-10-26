Imports System.Data.SqlClient
Public Class PubAreaCodeDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:47
    Public Shared ReadOnly tableName as String="PUB_Area_Code"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Area_Code", "Area_Name", "County_Code"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             4, 10, 4}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubAreaCodeDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Area_Code") = New Object
        dataRow("Area_Name") = New Object
        dataRow("County_Code") = New Object
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
            dt.Columns.Add("Area_Code")
            dt.Columns.Add("Area_Name")
            dt.Columns.Add("County_Code")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Area_Code")
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
            dt.Columns.Add("Area_Code")
            dt.Columns("Area_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Area_Name")
            dt.Columns("Area_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("County_Code")
            dt.Columns("County_Code").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Area_Code")
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
            dt.Columns.Add("Area_Code")
            dt.Columns.Add("Area_Name")
            dt.Columns.Add("County_Code")
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

  Class PUBAreaCodePt
    Private m_Area_Code As String = "Area_Code"
    Public ReadOnly Property Area_Code() As System.String 
    Get
        Return m_Area_Code
    End Get
    End Property

    Private m_Area_Name As String = "Area_Name"
    Public ReadOnly Property Area_Name() As System.String 
    Get
        Return m_Area_Name
    End Get
    End Property

    Private m_County_Code As String = "County_Code"
    Public ReadOnly Property County_Code() As System.String 
    Get
        Return m_County_Code
    End Get
    End Property

  End Class

End Class
