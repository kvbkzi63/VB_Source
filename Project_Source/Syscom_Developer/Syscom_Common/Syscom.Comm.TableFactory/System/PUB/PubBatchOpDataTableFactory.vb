Imports System.Data.SqlClient
Public Class PubBatchOpDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:47
    Public Shared ReadOnly tableName as String="PUB_Batch_OP"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Batch_Job", "Effective_OP_Check", "Effective_OP_Notify", "Notify_Mail"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             50, 1, 1, 200}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubBatchOpDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Batch_Job") = New Object
        dataRow("Effective_OP_Check") = New Object
        dataRow("Effective_OP_Notify") = New Object
        dataRow("Notify_Mail") = New Object
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
            dt.Columns.Add("Batch_Job")
            dt.Columns.Add("Effective_OP_Check")
            dt.Columns.Add("Effective_OP_Notify")
            dt.Columns.Add("Notify_Mail")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Batch_Job")
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
            dt.Columns.Add("Batch_Job")
            dt.Columns("Batch_Job").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Effective_OP_Check")
            dt.Columns("Effective_OP_Check").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Effective_OP_Notify")
            dt.Columns("Effective_OP_Notify").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Notify_Mail")
            dt.Columns("Notify_Mail").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Batch_Job")
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
            dt.Columns.Add("Batch_Job")
            dt.Columns.Add("Effective_OP_Check")
            dt.Columns.Add("Effective_OP_Notify")
            dt.Columns.Add("Notify_Mail")
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

  Class PUBBatchOPPt
    Private m_Batch_Job As String = "Batch_Job"
    Public ReadOnly Property Batch_Job() As System.String 
    Get
        Return m_Batch_Job
    End Get
    End Property

    Private m_Effective_OP_Check As String = "Effective_OP_Check"
    Public ReadOnly Property Effective_OP_Check() As System.String 
    Get
        Return m_Effective_OP_Check
    End Get
    End Property

    Private m_Effective_OP_Notify As String = "Effective_OP_Notify"
    Public ReadOnly Property Effective_OP_Notify() As System.String 
    Get
        Return m_Effective_OP_Notify
    End Get
    End Property

    Private m_Notify_Mail As String = "Notify_Mail"
    Public ReadOnly Property Notify_Mail() As System.String 
    Get
        Return m_Notify_Mail
    End Get
    End Property

  End Class

End Class
