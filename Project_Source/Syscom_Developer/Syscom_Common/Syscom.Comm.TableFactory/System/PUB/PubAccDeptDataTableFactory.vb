Imports System.Data.SqlClient
Public Class PubAccDeptDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/8/25 上午 10:07:48
    Public Shared ReadOnly tableName as String="PUB_Acc_Dept"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Acc_Dept", "Acc_Dept_Name", "Acc_Dept_Upper", "Acc_Dept_Type_Id", "Acc_Level",   _
             "Acc_Level_Same", "Acc_Class_Id", "Is_Primary", "Is_Collect", "Create_User",   _
             "Create_Time", "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.DateTime", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             6, 100, 6, 5, 5,   _
             5, 5, 1, 1, 10,   _
             -1, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubAccDeptDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Acc_Dept") = New Object
        dataRow("Acc_Dept_Name") = New Object
        dataRow("Acc_Dept_Upper") = New Object
        dataRow("Acc_Dept_Type_Id") = New Object
        dataRow("Acc_Level") = New Object
        dataRow("Acc_Level_Same") = New Object
        dataRow("Acc_Class_Id") = New Object
        dataRow("Is_Primary") = New Object
        dataRow("Is_Collect") = New Object
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
            dt.Columns.Add("Acc_Dept")
            dt.Columns.Add("Acc_Dept_Name")
            dt.Columns.Add("Acc_Dept_Upper")
            dt.Columns.Add("Acc_Dept_Type_Id")
            dt.Columns.Add("Acc_Level")
            dt.Columns.Add("Acc_Level_Same")
            dt.Columns.Add("Acc_Class_Id")
            dt.Columns.Add("Is_Primary")
            dt.Columns.Add("Is_Collect")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Acc_Dept")
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
            dt.Columns.Add("Acc_Dept")
            dt.Columns("Acc_Dept").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Acc_Dept_Name")
            dt.Columns("Acc_Dept_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Acc_Dept_Upper")
            dt.Columns("Acc_Dept_Upper").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Acc_Dept_Type_Id")
            dt.Columns("Acc_Dept_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Acc_Level")
            dt.Columns("Acc_Level").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Acc_Level_Same")
            dt.Columns("Acc_Level_Same").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Acc_Class_Id")
            dt.Columns("Acc_Class_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Primary")
            dt.Columns("Is_Primary").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Collect")
            dt.Columns("Is_Collect").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Acc_Dept")
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
            dt.Columns.Add("Acc_Dept")
            dt.Columns.Add("Acc_Dept_Name")
            dt.Columns.Add("Acc_Dept_Upper")
            dt.Columns.Add("Acc_Dept_Type_Id")
            dt.Columns.Add("Acc_Level")
            dt.Columns.Add("Acc_Level_Same")
            dt.Columns.Add("Acc_Class_Id")
            dt.Columns.Add("Is_Primary")
            dt.Columns.Add("Is_Collect")
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

  Class PUBAccDeptPt
    Private m_Acc_Dept As String = "Acc_Dept"
    Public ReadOnly Property Acc_Dept() As System.String 
    Get
        Return m_Acc_Dept
    End Get
    End Property

    Private m_Acc_Dept_Name As String = "Acc_Dept_Name"
    Public ReadOnly Property Acc_Dept_Name() As System.String 
    Get
        Return m_Acc_Dept_Name
    End Get
    End Property

    Private m_Acc_Dept_Upper As String = "Acc_Dept_Upper"
    Public ReadOnly Property Acc_Dept_Upper() As System.String 
    Get
        Return m_Acc_Dept_Upper
    End Get
    End Property

    Private m_Acc_Dept_Type_Id As String = "Acc_Dept_Type_Id"
    Public ReadOnly Property Acc_Dept_Type_Id() As System.String 
    Get
        Return m_Acc_Dept_Type_Id
    End Get
    End Property

    Private m_Acc_Level As String = "Acc_Level"
    Public ReadOnly Property Acc_Level() As System.String 
    Get
        Return m_Acc_Level
    End Get
    End Property

    Private m_Acc_Level_Same As String = "Acc_Level_Same"
    Public ReadOnly Property Acc_Level_Same() As System.String 
    Get
        Return m_Acc_Level_Same
    End Get
    End Property

    Private m_Acc_Class_Id As String = "Acc_Class_Id"
    Public ReadOnly Property Acc_Class_Id() As System.String 
    Get
        Return m_Acc_Class_Id
    End Get
    End Property

    Private m_Is_Primary As String = "Is_Primary"
    Public ReadOnly Property Is_Primary() As System.String 
    Get
        Return m_Is_Primary
    End Get
    End Property

    Private m_Is_Collect As String = "Is_Collect"
    Public ReadOnly Property Is_Collect() As System.String 
    Get
        Return m_Is_Collect
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
