Imports System.Data.SqlClient
Public Class JobQaBugRecordDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/11/3 上午 10:08:57
    Public Shared ReadOnly tableName as String="Job_QA_Bug_Record"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Bug_Id", "Version_Id", "System_Code", "Function_Code", "Issue_Subject",   _
             "Issue_Desc", "Issue_Level", "Issue_Classify", "Retest_Date", "Retest_Version",   _
             "Test_Result", "Test_Note", "JOB_Code", "Create_User", "Create_Time",   _
             "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.DateTime", "System.Int32",   _
             "System.String", "System.String", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             20, 20, 10, 100, 150,   _
             500, 1, 1, -1, -1,   _
             2, 500, 200, 10, -1,   _
             10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = JobQaBugRecordDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Bug_Id") = New Object
        dataRow("Version_Id") = New Object
        dataRow("System_Code") = New Object
        dataRow("Function_Code") = New Object
        dataRow("Issue_Subject") = New Object
        dataRow("Issue_Desc") = New Object
        dataRow("Issue_Level") = New Object
        dataRow("Issue_Classify") = New Object
        dataRow("Retest_Date") = New Object
        dataRow("Retest_Version") = New Object
        dataRow("Test_Result") = New Object
        dataRow("Test_Note") = New Object
        dataRow("JOB_Code") = New Object
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
            dt.Columns.Add("Bug_Id")
            dt.Columns.Add("Version_Id")
            dt.Columns.Add("System_Code")
            dt.Columns.Add("Function_Code")
            dt.Columns.Add("Issue_Subject")
            dt.Columns.Add("Issue_Desc")
            dt.Columns.Add("Issue_Level")
            dt.Columns.Add("Issue_Classify")
            dt.Columns.Add("Retest_Date")
            dt.Columns.Add("Retest_Version")
            dt.Columns.Add("Test_Result")
            dt.Columns.Add("Test_Note")
            dt.Columns.Add("JOB_Code")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Bug_Id")
            pkColArray(1) = dt.Columns("Version_Id")
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
            dt.Columns.Add("Bug_Id")
            dt.Columns("Bug_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Version_Id")
            dt.Columns("Version_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("System_Code")
            dt.Columns("System_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Function_Code")
            dt.Columns("Function_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Issue_Subject")
            dt.Columns("Issue_Subject").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Issue_Desc")
            dt.Columns("Issue_Desc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Issue_Level")
            dt.Columns("Issue_Level").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Issue_Classify")
            dt.Columns("Issue_Classify").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Retest_Date")
            dt.Columns("Retest_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Retest_Version")
            dt.Columns("Retest_Version").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Test_Result")
            dt.Columns("Test_Result").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Test_Note")
            dt.Columns("Test_Note").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("JOB_Code")
            dt.Columns("JOB_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Bug_Id")
            pkColArray(1) = dt.Columns("Version_Id")
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
            dt.Columns.Add("Bug_Id")
            dt.Columns.Add("Version_Id")
            dt.Columns.Add("System_Code")
            dt.Columns.Add("Function_Code")
            dt.Columns.Add("Issue_Subject")
            dt.Columns.Add("Issue_Desc")
            dt.Columns.Add("Issue_Level")
            dt.Columns.Add("Issue_Classify")
            dt.Columns.Add("Retest_Date")
            dt.Columns.Add("Retest_Version")
            dt.Columns.Add("Test_Result")
            dt.Columns.Add("Test_Note")
            dt.Columns.Add("JOB_Code")
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

  Class JobQABugRecordPt
    Private m_Bug_Id As String = "Bug_Id"
    Public ReadOnly Property Bug_Id() As System.String 
    Get
        Return m_Bug_Id
    End Get
    End Property

    Private m_Version_Id As String = "Version_Id"
    Public ReadOnly Property Version_Id() As System.String 
    Get
        Return m_Version_Id
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

    Private m_Issue_Subject As String = "Issue_Subject"
    Public ReadOnly Property Issue_Subject() As System.String 
    Get
        Return m_Issue_Subject
    End Get
    End Property

    Private m_Issue_Desc As String = "Issue_Desc"
    Public ReadOnly Property Issue_Desc() As System.String 
    Get
        Return m_Issue_Desc
    End Get
    End Property

    Private m_Issue_Level As String = "Issue_Level"
    Public ReadOnly Property Issue_Level() As System.String 
    Get
        Return m_Issue_Level
    End Get
    End Property

    Private m_Issue_Classify As String = "Issue_Classify"
    Public ReadOnly Property Issue_Classify() As System.String 
    Get
        Return m_Issue_Classify
    End Get
    End Property

    Private m_Retest_Date As String = "Retest_Date"
    Public ReadOnly Property Retest_Date() As System.String 
    Get
        Return m_Retest_Date
    End Get
    End Property

    Private m_Retest_Version As String = "Retest_Version"
    Public ReadOnly Property Retest_Version() As System.String 
    Get
        Return m_Retest_Version
    End Get
    End Property

    Private m_Test_Result As String = "Test_Result"
    Public ReadOnly Property Test_Result() As System.String 
    Get
        Return m_Test_Result
    End Get
    End Property

    Private m_Test_Note As String = "Test_Note"
    Public ReadOnly Property Test_Note() As System.String 
    Get
        Return m_Test_Note
    End Get
    End Property

    Private m_JOB_Code As String = "JOB_Code"
    Public ReadOnly Property JOB_Code() As System.String 
    Get
        Return m_JOB_Code
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
  Class DBColumnName 
    Private Shared ReadOnly m_Bug_Id As String = "Bug_Id"
    Public Shared ReadOnly Property Bug_Id() As System.String 
    Get
        Return m_Bug_Id
    End Get
    End Property

    Private Shared ReadOnly m_Version_Id As String = "Version_Id"
    Public Shared ReadOnly Property Version_Id() As System.String 
    Get
        Return m_Version_Id
    End Get
    End Property

    Private Shared ReadOnly m_System_Code As String = "System_Code"
    Public Shared ReadOnly Property System_Code() As System.String 
    Get
        Return m_System_Code
    End Get
    End Property

    Private Shared ReadOnly m_Function_Code As String = "Function_Code"
    Public Shared ReadOnly Property Function_Code() As System.String 
    Get
        Return m_Function_Code
    End Get
    End Property

    Private Shared ReadOnly m_Issue_Subject As String = "Issue_Subject"
    Public Shared ReadOnly Property Issue_Subject() As System.String 
    Get
        Return m_Issue_Subject
    End Get
    End Property

    Private Shared ReadOnly m_Issue_Desc As String = "Issue_Desc"
    Public Shared ReadOnly Property Issue_Desc() As System.String 
    Get
        Return m_Issue_Desc
    End Get
    End Property

    Private Shared ReadOnly m_Issue_Level As String = "Issue_Level"
    Public Shared ReadOnly Property Issue_Level() As System.String 
    Get
        Return m_Issue_Level
    End Get
    End Property

    Private Shared ReadOnly m_Issue_Classify As String = "Issue_Classify"
    Public Shared ReadOnly Property Issue_Classify() As System.String 
    Get
        Return m_Issue_Classify
    End Get
    End Property

    Private Shared ReadOnly m_Retest_Date As String = "Retest_Date"
    Public Shared ReadOnly Property Retest_Date() As System.String 
    Get
        Return m_Retest_Date
    End Get
    End Property

    Private Shared ReadOnly m_Retest_Version As String = "Retest_Version"
    Public Shared ReadOnly Property Retest_Version() As System.String 
    Get
        Return m_Retest_Version
    End Get
    End Property

    Private Shared ReadOnly m_Test_Result As String = "Test_Result"
    Public Shared ReadOnly Property Test_Result() As System.String 
    Get
        Return m_Test_Result
    End Get
    End Property

    Private Shared ReadOnly m_Test_Note As String = "Test_Note"
    Public Shared ReadOnly Property Test_Note() As System.String 
    Get
        Return m_Test_Note
    End Get
    End Property

    Private Shared ReadOnly m_JOB_Code As String = "JOB_Code"
    Public Shared ReadOnly Property JOB_Code() As System.String 
    Get
        Return m_JOB_Code
    End Get
    End Property

    Private Shared ReadOnly m_Create_User As String = "Create_User"
    Public Shared ReadOnly Property Create_User() As System.String 
    Get
        Return m_Create_User
    End Get
    End Property

    Private Shared ReadOnly m_Create_Time As String = "Create_Time"
    Public Shared ReadOnly Property Create_Time() As System.String 
    Get
        Return m_Create_Time
    End Get
    End Property

    Private Shared ReadOnly m_Modified_User As String = "Modified_User"
    Public Shared ReadOnly Property Modified_User() As System.String 
    Get
        Return m_Modified_User
    End Get
    End Property

    Private Shared ReadOnly m_Modified_Time As String = "Modified_Time"
    Public Shared ReadOnly Property Modified_Time() As System.String 
    Get
        Return m_Modified_Time
    End Get
    End Property

  End Class

End Class
