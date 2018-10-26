Imports System.Data.SqlClient
Public Class PubPrintJobDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:53
    Public Shared ReadOnly tableName as String="PUB_Print_Job"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Job_ID", "Report_ID", "FID", "Report_Name", "Condition_Param",   _
             "Report_Status", "Process_Msg", "Create_User", "Create_Time", "Modified_User",   _
             "Modified_Time", "Download_Cnt"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.DateTime", "System.String",   _
             "System.DateTime", "System.Int32"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             20, 20, 50, 100, 4000,   _
             1, 4000, 10, -1, 10,   _
             -1, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubPrintJobDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Job_ID") = New Object
        dataRow("Report_ID") = New Object
        dataRow("FID") = New Object
        dataRow("Report_Name") = New Object
        dataRow("Condition_Param") = New Object
        dataRow("Report_Status") = New Object
        dataRow("Process_Msg") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Download_Cnt") = New Object
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
            dt.Columns.Add("Job_ID")
            dt.Columns.Add("Report_ID")
            dt.Columns.Add("FID")
            dt.Columns.Add("Report_Name")
            dt.Columns.Add("Condition_Param")
            dt.Columns.Add("Report_Status")
            dt.Columns.Add("Process_Msg")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Download_Cnt")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Job_ID")
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
            dt.Columns.Add("Job_ID")
            dt.Columns("Job_ID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Report_ID")
            dt.Columns("Report_ID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("FID")
            dt.Columns("FID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Report_Name")
            dt.Columns("Report_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Condition_Param")
            dt.Columns("Condition_Param").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Report_Status")
            dt.Columns("Report_Status").DataType = System.Type.GetType("System.String")
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
            dt.Columns.Add("Download_Cnt")
            dt.Columns("Download_Cnt").DataType = System.Type.GetType("System.Int32")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Job_ID")
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
            dt.Columns.Add("Job_ID")
            dt.Columns.Add("Report_ID")
            dt.Columns.Add("FID")
            dt.Columns.Add("Report_Name")
            dt.Columns.Add("Condition_Param")
            dt.Columns.Add("Report_Status")
            dt.Columns.Add("Process_Msg")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Download_Cnt")
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

  Class PUBPrintJobPt
    Private m_Job_ID As String = "Job_ID"
    Public ReadOnly Property Job_ID() As System.String 
    Get
        Return m_Job_ID
    End Get
    End Property

    Private m_Report_ID As String = "Report_ID"
    Public ReadOnly Property Report_ID() As System.String 
    Get
        Return m_Report_ID
    End Get
    End Property

    Private m_FID As String = "FID"
    Public ReadOnly Property FID() As System.String 
    Get
        Return m_FID
    End Get
    End Property

    Private m_Report_Name As String = "Report_Name"
    Public ReadOnly Property Report_Name() As System.String 
    Get
        Return m_Report_Name
    End Get
    End Property

    Private m_Condition_Param As String = "Condition_Param"
    Public ReadOnly Property Condition_Param() As System.String 
    Get
        Return m_Condition_Param
    End Get
    End Property

    Private m_Report_Status As String = "Report_Status"
    Public ReadOnly Property Report_Status() As System.String 
    Get
        Return m_Report_Status
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

    Private m_Download_Cnt As String = "Download_Cnt"
    Public ReadOnly Property Download_Cnt() As System.String 
    Get
        Return m_Download_Cnt
    End Get
    End Property

  End Class

End Class
