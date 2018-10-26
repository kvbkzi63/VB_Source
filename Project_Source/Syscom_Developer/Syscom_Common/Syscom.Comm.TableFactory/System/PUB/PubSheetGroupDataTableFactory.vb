Imports System.Data.SqlClient
Public Class PubSheetGroupDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:54
    Public Shared ReadOnly tableName as String="PUB_Sheet_Group"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Sheet_Group", "Sheet_Code", "Order_Code", "Sheet_Group_Name", "Is_Custom_Group"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             5, 10, 20, 50, 1  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubSheetGroupDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Sheet_Group") = New Object
        dataRow("Sheet_Code") = New Object
        dataRow("Order_Code") = New Object
        dataRow("Sheet_Group_Name") = New Object
        dataRow("Is_Custom_Group") = New Object
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
            dt.Columns.Add("Sheet_Group")
            dt.Columns.Add("Sheet_Code")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Sheet_Group_Name")
            dt.Columns.Add("Is_Custom_Group")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Sheet_Group")
            pkColArray(1) = dt.Columns("Sheet_Code")
            pkColArray(2) = dt.Columns("Order_Code")
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
            dt.Columns.Add("Sheet_Group")
            dt.Columns("Sheet_Group").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sheet_Code")
            dt.Columns("Sheet_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sheet_Group_Name")
            dt.Columns("Sheet_Group_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Custom_Group")
            dt.Columns("Is_Custom_Group").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Sheet_Group")
            pkColArray(1) = dt.Columns("Sheet_Code")
            pkColArray(2) = dt.Columns("Order_Code")
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
            dt.Columns.Add("Sheet_Group")
            dt.Columns.Add("Sheet_Code")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Sheet_Group_Name")
            dt.Columns.Add("Is_Custom_Group")
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

  Class PUBSheetGroupPt
    Private m_Sheet_Group As String = "Sheet_Group"
    Public ReadOnly Property Sheet_Group() As System.String 
    Get
        Return m_Sheet_Group
    End Get
    End Property

    Private m_Sheet_Code As String = "Sheet_Code"
    Public ReadOnly Property Sheet_Code() As System.String 
    Get
        Return m_Sheet_Code
    End Get
    End Property

    Private m_Order_Code As String = "Order_Code"
    Public ReadOnly Property Order_Code() As System.String 
    Get
        Return m_Order_Code
    End Get
    End Property

    Private m_Sheet_Group_Name As String = "Sheet_Group_Name"
    Public ReadOnly Property Sheet_Group_Name() As System.String 
    Get
        Return m_Sheet_Group_Name
    End Get
    End Property

    Private m_Is_Custom_Group As String = "Is_Custom_Group"
    Public ReadOnly Property Is_Custom_Group() As System.String 
    Get
        Return m_Is_Custom_Group
    End Get
    End Property

  End Class

End Class
