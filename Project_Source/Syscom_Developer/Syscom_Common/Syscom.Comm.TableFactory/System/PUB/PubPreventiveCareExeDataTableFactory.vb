Imports System.Data.SqlClient
Public Class PubPreventiveCareExeDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:53
    Public Shared ReadOnly tableName as String="PUB_Preventive_Care_Exe"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Care_Order_Code", "Pre_Care_Order_Code", "Age_Control_Id", "Age_Start", "Age_End"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.Int32", "System.Int32"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             2, 2, 5, -1, -1  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubPreventiveCareExeDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Care_Order_Code") = New Object
        dataRow("Pre_Care_Order_Code") = New Object
        dataRow("Age_Control_Id") = New Object
        dataRow("Age_Start") = New Object
        dataRow("Age_End") = New Object
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
            dt.Columns.Add("Care_Order_Code")
            dt.Columns.Add("Pre_Care_Order_Code")
            dt.Columns.Add("Age_Control_Id")
            dt.Columns.Add("Age_Start")
            dt.Columns.Add("Age_End")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Care_Order_Code")
            pkColArray(1) = dt.Columns("Pre_Care_Order_Code")
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
            dt.Columns.Add("Care_Order_Code")
            dt.Columns("Care_Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Pre_Care_Order_Code")
            dt.Columns("Pre_Care_Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Age_Control_Id")
            dt.Columns("Age_Control_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Age_Start")
            dt.Columns("Age_Start").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Age_End")
            dt.Columns("Age_End").DataType = System.Type.GetType("System.Int32")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Care_Order_Code")
            pkColArray(1) = dt.Columns("Pre_Care_Order_Code")
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
            dt.Columns.Add("Care_Order_Code")
            dt.Columns.Add("Pre_Care_Order_Code")
            dt.Columns.Add("Age_Control_Id")
            dt.Columns.Add("Age_Start")
            dt.Columns.Add("Age_End")
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

  Class PUBPreventiveCareExePt
    Private m_Care_Order_Code As String = "Care_Order_Code"
    Public ReadOnly Property Care_Order_Code() As System.String 
    Get
        Return m_Care_Order_Code
    End Get
    End Property

    Private m_Pre_Care_Order_Code As String = "Pre_Care_Order_Code"
    Public ReadOnly Property Pre_Care_Order_Code() As System.String 
    Get
        Return m_Pre_Care_Order_Code
    End Get
    End Property

    Private m_Age_Control_Id As String = "Age_Control_Id"
    Public ReadOnly Property Age_Control_Id() As System.String 
    Get
        Return m_Age_Control_Id
    End Get
    End Property

    Private m_Age_Start As String = "Age_Start"
    Public ReadOnly Property Age_Start() As System.String 
    Get
        Return m_Age_Start
    End Get
    End Property

    Private m_Age_End As String = "Age_End"
    Public ReadOnly Property Age_End() As System.String 
    Get
        Return m_Age_End
    End Get
    End Property

  End Class

End Class
