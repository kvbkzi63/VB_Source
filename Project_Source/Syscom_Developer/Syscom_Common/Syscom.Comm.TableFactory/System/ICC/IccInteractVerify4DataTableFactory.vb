Imports System.Data.SqlClient
Public Class IccInteractVerify4DataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/10/26 下午 04:52:56
    Public Shared ReadOnly tableName as String="ICC_Interact_Verify4"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Serial_Sn", "ID1", "ID1_Equation", "ID1_Value", "Rule_Logic",   _
             "ID2", "ID2_Equation", "ID2_Value", "ID", "ID_Value",   _
             "Is_No_Empty_Less_Equal_1500", "Is_Accept_Empty", "Is_ICXX", "Is_Can_Equal_IC08", "Create_User",   _
             "Create_Time", "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.DateTime", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 10, 2, 100, 10,   _
             10, 2, 100, 10, 200,   _
             1, 1, 10, 10, 10,   _
             -1, 10, 10}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccInteractVerify4DataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Serial_Sn") = New Object
        dataRow("ID1") = New Object
        dataRow("ID1_Equation") = New Object
        dataRow("ID1_Value") = New Object
        dataRow("Rule_Logic") = New Object
        dataRow("ID2") = New Object
        dataRow("ID2_Equation") = New Object
        dataRow("ID2_Value") = New Object
        dataRow("ID") = New Object
        dataRow("ID_Value") = New Object
        dataRow("Is_No_Empty_Less_Equal_1500") = New Object
        dataRow("Is_Accept_Empty") = New Object
        dataRow("Is_ICXX") = New Object
        dataRow("Is_Can_Equal_IC08") = New Object
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
            dt.Columns.Add("ID1_Equation")
            dt.Columns.Add("ID1_Value")
            dt.Columns.Add("Rule_Logic")
            dt.Columns.Add("ID2")
            dt.Columns.Add("ID2_Equation")
            dt.Columns.Add("ID2_Value")
            dt.Columns.Add("ID")
            dt.Columns.Add("ID_Value")
            dt.Columns.Add("Is_No_Empty_Less_Equal_1500")
            dt.Columns.Add("Is_Accept_Empty")
            dt.Columns.Add("Is_ICXX")
            dt.Columns.Add("Is_Can_Equal_IC08")
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
            dt.Columns.Add("ID1_Equation")
            dt.Columns("ID1_Equation").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ID1_Value")
            dt.Columns("ID1_Value").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Rule_Logic")
            dt.Columns("Rule_Logic").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ID2")
            dt.Columns("ID2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ID2_Equation")
            dt.Columns("ID2_Equation").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ID2_Value")
            dt.Columns("ID2_Value").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ID")
            dt.Columns("ID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ID_Value")
            dt.Columns("ID_Value").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_No_Empty_Less_Equal_1500")
            dt.Columns("Is_No_Empty_Less_Equal_1500").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Accept_Empty")
            dt.Columns("Is_Accept_Empty").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_ICXX")
            dt.Columns("Is_ICXX").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Can_Equal_IC08")
            dt.Columns("Is_Can_Equal_IC08").DataType = System.Type.GetType("System.String")
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
            dt.Columns.Add("ID1")
            dt.Columns.Add("ID1_Equation")
            dt.Columns.Add("ID1_Value")
            dt.Columns.Add("Rule_Logic")
            dt.Columns.Add("ID2")
            dt.Columns.Add("ID2_Equation")
            dt.Columns.Add("ID2_Value")
            dt.Columns.Add("ID")
            dt.Columns.Add("ID_Value")
            dt.Columns.Add("Is_No_Empty_Less_Equal_1500")
            dt.Columns.Add("Is_Accept_Empty")
            dt.Columns.Add("Is_ICXX")
            dt.Columns.Add("Is_Can_Equal_IC08")
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

  Class ICCInteractVerify4Pt
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

    Private m_ID1_Equation As String = "ID1_Equation"
    Public ReadOnly Property ID1_Equation() As System.String 
    Get
        Return m_ID1_Equation
    End Get
    End Property

    Private m_ID1_Value As String = "ID1_Value"
    Public ReadOnly Property ID1_Value() As System.String 
    Get
        Return m_ID1_Value
    End Get
    End Property

    Private m_Rule_Logic As String = "Rule_Logic"
    Public ReadOnly Property Rule_Logic() As System.String 
    Get
        Return m_Rule_Logic
    End Get
    End Property

    Private m_ID2 As String = "ID2"
    Public ReadOnly Property ID2() As System.String 
    Get
        Return m_ID2
    End Get
    End Property

    Private m_ID2_Equation As String = "ID2_Equation"
    Public ReadOnly Property ID2_Equation() As System.String 
    Get
        Return m_ID2_Equation
    End Get
    End Property

    Private m_ID2_Value As String = "ID2_Value"
    Public ReadOnly Property ID2_Value() As System.String 
    Get
        Return m_ID2_Value
    End Get
    End Property

    Private m_ID As String = "ID"
    Public ReadOnly Property ID() As System.String 
    Get
        Return m_ID
    End Get
    End Property

    Private m_ID_Value As String = "ID_Value"
    Public ReadOnly Property ID_Value() As System.String 
    Get
        Return m_ID_Value
    End Get
    End Property

    Private m_Is_No_Empty_Less_Equal_1500 As String = "Is_No_Empty_Less_Equal_1500"
    Public ReadOnly Property Is_No_Empty_Less_Equal_1500() As System.String 
    Get
        Return m_Is_No_Empty_Less_Equal_1500
    End Get
    End Property

    Private m_Is_Accept_Empty As String = "Is_Accept_Empty"
    Public ReadOnly Property Is_Accept_Empty() As System.String 
    Get
        Return m_Is_Accept_Empty
    End Get
    End Property

    Private m_Is_ICXX As String = "Is_ICXX"
    Public ReadOnly Property Is_ICXX() As System.String 
    Get
        Return m_Is_ICXX
    End Get
    End Property

    Private m_Is_Can_Equal_IC08 As String = "Is_Can_Equal_IC08"
    Public ReadOnly Property Is_Can_Equal_IC08() As System.String 
    Get
        Return m_Is_Can_Equal_IC08
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
