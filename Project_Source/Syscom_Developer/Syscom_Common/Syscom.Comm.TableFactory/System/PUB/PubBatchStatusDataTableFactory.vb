Imports System.Data.SqlClient
Public Class PubBatchStatusDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:47
    Public Shared ReadOnly tableName as String="PUB_Batch_Status"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Batch_Job_ID", "Batch_Job", "Batch_Path", "Schedule_Type", "Schedule_Start_Time",   _
             "Batch_Stauts", "Last_Excuted_Time", "Last_Excuted_Result", "Next_Excute_Time", "Status_Update_Time",   _
             "Batch_Type"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.Int32", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.DateTime",   _
             "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             -1, 50, 250, 10, 30,   _
             10, 30, 1, 30, -1,   _
             15}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubBatchStatusDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Batch_Job_ID") = New Object
        dataRow("Batch_Job") = New Object
        dataRow("Batch_Path") = New Object
        dataRow("Schedule_Type") = New Object
        dataRow("Schedule_Start_Time") = New Object
        dataRow("Batch_Stauts") = New Object
        dataRow("Last_Excuted_Time") = New Object
        dataRow("Last_Excuted_Result") = New Object
        dataRow("Next_Excute_Time") = New Object
        dataRow("Status_Update_Time") = New Object
        dataRow("Batch_Type") = New Object
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
            dt.Columns.Add("Batch_Job_ID")
            dt.Columns.Add("Batch_Job")
            dt.Columns.Add("Batch_Path")
            dt.Columns.Add("Schedule_Type")
            dt.Columns.Add("Schedule_Start_Time")
            dt.Columns.Add("Batch_Stauts")
            dt.Columns.Add("Last_Excuted_Time")
            dt.Columns.Add("Last_Excuted_Result")
            dt.Columns.Add("Next_Excute_Time")
            dt.Columns.Add("Status_Update_Time")
            dt.Columns.Add("Batch_Type")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Batch_Job_ID")
            pkColArray(1) = dt.Columns("Batch_Job")
            pkColArray(2) = dt.Columns("Batch_Type")
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
            dt.Columns.Add("Batch_Job_ID")
            dt.Columns("Batch_Job_ID").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Batch_Job")
            dt.Columns("Batch_Job").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Batch_Path")
            dt.Columns("Batch_Path").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Schedule_Type")
            dt.Columns("Schedule_Type").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Schedule_Start_Time")
            dt.Columns("Schedule_Start_Time").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Batch_Stauts")
            dt.Columns("Batch_Stauts").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Last_Excuted_Time")
            dt.Columns("Last_Excuted_Time").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Last_Excuted_Result")
            dt.Columns("Last_Excuted_Result").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Next_Excute_Time")
            dt.Columns("Next_Excute_Time").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Status_Update_Time")
            dt.Columns("Status_Update_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Batch_Type")
            dt.Columns("Batch_Type").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Batch_Job_ID")
            pkColArray(1) = dt.Columns("Batch_Job")
            pkColArray(2) = dt.Columns("Batch_Type")
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
            dt.Columns.Add("Batch_Job_ID")
            dt.Columns.Add("Batch_Job")
            dt.Columns.Add("Batch_Path")
            dt.Columns.Add("Schedule_Type")
            dt.Columns.Add("Schedule_Start_Time")
            dt.Columns.Add("Batch_Stauts")
            dt.Columns.Add("Last_Excuted_Time")
            dt.Columns.Add("Last_Excuted_Result")
            dt.Columns.Add("Next_Excute_Time")
            dt.Columns.Add("Status_Update_Time")
            dt.Columns.Add("Batch_Type")
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

  Class PUBBatchStatusPt
    Private m_Batch_Job_ID As String = "Batch_Job_ID"
    Public ReadOnly Property Batch_Job_ID() As System.String 
    Get
        Return m_Batch_Job_ID
    End Get
    End Property

    Private m_Batch_Job As String = "Batch_Job"
    Public ReadOnly Property Batch_Job() As System.String 
    Get
        Return m_Batch_Job
    End Get
    End Property

    Private m_Batch_Path As String = "Batch_Path"
    Public ReadOnly Property Batch_Path() As System.String 
    Get
        Return m_Batch_Path
    End Get
    End Property

    Private m_Schedule_Type As String = "Schedule_Type"
    Public ReadOnly Property Schedule_Type() As System.String 
    Get
        Return m_Schedule_Type
    End Get
    End Property

    Private m_Schedule_Start_Time As String = "Schedule_Start_Time"
    Public ReadOnly Property Schedule_Start_Time() As System.String 
    Get
        Return m_Schedule_Start_Time
    End Get
    End Property

    Private m_Batch_Stauts As String = "Batch_Stauts"
    Public ReadOnly Property Batch_Stauts() As System.String 
    Get
        Return m_Batch_Stauts
    End Get
    End Property

    Private m_Last_Excuted_Time As String = "Last_Excuted_Time"
    Public ReadOnly Property Last_Excuted_Time() As System.String 
    Get
        Return m_Last_Excuted_Time
    End Get
    End Property

    Private m_Last_Excuted_Result As String = "Last_Excuted_Result"
    Public ReadOnly Property Last_Excuted_Result() As System.String 
    Get
        Return m_Last_Excuted_Result
    End Get
    End Property

    Private m_Next_Excute_Time As String = "Next_Excute_Time"
    Public ReadOnly Property Next_Excute_Time() As System.String 
    Get
        Return m_Next_Excute_Time
    End Get
    End Property

    Private m_Status_Update_Time As String = "Status_Update_Time"
    Public ReadOnly Property Status_Update_Time() As System.String 
    Get
        Return m_Status_Update_Time
    End Get
    End Property

    Private m_Batch_Type As String = "Batch_Type"
    Public ReadOnly Property Batch_Type() As System.String 
    Get
        Return m_Batch_Type
    End Get
    End Property

  End Class

End Class
