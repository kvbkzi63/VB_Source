Imports System.Data.SqlClient
Public Class PubAccountDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/9/20 上午 10:22:15
    Public Shared ReadOnly tableName as String="PUB_Account"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Account_Id", "Receipt_Account_Id", "Insu_Account_Id", "Acc1_Account_Id", "Acc2_Account_Id",   _
             "Dc", "Create_User", "Create_Time", "Modified_User", "Modified_Time",   _
             "BIL_Seqno"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime",   _
             "System.Int32"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             5, 5, 5, 5, 5,   _
             1, 10, -1, 10, -1,   _
             -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubAccountDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Account_Id") = New Object
        dataRow("Receipt_Account_Id") = New Object
        dataRow("Insu_Account_Id") = New Object
        dataRow("Acc1_Account_Id") = New Object
        dataRow("Acc2_Account_Id") = New Object
        dataRow("Dc") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("BIL_Seqno") = New Object
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
            dt.Columns.Add("Account_Id")
            dt.Columns.Add("Receipt_Account_Id")
            dt.Columns.Add("Insu_Account_Id")
            dt.Columns.Add("Acc1_Account_Id")
            dt.Columns.Add("Acc2_Account_Id")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("BIL_Seqno")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Account_Id")
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
            dt.Columns.Add("Account_Id")
            dt.Columns("Account_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Receipt_Account_Id")
            dt.Columns("Receipt_Account_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Account_Id")
            dt.Columns("Insu_Account_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Acc1_Account_Id")
            dt.Columns("Acc1_Account_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Acc2_Account_Id")
            dt.Columns("Acc2_Account_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dc")
            dt.Columns("Dc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("BIL_Seqno")
            dt.Columns("BIL_Seqno").DataType = System.Type.GetType("System.Int32")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Account_Id")
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
            dt.Columns.Add("Account_Id")
            dt.Columns.Add("Receipt_Account_Id")
            dt.Columns.Add("Insu_Account_Id")
            dt.Columns.Add("Acc1_Account_Id")
            dt.Columns.Add("Acc2_Account_Id")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("BIL_Seqno")
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

  Class PUBAccountPt
    Private m_Account_Id As String = "Account_Id"
    Public ReadOnly Property Account_Id() As System.String 
    Get
        Return m_Account_Id
    End Get
    End Property

    Private m_Receipt_Account_Id As String = "Receipt_Account_Id"
    Public ReadOnly Property Receipt_Account_Id() As System.String 
    Get
        Return m_Receipt_Account_Id
    End Get
    End Property

    Private m_Insu_Account_Id As String = "Insu_Account_Id"
    Public ReadOnly Property Insu_Account_Id() As System.String 
    Get
        Return m_Insu_Account_Id
    End Get
    End Property

    Private m_Acc1_Account_Id As String = "Acc1_Account_Id"
    Public ReadOnly Property Acc1_Account_Id() As System.String 
    Get
        Return m_Acc1_Account_Id
    End Get
    End Property

    Private m_Acc2_Account_Id As String = "Acc2_Account_Id"
    Public ReadOnly Property Acc2_Account_Id() As System.String 
    Get
        Return m_Acc2_Account_Id
    End Get
    End Property

    Private m_Dc As String = "Dc"
    Public ReadOnly Property Dc() As System.String 
    Get
        Return m_Dc
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

    Private m_BIL_Seqno As String = "BIL_Seqno"
    Public ReadOnly Property BIL_Seqno() As System.String 
    Get
        Return m_BIL_Seqno
    End Get
    End Property

  End Class

End Class
