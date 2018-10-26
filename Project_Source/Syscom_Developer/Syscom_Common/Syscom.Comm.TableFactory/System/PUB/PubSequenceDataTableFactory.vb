Imports System.Data.SqlClient
Public Class PubSequenceDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:54
    Public Shared ReadOnly tableName as String="PUB_Sequence"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "type", "key", "seqno", "minno", "maxno",   _
             "create_date", "TagList", "CurrentTag"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.Int32", "System.Int32", "System.Int32",   _
             "System.DateTime", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             1, 20, -1, -1, -1,   _
             -1, 20, 1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubSequenceDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("type") = New Object
        dataRow("key") = New Object
        dataRow("seqno") = New Object
        dataRow("minno") = New Object
        dataRow("maxno") = New Object
        dataRow("create_date") = New Object
        dataRow("TagList") = New Object
        dataRow("CurrentTag") = New Object
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
            dt.Columns.Add("type")
            dt.Columns.Add("key")
            dt.Columns.Add("seqno")
            dt.Columns.Add("minno")
            dt.Columns.Add("maxno")
            dt.Columns.Add("create_date")
            dt.Columns.Add("TagList")
            dt.Columns.Add("CurrentTag")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("type")
            pkColArray(1) = dt.Columns("key")
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
            dt.Columns.Add("type")
            dt.Columns("type").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("key")
            dt.Columns("key").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("seqno")
            dt.Columns("seqno").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("minno")
            dt.Columns("minno").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("maxno")
            dt.Columns("maxno").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("create_date")
            dt.Columns("create_date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("TagList")
            dt.Columns("TagList").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("CurrentTag")
            dt.Columns("CurrentTag").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("type")
            pkColArray(1) = dt.Columns("key")
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
            dt.Columns.Add("type")
            dt.Columns.Add("key")
            dt.Columns.Add("seqno")
            dt.Columns.Add("minno")
            dt.Columns.Add("maxno")
            dt.Columns.Add("create_date")
            dt.Columns.Add("TagList")
            dt.Columns.Add("CurrentTag")
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

  Class PUBSequencePt
    Private m_type As String = "type"
    Public ReadOnly Property type() As System.String 
    Get
        Return m_type
    End Get
    End Property

    Private m_key As String = "key"
    Public ReadOnly Property key() As System.String 
    Get
        Return m_key
    End Get
    End Property

    Private m_seqno As String = "seqno"
    Public ReadOnly Property seqno() As System.String 
    Get
        Return m_seqno
    End Get
    End Property

    Private m_minno As String = "minno"
    Public ReadOnly Property minno() As System.String 
    Get
        Return m_minno
    End Get
    End Property

    Private m_maxno As String = "maxno"
    Public ReadOnly Property maxno() As System.String 
    Get
        Return m_maxno
    End Get
    End Property

    Private m_create_date As String = "create_date"
    Public ReadOnly Property create_date() As System.String 
    Get
        Return m_create_date
    End Get
    End Property

    Private m_TagList As String = "TagList"
    Public ReadOnly Property TagList() As System.String 
    Get
        Return m_TagList
    End Get
    End Property

    Private m_CurrentTag As String = "CurrentTag"
    Public ReadOnly Property CurrentTag() As System.String 
    Get
        Return m_CurrentTag
    End Get
    End Property

  End Class

End Class
