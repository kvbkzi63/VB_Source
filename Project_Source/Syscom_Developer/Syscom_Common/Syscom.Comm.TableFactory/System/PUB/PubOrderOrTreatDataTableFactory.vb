Imports System.Data.SqlClient
Public Class PubOrderOrTreatDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:51
    Public Shared ReadOnly tableName as String="PUB_Order_Or_Treat"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Order_Code", "Is_Single_Or", "Is_Body_Site", "Default_Body_Site_Code", "Default_Side_Id"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             20, 1, 1, 5, 5  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubOrderOrTreatDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Order_Code") = New Object
        dataRow("Is_Single_Or") = New Object
        dataRow("Is_Body_Site") = New Object
        dataRow("Default_Body_Site_Code") = New Object
        dataRow("Default_Side_Id") = New Object
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
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Is_Single_Or")
            dt.Columns.Add("Is_Body_Site")
            dt.Columns.Add("Default_Body_Site_Code")
            dt.Columns.Add("Default_Side_Id")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Order_Code")
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
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Single_Or")
            dt.Columns("Is_Single_Or").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Body_Site")
            dt.Columns("Is_Body_Site").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Default_Body_Site_Code")
            dt.Columns("Default_Body_Site_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Default_Side_Id")
            dt.Columns("Default_Side_Id").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Order_Code")
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
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Is_Single_Or")
            dt.Columns.Add("Is_Body_Site")
            dt.Columns.Add("Default_Body_Site_Code")
            dt.Columns.Add("Default_Side_Id")
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

  Class PUBOrderOrTreatPt
    Private m_Order_Code As String = "Order_Code"
    Public ReadOnly Property Order_Code() As System.String 
    Get
        Return m_Order_Code
    End Get
    End Property

    Private m_Is_Single_Or As String = "Is_Single_Or"
    Public ReadOnly Property Is_Single_Or() As System.String 
    Get
        Return m_Is_Single_Or
    End Get
    End Property

    Private m_Is_Body_Site As String = "Is_Body_Site"
    Public ReadOnly Property Is_Body_Site() As System.String 
    Get
        Return m_Is_Body_Site
    End Get
    End Property

    Private m_Default_Body_Site_Code As String = "Default_Body_Site_Code"
    Public ReadOnly Property Default_Body_Site_Code() As System.String 
    Get
        Return m_Default_Body_Site_Code
    End Get
    End Property

    Private m_Default_Side_Id As String = "Default_Side_Id"
    Public ReadOnly Property Default_Side_Id() As System.String 
    Get
        Return m_Default_Side_Id
    End Get
    End Property

  End Class

End Class
