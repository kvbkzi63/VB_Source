Imports System.Data.SqlClient
Public Class PubBatchJobDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/2/9 上午 10:09:30
    Public Shared ReadOnly tableName as String="PUB_Batch_Job"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Fun_Function_No", "Condition_Param", "Prepare_Exe_Time", "Exe_Time", "Process_Msg",   _
             "Create_User", "Create_Time", "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.DateTime", "System.DateTime", "System.String",   _
             "System.String", "System.DateTime", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             40, 4000, -1, -1, 4000,   _
             10, -1, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubBatchJobDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Fun_Function_No") = New Object
        dataRow("Condition_Param") = New Object
        dataRow("Prepare_Exe_Time") = New Object
        dataRow("Exe_Time") = New Object
        dataRow("Process_Msg") = New Object
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
            dt.Columns.Add("Fun_Function_No")
            dt.Columns.Add("Condition_Param")
            dt.Columns.Add("Prepare_Exe_Time")
            dt.Columns.Add("Exe_Time")
            dt.Columns.Add("Process_Msg")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Create_Time")
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
            dt.Columns.Add("Fun_Function_No")
            dt.Columns("Fun_Function_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Condition_Param")
            dt.Columns("Condition_Param").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Prepare_Exe_Time")
            dt.Columns("Prepare_Exe_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Exe_Time")
            dt.Columns("Exe_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Process_Msg")
            dt.Columns("Process_Msg").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Create_Time")
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
            dt.Columns.Add("Fun_Function_No")
            dt.Columns.Add("Condition_Param")
            dt.Columns.Add("Prepare_Exe_Time")
            dt.Columns.Add("Exe_Time")
            dt.Columns.Add("Process_Msg")
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

  Class PUBBatchJobPt
    Private m_Fun_Function_No As String = "Fun_Function_No"
    Public ReadOnly Property Fun_Function_No() As System.String 
    Get
        Return m_Fun_Function_No
    End Get
    End Property

    Private m_Condition_Param As String = "Condition_Param"
    Public ReadOnly Property Condition_Param() As System.String 
    Get
        Return m_Condition_Param
    End Get
    End Property

    Private m_Prepare_Exe_Time As String = "Prepare_Exe_Time"
    Public ReadOnly Property Prepare_Exe_Time() As System.String 
    Get
        Return m_Prepare_Exe_Time
    End Get
    End Property

    Private m_Exe_Time As String = "Exe_Time"
    Public ReadOnly Property Exe_Time() As System.String 
    Get
        Return m_Exe_Time
    End Get
    End Property

    Private m_Process_Msg As String = "Process_Msg"
    Public ReadOnly Property Process_Msg() As System.String 
    Get
        Return m_Process_Msg
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
