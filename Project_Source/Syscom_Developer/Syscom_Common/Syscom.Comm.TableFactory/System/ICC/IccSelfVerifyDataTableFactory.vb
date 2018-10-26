Imports System.Data.SqlClient
Public Class IccSelfVerifyDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/10/26 下午 04:54:54
    Public Shared ReadOnly tableName as String="ICC_Self_Verify"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "ID", "ID_Values", "Is_Empty", "Is_Num", "Greater_Num",   _
             "Less_Num", "Create_User", "Create_Time", "Modified_User", "Modified_Time"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.Int32",   _
             "System.Int32", "System.String", "System.DateTime", "System.String", "System.DateTime"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 200, 1, 1, -1,   _
             -1, 10, -1, 10, -1  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccSelfVerifyDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("ID") = New Object
        dataRow("ID_Values") = New Object
        dataRow("Is_Empty") = New Object
        dataRow("Is_Num") = New Object
        dataRow("Greater_Num") = New Object
        dataRow("Less_Num") = New Object
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
            dt.Columns.Add("ID")
            dt.Columns.Add("ID_Values")
            dt.Columns.Add("Is_Empty")
            dt.Columns.Add("Is_Num")
            dt.Columns.Add("Greater_Num")
            dt.Columns.Add("Less_Num")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("ID")
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
            dt.Columns.Add("ID")
            dt.Columns("ID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ID_Values")
            dt.Columns("ID_Values").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Empty")
            dt.Columns("Is_Empty").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Num")
            dt.Columns("Is_Num").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Greater_Num")
            dt.Columns("Greater_Num").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Less_Num")
            dt.Columns("Less_Num").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("ID")
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
            dt.Columns.Add("ID")
            dt.Columns.Add("ID_Values")
            dt.Columns.Add("Is_Empty")
            dt.Columns.Add("Is_Num")
            dt.Columns.Add("Greater_Num")
            dt.Columns.Add("Less_Num")
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

  Class ICCSelfVerifyPt
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

    Private m_Is_Empty As String = "Is_Empty"
    Public ReadOnly Property Is_Empty() As System.String 
    Get
        Return m_Is_Empty
    End Get
    End Property

    Private m_Is_Num As String = "Is_Num"
    Public ReadOnly Property Is_Num() As System.String 
    Get
        Return m_Is_Num
    End Get
    End Property

    Private m_Greater_Num As String = "Greater_Num"
    Public ReadOnly Property Greater_Num() As System.String 
    Get
        Return m_Greater_Num
    End Get
    End Property

    Private m_Less_Num As String = "Less_Num"
    Public ReadOnly Property Less_Num() As System.String 
    Get
        Return m_Less_Num
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
