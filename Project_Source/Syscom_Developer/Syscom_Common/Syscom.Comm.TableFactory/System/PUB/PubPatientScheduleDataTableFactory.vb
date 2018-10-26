Imports System.Data.SqlClient
Public Class PubPatientScheduleDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:53
    Public Shared ReadOnly tableName as String="PUB_Patient_Schedule"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Book_Type_Id", "Chart_No", "Book_Date", "Book_Time", "CheckIn_Dept_Code",   _
             "CheckIn_Section_Id", "CheckIn_Reg_Sn", "Medical_Sn", "Is_PreLend_Chart", "Book_State",   _
             "Source_Table_Name", "Create_User", "Create_Time", "Modified_User", "Modified_Time",   _
             "PreLend_No"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.DateTime", "System.String", "System.String",   _
             "System.String", "System.Int32", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime",   _
             "System.Int32"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             5, 10, -1, 4, 6,   _
             5, -1, 15, 1, 1,   _
             100, 10, -1, 10, -1,   _
             -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubPatientScheduleDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Book_Type_Id") = New Object
        dataRow("Chart_No") = New Object
        dataRow("Book_Date") = New Object
        dataRow("Book_Time") = New Object
        dataRow("CheckIn_Dept_Code") = New Object
        dataRow("CheckIn_Section_Id") = New Object
        dataRow("CheckIn_Reg_Sn") = New Object
        dataRow("Medical_Sn") = New Object
        dataRow("Is_PreLend_Chart") = New Object
        dataRow("Book_State") = New Object
        dataRow("Source_Table_Name") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("PreLend_No") = New Object
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
            dt.Columns.Add("Book_Type_Id")
            dt.Columns.Add("Chart_No")
            dt.Columns.Add("Book_Date")
            dt.Columns.Add("Book_Time")
            dt.Columns.Add("CheckIn_Dept_Code")
            dt.Columns.Add("CheckIn_Section_Id")
            dt.Columns.Add("CheckIn_Reg_Sn")
            dt.Columns.Add("Medical_Sn")
            dt.Columns.Add("Is_PreLend_Chart")
            dt.Columns.Add("Book_State")
            dt.Columns.Add("Source_Table_Name")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("PreLend_No")
            Dim pkColArray(4) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Book_Date")
            pkColArray(2) = dt.Columns("Book_Time")
            pkColArray(3) = dt.Columns("CheckIn_Dept_Code")
            pkColArray(4) = dt.Columns("Create_Time")
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
            dt.Columns.Add("Book_Type_Id")
            dt.Columns("Book_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Chart_No")
            dt.Columns("Chart_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Book_Date")
            dt.Columns("Book_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Book_Time")
            dt.Columns("Book_Time").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("CheckIn_Dept_Code")
            dt.Columns("CheckIn_Dept_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("CheckIn_Section_Id")
            dt.Columns("CheckIn_Section_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("CheckIn_Reg_Sn")
            dt.Columns("CheckIn_Reg_Sn").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Medical_Sn")
            dt.Columns("Medical_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_PreLend_Chart")
            dt.Columns("Is_PreLend_Chart").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Book_State")
            dt.Columns("Book_State").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Source_Table_Name")
            dt.Columns("Source_Table_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("PreLend_No")
            dt.Columns("PreLend_No").DataType = System.Type.GetType("System.Int32")
            Dim pkColArray(4) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Book_Date")
            pkColArray(2) = dt.Columns("Book_Time")
            pkColArray(3) = dt.Columns("CheckIn_Dept_Code")
            pkColArray(4) = dt.Columns("Create_Time")
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
            dt.Columns.Add("Book_Type_Id")
            dt.Columns.Add("Chart_No")
            dt.Columns.Add("Book_Date")
            dt.Columns.Add("Book_Time")
            dt.Columns.Add("CheckIn_Dept_Code")
            dt.Columns.Add("CheckIn_Section_Id")
            dt.Columns.Add("CheckIn_Reg_Sn")
            dt.Columns.Add("Medical_Sn")
            dt.Columns.Add("Is_PreLend_Chart")
            dt.Columns.Add("Book_State")
            dt.Columns.Add("Source_Table_Name")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("PreLend_No")
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

  Class PUBPatientSchedulePt
    Private m_Book_Type_Id As String = "Book_Type_Id"
    Public ReadOnly Property Book_Type_Id() As System.String 
    Get
        Return m_Book_Type_Id
    End Get
    End Property

    Private m_Chart_No As String = "Chart_No"
    Public ReadOnly Property Chart_No() As System.String 
    Get
        Return m_Chart_No
    End Get
    End Property

    Private m_Book_Date As String = "Book_Date"
    Public ReadOnly Property Book_Date() As System.String 
    Get
        Return m_Book_Date
    End Get
    End Property

    Private m_Book_Time As String = "Book_Time"
    Public ReadOnly Property Book_Time() As System.String 
    Get
        Return m_Book_Time
    End Get
    End Property

    Private m_CheckIn_Dept_Code As String = "CheckIn_Dept_Code"
    Public ReadOnly Property CheckIn_Dept_Code() As System.String 
    Get
        Return m_CheckIn_Dept_Code
    End Get
    End Property

    Private m_CheckIn_Section_Id As String = "CheckIn_Section_Id"
    Public ReadOnly Property CheckIn_Section_Id() As System.String 
    Get
        Return m_CheckIn_Section_Id
    End Get
    End Property

    Private m_CheckIn_Reg_Sn As String = "CheckIn_Reg_Sn"
    Public ReadOnly Property CheckIn_Reg_Sn() As System.String 
    Get
        Return m_CheckIn_Reg_Sn
    End Get
    End Property

    Private m_Medical_Sn As String = "Medical_Sn"
    Public ReadOnly Property Medical_Sn() As System.String 
    Get
        Return m_Medical_Sn
    End Get
    End Property

    Private m_Is_PreLend_Chart As String = "Is_PreLend_Chart"
    Public ReadOnly Property Is_PreLend_Chart() As System.String 
    Get
        Return m_Is_PreLend_Chart
    End Get
    End Property

    Private m_Book_State As String = "Book_State"
    Public ReadOnly Property Book_State() As System.String 
    Get
        Return m_Book_State
    End Get
    End Property

    Private m_Source_Table_Name As String = "Source_Table_Name"
    Public ReadOnly Property Source_Table_Name() As System.String 
    Get
        Return m_Source_Table_Name
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

    Private m_PreLend_No As String = "PreLend_No"
    Public ReadOnly Property PreLend_No() As System.String 
    Get
        Return m_PreLend_No
    End Get
    End Property

  End Class

End Class
