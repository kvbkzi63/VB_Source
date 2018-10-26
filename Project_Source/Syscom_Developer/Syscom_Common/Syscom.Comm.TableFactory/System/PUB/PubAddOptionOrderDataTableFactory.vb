Imports System.Data.SqlClient
Public Class PubAddOptionOrderDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/5/10 上午 11:08:57
    Public Shared ReadOnly tableName as String="PUB_Add_Option_Order"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Add_Order_Code", "Add_Order_Detail_No", "Option_Order_Code", "Tqty", "Dc"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Int32", "System.String", "System.Decimal", "System.String"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             20, -1, 20, -1, 1  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubAddOptionOrderDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Add_Order_Code") = New Object
        dataRow("Add_Order_Detail_No") = New Object
        dataRow("Option_Order_Code") = New Object
        dataRow("Tqty") = New Object
        dataRow("Dc") = New Object
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
            dt.Columns.Add("Add_Order_Code")
            dt.Columns.Add("Add_Order_Detail_No")
            dt.Columns.Add("Option_Order_Code")
            dt.Columns.Add("Tqty")
            dt.Columns.Add("Dc")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Add_Order_Code")
            pkColArray(1) = dt.Columns("Add_Order_Detail_No")
            pkColArray(2) = dt.Columns("Option_Order_Code")
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
            dt.Columns.Add("Add_Order_Code")
            dt.Columns("Add_Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Add_Order_Detail_No")
            dt.Columns("Add_Order_Detail_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Option_Order_Code")
            dt.Columns("Option_Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Tqty")
            dt.Columns("Tqty").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Dc")
            dt.Columns("Dc").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Add_Order_Code")
            pkColArray(1) = dt.Columns("Add_Order_Detail_No")
            pkColArray(2) = dt.Columns("Option_Order_Code")
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
            dt.Columns.Add("Add_Order_Code")
            dt.Columns.Add("Add_Order_Detail_No")
            dt.Columns.Add("Option_Order_Code")
            dt.Columns.Add("Tqty")
            dt.Columns.Add("Dc")
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

  Class PUBAddOptionOrderPt
    Private m_Add_Order_Code As String = "Add_Order_Code"
    Public ReadOnly Property Add_Order_Code() As System.String 
    Get
        Return m_Add_Order_Code
    End Get
    End Property

    Private m_Add_Order_Detail_No As String = "Add_Order_Detail_No"
    Public ReadOnly Property Add_Order_Detail_No() As System.String 
    Get
        Return m_Add_Order_Detail_No
    End Get
    End Property

    Private m_Option_Order_Code As String = "Option_Order_Code"
    Public ReadOnly Property Option_Order_Code() As System.String 
    Get
        Return m_Option_Order_Code
    End Get
    End Property

    Private m_Tqty As String = "Tqty"
    Public ReadOnly Property Tqty() As System.String 
    Get
        Return m_Tqty
    End Get
    End Property

    Private m_Dc As String = "Dc"
    Public ReadOnly Property Dc() As System.String 
    Get
        Return m_Dc
    End Get
    End Property

  End Class

End Class
