Imports System.Data.SqlClient
Public Class PubSheetLocationDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:54
    Public Shared ReadOnly tableName as String="PUB_Sheet_Location"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Sheet_Code", "Zone_Id", "Sheet_Location_Desc", "Sheet_Contect_Tel"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 5, 100, 10}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubSheetLocationDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Sheet_Code") = New Object
        dataRow("Zone_Id") = New Object
        dataRow("Sheet_Location_Desc") = New Object
        dataRow("Sheet_Contect_Tel") = New Object
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
            dt.Columns.Add("Sheet_Code")
            dt.Columns.Add("Zone_Id")
            dt.Columns.Add("Sheet_Location_Desc")
            dt.Columns.Add("Sheet_Contect_Tel")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Sheet_Code")
            pkColArray(1) = dt.Columns("Zone_Id")
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
            dt.Columns.Add("Sheet_Code")
            dt.Columns("Sheet_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Zone_Id")
            dt.Columns("Zone_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sheet_Location_Desc")
            dt.Columns("Sheet_Location_Desc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sheet_Contect_Tel")
            dt.Columns("Sheet_Contect_Tel").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Sheet_Code")
            pkColArray(1) = dt.Columns("Zone_Id")
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
            dt.Columns.Add("Sheet_Code")
            dt.Columns.Add("Zone_Id")
            dt.Columns.Add("Sheet_Location_Desc")
            dt.Columns.Add("Sheet_Contect_Tel")
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

  Class PUBSheetLocationPt
    Private m_Sheet_Code As String = "Sheet_Code"
    Public ReadOnly Property Sheet_Code() As System.String 
    Get
        Return m_Sheet_Code
    End Get
    End Property

    Private m_Zone_Id As String = "Zone_Id"
    Public ReadOnly Property Zone_Id() As System.String 
    Get
        Return m_Zone_Id
    End Get
    End Property

    Private m_Sheet_Location_Desc As String = "Sheet_Location_Desc"
    Public ReadOnly Property Sheet_Location_Desc() As System.String 
    Get
        Return m_Sheet_Location_Desc
    End Get
    End Property

    Private m_Sheet_Contect_Tel As String = "Sheet_Contect_Tel"
    Public ReadOnly Property Sheet_Contect_Tel() As System.String 
    Get
        Return m_Sheet_Contect_Tel
    End Get
    End Property

  End Class

End Class
