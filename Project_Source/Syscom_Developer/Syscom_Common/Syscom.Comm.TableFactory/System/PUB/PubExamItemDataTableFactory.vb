Imports System.Data.SqlClient
Public Class PubExamItemDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:49
    Public Shared ReadOnly tableName as String="PUB_Exam_Item"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Order_Code", "Display_Name", "Item_Option", "Other_Side_Code1", "Other_Side_Code2"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             20, 100, 20, 20, 20  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubExamItemDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Order_Code") = New Object
        dataRow("Display_Name") = New Object
        dataRow("Item_Option") = New Object
        dataRow("Other_Side_Code1") = New Object
        dataRow("Other_Side_Code2") = New Object
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
            dt.Columns.Add("Display_Name")
            dt.Columns.Add("Item_Option")
            dt.Columns.Add("Other_Side_Code1")
            dt.Columns.Add("Other_Side_Code2")
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
            dt.Columns.Add("Display_Name")
            dt.Columns("Display_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Item_Option")
            dt.Columns("Item_Option").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Other_Side_Code1")
            dt.Columns("Other_Side_Code1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Other_Side_Code2")
            dt.Columns("Other_Side_Code2").DataType = System.Type.GetType("System.String")
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
            dt.Columns.Add("Display_Name")
            dt.Columns.Add("Item_Option")
            dt.Columns.Add("Other_Side_Code1")
            dt.Columns.Add("Other_Side_Code2")
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

  Class PUBExamItemPt
    Private m_Order_Code As String = "Order_Code"
    Public ReadOnly Property Order_Code() As System.String 
    Get
        Return m_Order_Code
    End Get
    End Property

    Private m_Display_Name As String = "Display_Name"
    Public ReadOnly Property Display_Name() As System.String 
    Get
        Return m_Display_Name
    End Get
    End Property

    Private m_Item_Option As String = "Item_Option"
    Public ReadOnly Property Item_Option() As System.String 
    Get
        Return m_Item_Option
    End Get
    End Property

    Private m_Other_Side_Code1 As String = "Other_Side_Code1"
    Public ReadOnly Property Other_Side_Code1() As System.String 
    Get
        Return m_Other_Side_Code1
    End Get
    End Property

    Private m_Other_Side_Code2 As String = "Other_Side_Code2"
    Public ReadOnly Property Other_Side_Code2() As System.String 
    Get
        Return m_Other_Side_Code2
    End Get
    End Property

  End Class

End Class
