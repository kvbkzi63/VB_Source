Imports System.Data.SqlClient
Public Class PrjProjectSystemFunctionDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/6/16 下午 12:33:22
    Public Shared ReadOnly tableName as String="PRJ_Project_System_Function"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Project_ID", "System_Code", "Function_Code", "Function_Name", "Create_User",   _
             "Create_Time", "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.DateTime", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 100, 100, 200, 10,   _
             -1, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PrjProjectSystemFunctionDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Project_ID") = New Object
        dataRow("System_Code") = New Object
        dataRow("Function_Code") = New Object
        dataRow("Function_Name") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataTable.Rows.Add(dataRow) 
        dataSet.Tables.Add(dataTable) 
    End sub 

    ''' <summary>
    '''取得資料庫表格(無主鍵)的 DataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTable() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName)
            dt.Columns.Add("Project_ID")
            dt.Columns.Add("System_Code")
            dt.Columns.Add("Function_Code")
            dt.Columns.Add("Function_Name")
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
    '''取得資料庫表格(無主鍵)的 DataTable 加上各欄位的資料型態
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTableWithSchema() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName)
            dt.Columns.Add("Project_ID")
            dt.Columns("Project_ID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("System_Code")
            dt.Columns("System_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Function_Code")
            dt.Columns("Function_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Function_Name")
            dt.Columns("Function_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 

  Class PRJProjectSystemFunctionPt
    Private m_Project_ID As String = "Project_ID"
    Public ReadOnly Property Project_ID() As System.String 
    Get
        Return m_Project_ID
    End Get
    End Property

    Private m_System_Code As String = "System_Code"
    Public ReadOnly Property System_Code() As System.String 
    Get
        Return m_System_Code
    End Get
    End Property

    Private m_Function_Code As String = "Function_Code"
    Public ReadOnly Property Function_Code() As System.String 
    Get
        Return m_Function_Code
    End Get
    End Property

    Private m_Function_Name As String = "Function_Name"
    Public ReadOnly Property Function_Name() As System.String 
    Get
        Return m_Function_Name
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
