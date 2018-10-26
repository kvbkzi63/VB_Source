Imports System.Data.SqlClient
Public Class PubSyscodeDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:54
    Public Shared ReadOnly tableName as String="PUB_Syscode"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Type_Id", "Code_Id", "Code_En_Name", "Code_Name", "Is_Default",   _
             "Sort_Value", "Dc", "Create_User", "Create_Time", "Modified_User",   _
             "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.Int32", "System.String", "System.String", "System.String", "System.String",   _
             "System.Int32", "System.String", "System.String", "System.DateTime", "System.String",   _
             "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             -1, 5, 100, 100, 1,   _
             -1, 1, 10, -1, 10,   _
             -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubSyscodeDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Type_Id") = New Object
        dataRow("Code_Id") = New Object
        dataRow("Code_En_Name") = New Object
        dataRow("Code_Name") = New Object
        dataRow("Is_Default") = New Object
        dataRow("Sort_Value") = New Object
        dataRow("Dc") = New Object
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
            dt.Columns.Add("Type_Id")
            dt.Columns.Add("Code_Id")
            dt.Columns.Add("Code_En_Name")
            dt.Columns.Add("Code_Name")
            dt.Columns.Add("Is_Default")
            dt.Columns.Add("Sort_Value")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Type_Id")
            pkColArray(1) = dt.Columns("Code_Id")
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
            dt.Columns.Add("Type_Id")
            dt.Columns("Type_Id").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Code_Id")
            dt.Columns("Code_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Code_En_Name")
            dt.Columns("Code_En_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Code_Name")
            dt.Columns("Code_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Default")
            dt.Columns("Is_Default").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sort_Value")
            dt.Columns("Sort_Value").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Dc")
            dt.Columns("Dc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Type_Id")
            pkColArray(1) = dt.Columns("Code_Id")
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
            dt.Columns.Add("Type_Id")
            dt.Columns.Add("Code_Id")
            dt.Columns.Add("Code_En_Name")
            dt.Columns.Add("Code_Name")
            dt.Columns.Add("Is_Default")
            dt.Columns.Add("Sort_Value")
            dt.Columns.Add("Dc")
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

  Class PUBSyscodePt
    Private m_Type_Id As String = "Type_Id"
    Public ReadOnly Property Type_Id() As System.String 
    Get
        Return m_Type_Id
    End Get
    End Property

    Private m_Code_Id As String = "Code_Id"
    Public ReadOnly Property Code_Id() As System.String 
    Get
        Return m_Code_Id
    End Get
    End Property

    Private m_Code_En_Name As String = "Code_En_Name"
    Public ReadOnly Property Code_En_Name() As System.String 
    Get
        Return m_Code_En_Name
    End Get
    End Property

    Private m_Code_Name As String = "Code_Name"
    Public ReadOnly Property Code_Name() As System.String 
    Get
        Return m_Code_Name
    End Get
    End Property

    Private m_Is_Default As String = "Is_Default"
    Public ReadOnly Property Is_Default() As System.String 
    Get
        Return m_Is_Default
    End Get
    End Property

    Private m_Sort_Value As String = "Sort_Value"
    Public ReadOnly Property Sort_Value() As System.String 
    Get
        Return m_Sort_Value
    End Get
    End Property

    Private m_Dc As String = "Dc"
    Public ReadOnly Property Dc() As System.String 
    Get
        Return m_Dc
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
