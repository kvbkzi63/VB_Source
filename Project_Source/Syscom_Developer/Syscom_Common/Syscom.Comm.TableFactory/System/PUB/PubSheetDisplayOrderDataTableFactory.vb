Imports System.Data.SqlClient
Public Class PubSheetDisplayOrderDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/11/8 上午 10:12:45
    Public Shared ReadOnly tableName as String="PUB_Sheet_Display_Order"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Sheet_Sub_Display", "Order_Display_Code", "Order_Display_Name", "Order_Code", "Default_Main_Body_Site_Code",   _
             "Default_Body_Site_Code", "Default_Side_Id", "Display_Sort_Value"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.Int32"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 20, 100, 20, 5,   _
             5, 5, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubSheetDisplayOrderDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Sheet_Sub_Display") = New Object
        dataRow("Order_Display_Code") = New Object
        dataRow("Order_Display_Name") = New Object
        dataRow("Order_Code") = New Object
        dataRow("Default_Main_Body_Site_Code") = New Object
        dataRow("Default_Body_Site_Code") = New Object
        dataRow("Default_Side_Id") = New Object
        dataRow("Display_Sort_Value") = New Object
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
            dt.Columns.Add("Sheet_Sub_Display")
            dt.Columns.Add("Order_Display_Code")
            dt.Columns.Add("Order_Display_Name")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Default_Main_Body_Site_Code")
            dt.Columns.Add("Default_Body_Site_Code")
            dt.Columns.Add("Default_Side_Id")
            dt.Columns.Add("Display_Sort_Value")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Sheet_Sub_Display")
            pkColArray(1) = dt.Columns("Order_Display_Code")
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
            dt.Columns.Add("Sheet_Sub_Display")
            dt.Columns("Sheet_Sub_Display").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Display_Code")
            dt.Columns("Order_Display_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Display_Name")
            dt.Columns("Order_Display_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Default_Main_Body_Site_Code")
            dt.Columns("Default_Main_Body_Site_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Default_Body_Site_Code")
            dt.Columns("Default_Body_Site_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Default_Side_Id")
            dt.Columns("Default_Side_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Display_Sort_Value")
            dt.Columns("Display_Sort_Value").DataType = System.Type.GetType("System.Int32")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Sheet_Sub_Display")
            pkColArray(1) = dt.Columns("Order_Display_Code")
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
            dt.Columns.Add("Sheet_Sub_Display")
            dt.Columns.Add("Order_Display_Code")
            dt.Columns.Add("Order_Display_Name")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Default_Main_Body_Site_Code")
            dt.Columns.Add("Default_Body_Site_Code")
            dt.Columns.Add("Default_Side_Id")
            dt.Columns.Add("Display_Sort_Value")
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

  Class PUBSheetDisplayOrderPt
    Private m_Sheet_Sub_Display As String = "Sheet_Sub_Display"
    Public ReadOnly Property Sheet_Sub_Display() As System.String 
    Get
        Return m_Sheet_Sub_Display
    End Get
    End Property

    Private m_Order_Display_Code As String = "Order_Display_Code"
    Public ReadOnly Property Order_Display_Code() As System.String 
    Get
        Return m_Order_Display_Code
    End Get
    End Property

    Private m_Order_Display_Name As String = "Order_Display_Name"
    Public ReadOnly Property Order_Display_Name() As System.String 
    Get
        Return m_Order_Display_Name
    End Get
    End Property

    Private m_Order_Code As String = "Order_Code"
    Public ReadOnly Property Order_Code() As System.String 
    Get
        Return m_Order_Code
    End Get
    End Property

    Private m_Default_Main_Body_Site_Code As String = "Default_Main_Body_Site_Code"
    Public ReadOnly Property Default_Main_Body_Site_Code() As System.String 
    Get
        Return m_Default_Main_Body_Site_Code
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

    Private m_Display_Sort_Value As String = "Display_Sort_Value"
    Public ReadOnly Property Display_Sort_Value() As System.String 
    Get
        Return m_Display_Sort_Value
    End Get
    End Property

  End Class

End Class
