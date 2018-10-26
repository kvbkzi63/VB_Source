Imports System.Data.SqlClient
Public Class PubExamineDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:49
    Public Shared ReadOnly tableName as String="PUB_Examine"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Sub_Identity_Code", "First_Reg", "Dept_Code", "Section_Id", "Medical_Type_Id",   _
             "Examine_Type_Id", "Order_Code", "Dc", "Create_User", "Create_Time",   _
             "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             2, 1, 6, 5, 5,   _
             5, 20, 1, 10, -1,   _
             10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubExamineDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Sub_Identity_Code") = New Object
        dataRow("First_Reg") = New Object
        dataRow("Dept_Code") = New Object
        dataRow("Section_Id") = New Object
        dataRow("Medical_Type_Id") = New Object
        dataRow("Examine_Type_Id") = New Object
        dataRow("Order_Code") = New Object
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
            dt.Columns.Add("Sub_Identity_Code")
            dt.Columns.Add("First_Reg")
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Section_Id")
            dt.Columns.Add("Medical_Type_Id")
            dt.Columns.Add("Examine_Type_Id")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(5) As DataColumn 
            pkColArray(0) = dt.Columns("Sub_Identity_Code")
            pkColArray(1) = dt.Columns("First_Reg")
            pkColArray(2) = dt.Columns("Dept_Code")
            pkColArray(3) = dt.Columns("Section_Id")
            pkColArray(4) = dt.Columns("Medical_Type_Id")
            pkColArray(5) = dt.Columns("Examine_Type_Id")
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
            dt.Columns.Add("Sub_Identity_Code")
            dt.Columns("Sub_Identity_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("First_Reg")
            dt.Columns("First_Reg").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dept_Code")
            dt.Columns("Dept_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Section_Id")
            dt.Columns("Section_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Medical_Type_Id")
            dt.Columns("Medical_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Examine_Type_Id")
            dt.Columns("Examine_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
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
            Dim pkColArray(5) As DataColumn 
            pkColArray(0) = dt.Columns("Sub_Identity_Code")
            pkColArray(1) = dt.Columns("First_Reg")
            pkColArray(2) = dt.Columns("Dept_Code")
            pkColArray(3) = dt.Columns("Section_Id")
            pkColArray(4) = dt.Columns("Medical_Type_Id")
            pkColArray(5) = dt.Columns("Examine_Type_Id")
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
            dt.Columns.Add("Sub_Identity_Code")
            dt.Columns.Add("First_Reg")
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Section_Id")
            dt.Columns.Add("Medical_Type_Id")
            dt.Columns.Add("Examine_Type_Id")
            dt.Columns.Add("Order_Code")
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

  Class PUBExaminePt
    Private m_Sub_Identity_Code As String = "Sub_Identity_Code"
    Public ReadOnly Property Sub_Identity_Code() As System.String 
    Get
        Return m_Sub_Identity_Code
    End Get
    End Property

    Private m_First_Reg As String = "First_Reg"
    Public ReadOnly Property First_Reg() As System.String 
    Get
        Return m_First_Reg
    End Get
    End Property

    Private m_Dept_Code As String = "Dept_Code"
    Public ReadOnly Property Dept_Code() As System.String 
    Get
        Return m_Dept_Code
    End Get
    End Property

    Private m_Section_Id As String = "Section_Id"
    Public ReadOnly Property Section_Id() As System.String 
    Get
        Return m_Section_Id
    End Get
    End Property

    Private m_Medical_Type_Id As String = "Medical_Type_Id"
    Public ReadOnly Property Medical_Type_Id() As System.String 
    Get
        Return m_Medical_Type_Id
    End Get
    End Property

    Private m_Examine_Type_Id As String = "Examine_Type_Id"
    Public ReadOnly Property Examine_Type_Id() As System.String 
    Get
        Return m_Examine_Type_Id
    End Get
    End Property

    Private m_Order_Code As String = "Order_Code"
    Public ReadOnly Property Order_Code() As System.String 
    Get
        Return m_Order_Code
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
