Imports System.Data.SqlClient
Public Class PubPatientDnrDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:52
    Public Shared ReadOnly tableName as String="PUB_Patient_DNR"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Chart_No", "Source_Kind", "DNR_No", "DNR_Kind_Id", "Cancel",   _
             "Cancel_User", "Cancel_Time", "Create_User", "Create_Time", "Modified_User",   _
             "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.Int32", "System.String", "System.String",   _
             "System.String", "System.DateTime", "System.String", "System.DateTime", "System.String",   _
             "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 1, -1, 5, 1,   _
             10, -1, 10, -1, 10,   _
             -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubPatientDnrDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Chart_No") = New Object
        dataRow("Source_Kind") = New Object
        dataRow("DNR_No") = New Object
        dataRow("DNR_Kind_Id") = New Object
        dataRow("Cancel") = New Object
        dataRow("Cancel_User") = New Object
        dataRow("Cancel_Time") = New Object
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
            dt.Columns.Add("Chart_No")
            dt.Columns.Add("Source_Kind")
            dt.Columns.Add("DNR_No")
            dt.Columns.Add("DNR_Kind_Id")
            dt.Columns.Add("Cancel")
            dt.Columns.Add("Cancel_User")
            dt.Columns.Add("Cancel_Time")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Source_Kind")
            pkColArray(2) = dt.Columns("DNR_No")
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
            dt.Columns.Add("Chart_No")
            dt.Columns("Chart_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Source_Kind")
            dt.Columns("Source_Kind").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("DNR_No")
            dt.Columns("DNR_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("DNR_Kind_Id")
            dt.Columns("DNR_Kind_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cancel")
            dt.Columns("Cancel").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cancel_User")
            dt.Columns("Cancel_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cancel_Time")
            dt.Columns("Cancel_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Source_Kind")
            pkColArray(2) = dt.Columns("DNR_No")
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
            dt.Columns.Add("Chart_No")
            dt.Columns.Add("Source_Kind")
            dt.Columns.Add("DNR_No")
            dt.Columns.Add("DNR_Kind_Id")
            dt.Columns.Add("Cancel")
            dt.Columns.Add("Cancel_User")
            dt.Columns.Add("Cancel_Time")
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

  Class PUBPatientDNRPt
    Private m_Chart_No As String = "Chart_No"
    Public ReadOnly Property Chart_No() As System.String 
    Get
        Return m_Chart_No
    End Get
    End Property

    Private m_Source_Kind As String = "Source_Kind"
    Public ReadOnly Property Source_Kind() As System.String 
    Get
        Return m_Source_Kind
    End Get
    End Property

    Private m_DNR_No As String = "DNR_No"
    Public ReadOnly Property DNR_No() As System.String 
    Get
        Return m_DNR_No
    End Get
    End Property

    Private m_DNR_Kind_Id As String = "DNR_Kind_Id"
    Public ReadOnly Property DNR_Kind_Id() As System.String 
    Get
        Return m_DNR_Kind_Id
    End Get
    End Property

    Private m_Cancel As String = "Cancel"
    Public ReadOnly Property Cancel() As System.String 
    Get
        Return m_Cancel
    End Get
    End Property

    Private m_Cancel_User As String = "Cancel_User"
    Public ReadOnly Property Cancel_User() As System.String 
    Get
        Return m_Cancel_User
    End Get
    End Property

    Private m_Cancel_Time As String = "Cancel_Time"
    Public ReadOnly Property Cancel_Time() As System.String 
    Get
        Return m_Cancel_Time
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
