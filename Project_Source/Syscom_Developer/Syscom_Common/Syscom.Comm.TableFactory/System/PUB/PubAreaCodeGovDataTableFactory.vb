Imports System.Data.SqlClient
Public Class PubAreaCodeGovDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:47
    Public Shared ReadOnly tableName as String="PUB_Area_Code_Gov"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Gov_County_Code", "Gov_County_Name", "Dist_Code", "Dist_Name", "Vil_Code",   _
             "Vil_Name"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             5, 10, 7, 10, 11,   _
             10}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubAreaCodeGovDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Gov_County_Code") = New Object
        dataRow("Gov_County_Name") = New Object
        dataRow("Dist_Code") = New Object
        dataRow("Dist_Name") = New Object
        dataRow("Vil_Code") = New Object
        dataRow("Vil_Name") = New Object
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
            dt.Columns.Add("Gov_County_Code")
            dt.Columns.Add("Gov_County_Name")
            dt.Columns.Add("Dist_Code")
            dt.Columns.Add("Dist_Name")
            dt.Columns.Add("Vil_Code")
            dt.Columns.Add("Vil_Name")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Gov_County_Code")
            pkColArray(1) = dt.Columns("Dist_Code")
            pkColArray(2) = dt.Columns("Vil_Code")
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
            dt.Columns.Add("Gov_County_Code")
            dt.Columns("Gov_County_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Gov_County_Name")
            dt.Columns("Gov_County_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dist_Code")
            dt.Columns("Dist_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dist_Name")
            dt.Columns("Dist_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Vil_Code")
            dt.Columns("Vil_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Vil_Name")
            dt.Columns("Vil_Name").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Gov_County_Code")
            pkColArray(1) = dt.Columns("Dist_Code")
            pkColArray(2) = dt.Columns("Vil_Code")
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
            dt.Columns.Add("Gov_County_Code")
            dt.Columns.Add("Gov_County_Name")
            dt.Columns.Add("Dist_Code")
            dt.Columns.Add("Dist_Name")
            dt.Columns.Add("Vil_Code")
            dt.Columns.Add("Vil_Name")
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

  Class PUBAreaCodeGovPt
    Private m_Gov_County_Code As String = "Gov_County_Code"
    Public ReadOnly Property Gov_County_Code() As System.String 
    Get
        Return m_Gov_County_Code
    End Get
    End Property

    Private m_Gov_County_Name As String = "Gov_County_Name"
    Public ReadOnly Property Gov_County_Name() As System.String 
    Get
        Return m_Gov_County_Name
    End Get
    End Property

    Private m_Dist_Code As String = "Dist_Code"
    Public ReadOnly Property Dist_Code() As System.String 
    Get
        Return m_Dist_Code
    End Get
    End Property

    Private m_Dist_Name As String = "Dist_Name"
    Public ReadOnly Property Dist_Name() As System.String 
    Get
        Return m_Dist_Name
    End Get
    End Property

    Private m_Vil_Code As String = "Vil_Code"
    Public ReadOnly Property Vil_Code() As System.String 
    Get
        Return m_Vil_Code
    End Get
    End Property

    Private m_Vil_Name As String = "Vil_Name"
    Public ReadOnly Property Vil_Name() As System.String 
    Get
        Return m_Vil_Name
    End Get
    End Property

  End Class

End Class
