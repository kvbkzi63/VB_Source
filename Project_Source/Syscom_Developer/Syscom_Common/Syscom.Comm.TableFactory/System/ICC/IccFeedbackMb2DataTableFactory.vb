Imports System.Data.SqlClient
Public Class IccFeedbackMb2DataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/11/13 下午 04:15:11
    Public Shared ReadOnly tableName as String="ICC_Feedback_Mb2"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Import_Date", "Count", "Record_No", "Detail_No", "A61",   _
             "A62", "A63", "A64", "A71", "A72",   _
             "A73", "A74", "A75", "A76", "A77",   _
             "A78", "A80", "A81", "Create_User", "Create_Time",   _
             "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.DateTime", "System.Int32", "System.Int32", "System.Int32", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             -1, -1, -1, -1, 20,   _
             7, 10, 20, 13, 1,   _
             12, 6, 18, 2, 9,   _
             2, 1, 200, 10, -1,   _
             10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccFeedbackMb2DataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Import_Date") = New Object
        dataRow("Count") = New Object
        dataRow("Record_No") = New Object
        dataRow("Detail_No") = New Object
        dataRow("A61") = New Object
        dataRow("A62") = New Object
        dataRow("A63") = New Object
        dataRow("A64") = New Object
        dataRow("A71") = New Object
        dataRow("A72") = New Object
        dataRow("A73") = New Object
        dataRow("A74") = New Object
        dataRow("A75") = New Object
        dataRow("A76") = New Object
        dataRow("A77") = New Object
        dataRow("A78") = New Object
        dataRow("A80") = New Object
        dataRow("A81") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
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
            dt.Columns.Add("Import_Date")
            dt.Columns.Add("Count")
            dt.Columns.Add("Record_No")
            dt.Columns.Add("Detail_No")
            dt.Columns.Add("A61")
            dt.Columns.Add("A62")
            dt.Columns.Add("A63")
            dt.Columns.Add("A64")
            dt.Columns.Add("A71")
            dt.Columns.Add("A72")
            dt.Columns.Add("A73")
            dt.Columns.Add("A74")
            dt.Columns.Add("A75")
            dt.Columns.Add("A76")
            dt.Columns.Add("A77")
            dt.Columns.Add("A78")
            dt.Columns.Add("A80")
            dt.Columns.Add("A81")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(3) As DataColumn 
            pkColArray(0) = dt.Columns("Import_Date")
            pkColArray(1) = dt.Columns("Count")
            pkColArray(2) = dt.Columns("Record_No")
            pkColArray(3) = dt.Columns("Detail_No")
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
            dt.Columns.Add("Import_Date")
            dt.Columns("Import_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Count")
            dt.Columns("Count").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Record_No")
            dt.Columns("Record_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Detail_No")
            dt.Columns("Detail_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("A61")
            dt.Columns("A61").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A62")
            dt.Columns("A62").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A63")
            dt.Columns("A63").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A64")
            dt.Columns("A64").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A71")
            dt.Columns("A71").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A72")
            dt.Columns("A72").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A73")
            dt.Columns("A73").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A74")
            dt.Columns("A74").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A75")
            dt.Columns("A75").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A76")
            dt.Columns("A76").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A77")
            dt.Columns("A77").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A78")
            dt.Columns("A78").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A80")
            dt.Columns("A80").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A81")
            dt.Columns("A81").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(3) As DataColumn 
            pkColArray(0) = dt.Columns("Import_Date")
            pkColArray(1) = dt.Columns("Count")
            pkColArray(2) = dt.Columns("Record_No")
            pkColArray(3) = dt.Columns("Detail_No")
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
            dt.Columns.Add("Import_Date")
            dt.Columns.Add("Count")
            dt.Columns.Add("Record_No")
            dt.Columns.Add("Detail_No")
            dt.Columns.Add("A61")
            dt.Columns.Add("A62")
            dt.Columns.Add("A63")
            dt.Columns.Add("A64")
            dt.Columns.Add("A71")
            dt.Columns.Add("A72")
            dt.Columns.Add("A73")
            dt.Columns.Add("A74")
            dt.Columns.Add("A75")
            dt.Columns.Add("A76")
            dt.Columns.Add("A77")
            dt.Columns.Add("A78")
            dt.Columns.Add("A80")
            dt.Columns.Add("A81")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
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

  Class ICCFeedbackMb2Pt
    Private m_Import_Date As String = "Import_Date"
    Public ReadOnly Property Import_Date() As System.String 
    Get
        Return m_Import_Date
    End Get
    End Property

    Private m_Count As String = "Count"
    Public ReadOnly Property Count() As System.String 
    Get
        Return m_Count
    End Get
    End Property

    Private m_Record_No As String = "Record_No"
    Public ReadOnly Property Record_No() As System.String 
    Get
        Return m_Record_No
    End Get
    End Property

    Private m_Detail_No As String = "Detail_No"
    Public ReadOnly Property Detail_No() As System.String 
    Get
        Return m_Detail_No
    End Get
    End Property

    Private m_A61 As String = "A61"
    Public ReadOnly Property A61() As System.String 
    Get
        Return m_A61
    End Get
    End Property

    Private m_A62 As String = "A62"
    Public ReadOnly Property A62() As System.String 
    Get
        Return m_A62
    End Get
    End Property

    Private m_A63 As String = "A63"
    Public ReadOnly Property A63() As System.String 
    Get
        Return m_A63
    End Get
    End Property

    Private m_A64 As String = "A64"
    Public ReadOnly Property A64() As System.String 
    Get
        Return m_A64
    End Get
    End Property

    Private m_A71 As String = "A71"
    Public ReadOnly Property A71() As System.String 
    Get
        Return m_A71
    End Get
    End Property

    Private m_A72 As String = "A72"
    Public ReadOnly Property A72() As System.String 
    Get
        Return m_A72
    End Get
    End Property

    Private m_A73 As String = "A73"
    Public ReadOnly Property A73() As System.String 
    Get
        Return m_A73
    End Get
    End Property

    Private m_A74 As String = "A74"
    Public ReadOnly Property A74() As System.String 
    Get
        Return m_A74
    End Get
    End Property

    Private m_A75 As String = "A75"
    Public ReadOnly Property A75() As System.String 
    Get
        Return m_A75
    End Get
    End Property

    Private m_A76 As String = "A76"
    Public ReadOnly Property A76() As System.String 
    Get
        Return m_A76
    End Get
    End Property

    Private m_A77 As String = "A77"
    Public ReadOnly Property A77() As System.String 
    Get
        Return m_A77
    End Get
    End Property

    Private m_A78 As String = "A78"
    Public ReadOnly Property A78() As System.String 
    Get
        Return m_A78
    End Get
    End Property

    Private m_A80 As String = "A80"
    Public ReadOnly Property A80() As System.String 
    Get
        Return m_A80
    End Get
    End Property

    Private m_A81 As String = "A81"
    Public ReadOnly Property A81() As System.String 
    Get
        Return m_A81
    End Get
    End Property

    Private m_Create_User As String = "Create_User"
    Public ReadOnly Property Create_User() As System.String 
    Get
        Return m_Create_User
    End Get
    End Property

    Private m_Create_Time As String = "Create_Time"
    Public ReadOnly Property Create_Time() As System.String 
    Get
        Return m_Create_Time
    End Get
    End Property

    Private m_Modified_User As String = "Modified_User"
    Public ReadOnly Property Modified_User() As System.String 
    Get
        Return m_Modified_User
    End Get
    End Property

    Private m_Modified_Time As String = "Modified_Time"
    Public ReadOnly Property Modified_Time() As System.String 
    Get
        Return m_Modified_Time
    End Get
    End Property

  End Class

End Class
