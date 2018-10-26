Imports System.Data.SqlClient
Public Class IccInteractVerify2DataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/10/26 下午 04:52:27
    Public Shared ReadOnly tableName as String="ICC_Interact_Verify2"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Serial_Sn", "ID1", "ID1_Values", "ID2", "ID2_Values",   _
             "Is_Zero_Or_Empty", "Create_User", "Create_Time", "Modified_User", "Modified_Time"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 10, 200, 10, 200,   _
             1, 10, -1, 10, -1  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccInteractVerify2DataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Serial_Sn") = New Object
        dataRow("ID1") = New Object
        dataRow("ID1_Values") = New Object
        dataRow("ID2") = New Object
        dataRow("ID2_Values") = New Object
        dataRow("Is_Zero_Or_Empty") = New Object
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
            dt.Columns.Add("Serial_Sn")
            dt.Columns.Add("ID1")
            dt.Columns.Add("ID1_Values")
            dt.Columns.Add("ID2")
            dt.Columns.Add("ID2_Values")
            dt.Columns.Add("Is_Zero_Or_Empty")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Serial_Sn")
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
            dt.Columns.Add("Serial_Sn")
            dt.Columns("Serial_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ID1")
            dt.Columns("ID1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ID1_Values")
            dt.Columns("ID1_Values").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ID2")
            dt.Columns("ID2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ID2_Values")
            dt.Columns("ID2_Values").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Zero_Or_Empty")
            dt.Columns("Is_Zero_Or_Empty").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Serial_Sn")
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
            dt.Columns.Add("Serial_Sn")
            dt.Columns.Add("ID1")
            dt.Columns.Add("ID1_Values")
            dt.Columns.Add("ID2")
            dt.Columns.Add("ID2_Values")
            dt.Columns.Add("Is_Zero_Or_Empty")
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

  Class ICCInteractVerify2Pt
    Private m_Serial_Sn As String = "Serial_Sn"
    Public ReadOnly Property Serial_Sn() As System.String 
    Get
        Return m_Serial_Sn
    End Get
    End Property

    Private m_ID1 As String = "ID1"
    Public ReadOnly Property ID1() As System.String 
    Get
        Return m_ID1
    End Get
    End Property

    Private m_ID1_Values As String = "ID1_Values"
    Public ReadOnly Property ID1_Values() As System.String 
    Get
        Return m_ID1_Values
    End Get
    End Property

    Private m_ID2 As String = "ID2"
    Public ReadOnly Property ID2() As System.String 
    Get
        Return m_ID2
    End Get
    End Property

    Private m_ID2_Values As String = "ID2_Values"
    Public ReadOnly Property ID2_Values() As System.String 
    Get
        Return m_ID2_Values
    End Get
    End Property

    Private m_Is_Zero_Or_Empty As String = "Is_Zero_Or_Empty"
    Public ReadOnly Property Is_Zero_Or_Empty() As System.String 
    Get
        Return m_Is_Zero_Or_Empty
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
