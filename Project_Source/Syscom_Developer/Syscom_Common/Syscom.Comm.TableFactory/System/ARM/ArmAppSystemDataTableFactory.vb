Imports System.Data.SqlClient
Public Class ArmAppSystemDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/7/5 上午 10:36:13
    Public Shared ReadOnly tableName as String="ARM_App_System"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "app_system_no", "app_system_name", "app_display_order", "app_flag_no", "app_creator_no",   _
             "app_create_datetime", "app_operator_no", "app_update_datetime"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.Int32", "System.String", "System.String",   _
             "System.DateTime", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 40, -1, 1, 10,   _
             -1, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = ArmAppSystemDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("app_system_no") = New Object
        dataRow("app_system_name") = New Object
        dataRow("app_display_order") = New Object
        dataRow("app_flag_no") = New Object
        dataRow("app_creator_no") = New Object
        dataRow("app_create_datetime") = New Object
        dataRow("app_operator_no") = New Object
        dataRow("app_update_datetime") = New Object
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
            dt.Columns.Add("app_system_no")
            dt.Columns.Add("app_system_name")
            dt.Columns.Add("app_display_order")
            dt.Columns.Add("app_flag_no")
            dt.Columns.Add("app_creator_no")
            dt.Columns.Add("app_create_datetime")
            dt.Columns.Add("app_operator_no")
            dt.Columns.Add("app_update_datetime")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("app_system_no")
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
            dt.Columns.Add("app_system_no")
            dt.Columns("app_system_no").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("app_system_name")
            dt.Columns("app_system_name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("app_display_order")
            dt.Columns("app_display_order").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("app_flag_no")
            dt.Columns("app_flag_no").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("app_creator_no")
            dt.Columns("app_creator_no").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("app_create_datetime")
            dt.Columns("app_create_datetime").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("app_operator_no")
            dt.Columns("app_operator_no").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("app_update_datetime")
            dt.Columns("app_update_datetime").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("app_system_no")
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
            dt.Columns.Add("app_system_no")
            dt.Columns.Add("app_system_name")
            dt.Columns.Add("app_display_order")
            dt.Columns.Add("app_flag_no")
            dt.Columns.Add("app_creator_no")
            dt.Columns.Add("app_create_datetime")
            dt.Columns.Add("app_operator_no")
            dt.Columns.Add("app_update_datetime")
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

  Class ARMAppSystemPt
    Private m_app_system_no As String = "app_system_no"
    Public ReadOnly Property app_system_no() As System.String 
    Get
        Return m_app_system_no
    End Get
    End Property

    Private m_app_system_name As String = "app_system_name"
    Public ReadOnly Property app_system_name() As System.String 
    Get
        Return m_app_system_name
    End Get
    End Property

    Private m_app_display_order As String = "app_display_order"
    Public ReadOnly Property app_display_order() As System.String 
    Get
        Return m_app_display_order
    End Get
    End Property

    Private m_app_flag_no As String = "app_flag_no"
    Public ReadOnly Property app_flag_no() As System.String 
    Get
        Return m_app_flag_no
    End Get
    End Property

    Private m_app_creator_no As String = "app_creator_no"
    Public ReadOnly Property app_creator_no() As System.String 
    Get
        Return m_app_creator_no
    End Get
    End Property

    Private m_app_create_datetime As String = "app_create_datetime"
    Public ReadOnly Property app_create_datetime() As System.String 
    Get
        Return m_app_create_datetime
    End Get
    End Property

    Private m_app_operator_no As String = "app_operator_no"
    Public ReadOnly Property app_operator_no() As System.String 
    Get
        Return m_app_operator_no
    End Get
    End Property

    Private m_app_update_datetime As String = "app_update_datetime"
    Public ReadOnly Property app_update_datetime() As System.String 
    Get
        Return m_app_update_datetime
    End Get
    End Property

  End Class

End Class
