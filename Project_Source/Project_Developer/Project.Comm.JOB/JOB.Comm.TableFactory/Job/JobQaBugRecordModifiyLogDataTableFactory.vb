Imports System.Data.SqlClient
Public Class JobQaBugRecordModifiyLogDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/11/3 上午 10:08:57
    Public Shared ReadOnly tableName as String="Job_QA_Bug_Record_Modifiy_Log"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Log_Id", "Bug_Id", "Retest_Date", "Retest_Version", "Test_Result",   _
             "Test_Note", "Create_User", "Create_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.DateTime", "System.Int32", "System.String",   _
             "System.String", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             20, 20, -1, -1, 2,   _
             500, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = JobQaBugRecordModifiyLogDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Log_Id") = New Object
        dataRow("Bug_Id") = New Object
        dataRow("Retest_Date") = New Object
        dataRow("Retest_Version") = New Object
        dataRow("Test_Result") = New Object
        dataRow("Test_Note") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
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
            dt.Columns.Add("Log_Id")
            dt.Columns.Add("Bug_Id")
            dt.Columns.Add("Retest_Date")
            dt.Columns.Add("Retest_Version")
            dt.Columns.Add("Test_Result")
            dt.Columns.Add("Test_Note")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Log_Id")
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
            dt.Columns.Add("Log_Id")
            dt.Columns("Log_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Bug_Id")
            dt.Columns("Bug_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Retest_Date")
            dt.Columns("Retest_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Retest_Version")
            dt.Columns("Retest_Version").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Test_Result")
            dt.Columns("Test_Result").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Test_Note")
            dt.Columns("Test_Note").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Log_Id")
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
            dt.Columns.Add("Log_Id")
            dt.Columns.Add("Bug_Id")
            dt.Columns.Add("Retest_Date")
            dt.Columns.Add("Retest_Version")
            dt.Columns.Add("Test_Result")
            dt.Columns.Add("Test_Note")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
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

  Class JobQABugRecordModifiyLogPt
    Private m_Log_Id As String = "Log_Id"
    Public ReadOnly Property Log_Id() As System.String 
    Get
        Return m_Log_Id
    End Get
    End Property

    Private m_Bug_Id As String = "Bug_Id"
    Public ReadOnly Property Bug_Id() As System.String 
    Get
        Return m_Bug_Id
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

  End Class
  Class DBColumnName 
    Private Shared ReadOnly m_Log_Id As String = "Log_Id"
    Public Shared ReadOnly Property Log_Id() As System.String 
    Get
        Return m_Log_Id
    End Get
    End Property

    Private Shared ReadOnly m_Bug_Id As String = "Bug_Id"
    Public Shared ReadOnly Property Bug_Id() As System.String 
    Get
        Return m_Bug_Id
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

  End Class

End Class
