Imports System.Data.SqlClient
Public Class IccInteractVerify3DataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/10/26 下午 04:52:39
    Public Shared ReadOnly tableName as String="ICC_Interact_Verify3"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Serial_Sn", "ID", "ID_Values", "One_Of_IDs", "Min_Value",   _
             "Max_Value", "Create_User", "Create_Time", "Modified_User", "Modified_Time"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.DateTime", "System.String", "System.String"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 10, 200, 50, 10,   _
             10, 10, -1, 10, 10  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccInteractVerify3DataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Serial_Sn") = New Object
        dataRow("ID") = New Object
        dataRow("ID_Values") = New Object
        dataRow("One_Of_IDs") = New Object
        dataRow("Min_Value") = New Object
        dataRow("Max_Value") = New Object
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
            dt.Columns.Add("ID")
            dt.Columns.Add("ID_Values")
            dt.Columns.Add("One_Of_IDs")
            dt.Columns.Add("Min_Value")
            dt.Columns.Add("Max_Value")
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
            dt.Columns.Add("ID")
            dt.Columns("ID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ID_Values")
            dt.Columns("ID_Values").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("One_Of_IDs")
            dt.Columns("One_Of_IDs").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Min_Value")
            dt.Columns("Min_Value").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Max_Value")
            dt.Columns("Max_Value").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.String")
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
            dt.Columns.Add("ID")
            dt.Columns.Add("ID_Values")
            dt.Columns.Add("One_Of_IDs")
            dt.Columns.Add("Min_Value")
            dt.Columns.Add("Max_Value")
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

  Class ICCInteractVerify3Pt
    Private m_Serial_Sn As String = "Serial_Sn"
    Public ReadOnly Property Serial_Sn() As System.String 
    Get
        Return m_Serial_Sn
    End Get
    End Property

    Private m_ID As String = "ID"
    Public ReadOnly Property ID() As System.String 
    Get
        Return m_ID
    End Get
    End Property

    Private m_ID_Values As String = "ID_Values"
    Public ReadOnly Property ID_Values() As System.String 
    Get
        Return m_ID_Values
    End Get
    End Property

    Private m_One_Of_IDs As String = "One_Of_IDs"
    Public ReadOnly Property One_Of_IDs() As System.String 
    Get
        Return m_One_Of_IDs
    End Get
    End Property

    Private m_Min_Value As String = "Min_Value"
    Public ReadOnly Property Min_Value() As System.String 
    Get
        Return m_Min_Value
    End Get
    End Property

    Private m_Max_Value As String = "Max_Value"
    Public ReadOnly Property Max_Value() As System.String 
    Get
        Return m_Max_Value
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
