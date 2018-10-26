Imports System.Data.SqlClient
Public Class PubCureControlDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:47
    Public Shared ReadOnly tableName as String="PUB_Cure_Control"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Cure_Type_Id", "Time_Control_Id", "Control_Value", "Max_Cnt", "Is_Reg_Fee",   _
             "Is_Fee_Check"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.Int32", "System.Int32", "System.String",   _
             "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             5, 5, -1, -1, 1,   _
             1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubCureControlDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Cure_Type_Id") = New Object
        dataRow("Time_Control_Id") = New Object
        dataRow("Control_Value") = New Object
        dataRow("Max_Cnt") = New Object
        dataRow("Is_Reg_Fee") = New Object
        dataRow("Is_Fee_Check") = New Object
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
            dt.Columns.Add("Cure_Type_Id")
            dt.Columns.Add("Time_Control_Id")
            dt.Columns.Add("Control_Value")
            dt.Columns.Add("Max_Cnt")
            dt.Columns.Add("Is_Reg_Fee")
            dt.Columns.Add("Is_Fee_Check")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Cure_Type_Id")
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
            dt.Columns.Add("Cure_Type_Id")
            dt.Columns("Cure_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Time_Control_Id")
            dt.Columns("Time_Control_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Control_Value")
            dt.Columns("Control_Value").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Max_Cnt")
            dt.Columns("Max_Cnt").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Is_Reg_Fee")
            dt.Columns("Is_Reg_Fee").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Fee_Check")
            dt.Columns("Is_Fee_Check").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Cure_Type_Id")
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
            dt.Columns.Add("Cure_Type_Id")
            dt.Columns.Add("Time_Control_Id")
            dt.Columns.Add("Control_Value")
            dt.Columns.Add("Max_Cnt")
            dt.Columns.Add("Is_Reg_Fee")
            dt.Columns.Add("Is_Fee_Check")
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

  Class PUBCureControlPt
    Private m_Cure_Type_Id As String = "Cure_Type_Id"
    Public ReadOnly Property Cure_Type_Id() As System.String 
    Get
        Return m_Cure_Type_Id
    End Get
    End Property

    Private m_Time_Control_Id As String = "Time_Control_Id"
    Public ReadOnly Property Time_Control_Id() As System.String 
    Get
        Return m_Time_Control_Id
    End Get
    End Property

    Private m_Control_Value As String = "Control_Value"
    Public ReadOnly Property Control_Value() As System.String 
    Get
        Return m_Control_Value
    End Get
    End Property

    Private m_Max_Cnt As String = "Max_Cnt"
    Public ReadOnly Property Max_Cnt() As System.String 
    Get
        Return m_Max_Cnt
    End Get
    End Property

    Private m_Is_Reg_Fee As String = "Is_Reg_Fee"
    Public ReadOnly Property Is_Reg_Fee() As System.String 
    Get
        Return m_Is_Reg_Fee
    End Get
    End Property

    Private m_Is_Fee_Check As String = "Is_Fee_Check"
    Public ReadOnly Property Is_Fee_Check() As System.String 
    Get
        Return m_Is_Fee_Check
    End Get
    End Property

  End Class

End Class
