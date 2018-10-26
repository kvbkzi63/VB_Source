Imports System.Data.SqlClient
Public Class IccCloudUploadLogDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/11/5 上午 09:20:01
    Public Shared ReadOnly tableName as String="ICC_Cloud_Upload_Log"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "JobId", "UploadPath", "DownloadPath", "UploadDate", "DownloadDate",   _
             "DownloadFlag"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.DateTime", "System.DateTime",   _
             "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             12, 100, 100, -1, -1,   _
             1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccCloudUploadLogDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("JobId") = New Object
        dataRow("UploadPath") = New Object
        dataRow("DownloadPath") = New Object
        dataRow("UploadDate") = New Object
        dataRow("DownloadDate") = New Object
        dataRow("DownloadFlag") = New Object
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
            dt.Columns.Add("JobId")
            dt.Columns.Add("UploadPath")
            dt.Columns.Add("DownloadPath")
            dt.Columns.Add("UploadDate")
            dt.Columns.Add("DownloadDate")
            dt.Columns.Add("DownloadFlag")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("JobId")
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
            dt.Columns.Add("JobId")
            dt.Columns("JobId").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("UploadPath")
            dt.Columns("UploadPath").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("DownloadPath")
            dt.Columns("DownloadPath").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("UploadDate")
            dt.Columns("UploadDate").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("DownloadDate")
            dt.Columns("DownloadDate").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("DownloadFlag")
            dt.Columns("DownloadFlag").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("JobId")
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
            dt.Columns.Add("JobId")
            dt.Columns.Add("UploadPath")
            dt.Columns.Add("DownloadPath")
            dt.Columns.Add("UploadDate")
            dt.Columns.Add("DownloadDate")
            dt.Columns.Add("DownloadFlag")
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

  Class ICCCloudUploadLogPt
    Private m_JobId As String = "JobId"
    Public ReadOnly Property JobId() As System.String 
    Get
        Return m_JobId
    End Get
    End Property

    Private m_UploadPath As String = "UploadPath"
    Public ReadOnly Property UploadPath() As System.String 
    Get
        Return m_UploadPath
    End Get
    End Property

    Private m_DownloadPath As String = "DownloadPath"
    Public ReadOnly Property DownloadPath() As System.String 
    Get
        Return m_DownloadPath
    End Get
    End Property

    Private m_UploadDate As String = "UploadDate"
    Public ReadOnly Property UploadDate() As System.String 
    Get
        Return m_UploadDate
    End Get
    End Property

    Private m_DownloadDate As String = "DownloadDate"
    Public ReadOnly Property DownloadDate() As System.String 
    Get
        Return m_DownloadDate
    End Get
    End Property

    Private m_DownloadFlag As String = "DownloadFlag"
    Public ReadOnly Property DownloadFlag() As System.String 
    Get
        Return m_DownloadFlag
    End Get
    End Property

  End Class

End Class
