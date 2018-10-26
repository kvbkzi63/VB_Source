Imports System.Data.SqlClient
Public Class JobPgJobRecordDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/7/28 下午 08:28:01
    Public Shared ReadOnly tableName as String="JOB_PG_JOB_Record"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "JOB_Code", "Seq_No", "Issue_Desc", "FID", "Create_User",   _
             "Create_Time", "Modified_User", "Modified_Time", "System_Code"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Int32", "System.String", "System.String", "System.String",   _
             "System.DateTime", "System.String", "System.DateTime", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             200, -1, 4000, 200, 10,   _
             -1, 10, -1, 10}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = JobPgJobRecordDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("JOB_Code") = New Object
        dataRow("Seq_No") = New Object
        dataRow("Issue_Desc") = New Object
        dataRow("FID") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("System_Code") = New Object
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
            dt.Columns.Add("JOB_Code")
            dt.Columns.Add("Seq_No")
            dt.Columns.Add("Issue_Desc")
            dt.Columns.Add("FID")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("System_Code")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("JOB_Code")
            pkColArray(1) = dt.Columns("Seq_No")
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
            dt.Columns.Add("JOB_Code")
            dt.Columns("JOB_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Seq_No")
            dt.Columns("Seq_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Issue_Desc")
            dt.Columns("Issue_Desc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("FID")
            dt.Columns("FID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("System_Code")
            dt.Columns("System_Code").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("JOB_Code")
            pkColArray(1) = dt.Columns("Seq_No")
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
            dt.Columns.Add("JOB_Code")
            dt.Columns.Add("Seq_No")
            dt.Columns.Add("Issue_Desc")
            dt.Columns.Add("FID")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("System_Code")
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

  Class JOBPGJOBRecordPt
    Private m_JOB_Code As String = "JOB_Code"
    Public ReadOnly Property JOB_Code() As System.String 
    Get
        Return m_JOB_Code
    End Get
    End Property

    Private m_Seq_No As String = "Seq_No"
    Public ReadOnly Property Seq_No() As System.String 
    Get
        Return m_Seq_No
    End Get
    End Property

    Private m_Issue_Desc As String = "Issue_Desc"
    Public ReadOnly Property Issue_Desc() As System.String 
    Get
        Return m_Issue_Desc
    End Get
    End Property

    Private m_FID As String = "FID"
    Public ReadOnly Property FID() As System.String 
    Get
        Return m_FID
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

    Private m_System_Code As String = "System_Code"
    Public ReadOnly Property System_Code() As System.String 
    Get
        Return m_System_Code
    End Get
    End Property

  End Class

End Class
