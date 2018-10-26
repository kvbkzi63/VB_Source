Imports System.Data.SqlClient
Public Class PubPrintRecordDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:53
    Public Shared ReadOnly tableName as String="PUB_Print_Record"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Report_ID", "Create_User", "Create_Time", "Report_Name", "Print_IP",   _
             "Print_Machine_Name"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.DateTime", "System.String", "System.String",   _
             "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             20, 10, -1, 100, 39,   _
             20}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubPrintRecordDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Report_ID") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Report_Name") = New Object
        dataRow("Print_IP") = New Object
        dataRow("Print_Machine_Name") = New Object
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
            dt.Columns.Add("Report_ID")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Report_Name")
            dt.Columns.Add("Print_IP")
            dt.Columns.Add("Print_Machine_Name")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Report_ID")
            pkColArray(1) = dt.Columns("Create_User")
            pkColArray(2) = dt.Columns("Create_Time")
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
            dt.Columns.Add("Report_ID")
            dt.Columns("Report_ID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Report_Name")
            dt.Columns("Report_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Print_IP")
            dt.Columns("Print_IP").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Print_Machine_Name")
            dt.Columns("Print_Machine_Name").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Report_ID")
            pkColArray(1) = dt.Columns("Create_User")
            pkColArray(2) = dt.Columns("Create_Time")
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
            dt.Columns.Add("Report_ID")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Report_Name")
            dt.Columns.Add("Print_IP")
            dt.Columns.Add("Print_Machine_Name")
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

  Class PUBPrintRecordPt
    Private m_Report_ID As String = "Report_ID"
    Public ReadOnly Property Report_ID() As System.String 
    Get
        Return m_Report_ID
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

    Private m_Report_Name As String = "Report_Name"
    Public ReadOnly Property Report_Name() As System.String 
    Get
        Return m_Report_Name
    End Get
    End Property

    Private m_Print_IP As String = "Print_IP"
    Public ReadOnly Property Print_IP() As System.String 
    Get
        Return m_Print_IP
    End Get
    End Property

    Private m_Print_Machine_Name As String = "Print_Machine_Name"
    Public ReadOnly Property Print_Machine_Name() As System.String 
    Get
        Return m_Print_Machine_Name
    End Get
    End Property

  End Class

End Class
