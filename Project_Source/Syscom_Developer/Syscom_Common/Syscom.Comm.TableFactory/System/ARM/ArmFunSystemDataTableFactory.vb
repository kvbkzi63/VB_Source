Imports System.Data.SqlClient
Public Class ArmFunSystemDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/11/15 上午 10:09:59
    Public Shared ReadOnly tableName as String="ARM_Fun_System"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "fun_function_no", "fun_function_name", "fun_task_no", "fun_content", "fun_special_flag",   _
             "fun_display_order", "fun_flag_no", "fun_creator_no", "fun_create_datetime", "fun_operator_no",   _
             "fun_update_datetime", "Fun_System_Memo"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.Int32", "System.String", "System.String", "System.DateTime", "System.String",   _
             "System.DateTime", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             40, 60, 50, 100, 1,   _
             -1, 1, 10, -1, 10,   _
             -1, 50}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = ArmFunSystemDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("fun_function_no") = New Object
        dataRow("fun_function_name") = New Object
        dataRow("fun_task_no") = New Object
        dataRow("fun_content") = New Object
        dataRow("fun_special_flag") = New Object
        dataRow("fun_display_order") = New Object
        dataRow("fun_flag_no") = New Object
        dataRow("fun_creator_no") = New Object
        dataRow("fun_create_datetime") = New Object
        dataRow("fun_operator_no") = New Object
        dataRow("fun_update_datetime") = New Object
        dataRow("Fun_System_Memo") = New Object
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
            dt.Columns.Add("fun_function_no")
            dt.Columns.Add("fun_function_name")
            dt.Columns.Add("fun_task_no")
            dt.Columns.Add("fun_content")
            dt.Columns.Add("fun_special_flag")
            dt.Columns.Add("fun_display_order")
            dt.Columns.Add("fun_flag_no")
            dt.Columns.Add("fun_creator_no")
            dt.Columns.Add("fun_create_datetime")
            dt.Columns.Add("fun_operator_no")
            dt.Columns.Add("fun_update_datetime")
            dt.Columns.Add("Fun_System_Memo")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("fun_function_no")
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
            dt.Columns.Add("fun_function_no")
            dt.Columns("fun_function_no").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("fun_function_name")
            dt.Columns("fun_function_name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("fun_task_no")
            dt.Columns("fun_task_no").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("fun_content")
            dt.Columns("fun_content").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("fun_special_flag")
            dt.Columns("fun_special_flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("fun_display_order")
            dt.Columns("fun_display_order").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("fun_flag_no")
            dt.Columns("fun_flag_no").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("fun_creator_no")
            dt.Columns("fun_creator_no").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("fun_create_datetime")
            dt.Columns("fun_create_datetime").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("fun_operator_no")
            dt.Columns("fun_operator_no").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("fun_update_datetime")
            dt.Columns("fun_update_datetime").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Fun_System_Memo")
            dt.Columns("Fun_System_Memo").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("fun_function_no")
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
            dt.Columns.Add("fun_function_no")
            dt.Columns.Add("fun_function_name")
            dt.Columns.Add("fun_task_no")
            dt.Columns.Add("fun_content")
            dt.Columns.Add("fun_special_flag")
            dt.Columns.Add("fun_display_order")
            dt.Columns.Add("fun_flag_no")
            dt.Columns.Add("fun_creator_no")
            dt.Columns.Add("fun_create_datetime")
            dt.Columns.Add("fun_operator_no")
            dt.Columns.Add("fun_update_datetime")
            dt.Columns.Add("Fun_System_Memo")
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

  Class ARMFunSystemPt
    Private m_fun_function_no As String = "fun_function_no"
    Public ReadOnly Property fun_function_no() As System.String 
    Get
        Return m_fun_function_no
    End Get
    End Property

    Private m_fun_function_name As String = "fun_function_name"
    Public ReadOnly Property fun_function_name() As System.String 
    Get
        Return m_fun_function_name
    End Get
    End Property

    Private m_fun_task_no As String = "fun_task_no"
    Public ReadOnly Property fun_task_no() As System.String 
    Get
        Return m_fun_task_no
    End Get
    End Property

    Private m_fun_content As String = "fun_content"
    Public ReadOnly Property fun_content() As System.String 
    Get
        Return m_fun_content
    End Get
    End Property

    Private m_fun_special_flag As String = "fun_special_flag"
    Public ReadOnly Property fun_special_flag() As System.String 
    Get
        Return m_fun_special_flag
    End Get
    End Property

    Private m_fun_display_order As String = "fun_display_order"
    Public ReadOnly Property fun_display_order() As System.String 
    Get
        Return m_fun_display_order
    End Get
    End Property

    Private m_fun_flag_no As String = "fun_flag_no"
    Public ReadOnly Property fun_flag_no() As System.String 
    Get
        Return m_fun_flag_no
    End Get
    End Property

    Private m_fun_creator_no As String = "fun_creator_no"
    Public ReadOnly Property fun_creator_no() As System.String 
    Get
        Return m_fun_creator_no
    End Get
    End Property

    Private m_fun_create_datetime As String = "fun_create_datetime"
    Public ReadOnly Property fun_create_datetime() As System.String 
    Get
        Return m_fun_create_datetime
    End Get
    End Property

    Private m_fun_operator_no As String = "fun_operator_no"
    Public ReadOnly Property fun_operator_no() As System.String 
    Get
        Return m_fun_operator_no
    End Get
    End Property

    Private m_fun_update_datetime As String = "fun_update_datetime"
    Public ReadOnly Property fun_update_datetime() As System.String 
    Get
        Return m_fun_update_datetime
    End Get
    End Property

    Private m_Fun_System_Memo As String = "Fun_System_Memo"
    Public ReadOnly Property Fun_System_Memo() As System.String 
    Get
        Return m_Fun_System_Memo
    End Get
    End Property

  End Class
  Class DBColumnName 
    Private Shared ReadOnly m_fun_function_no As String = "fun_function_no"
    Public Shared ReadOnly Property fun_function_no() As System.String 
    Get
        Return m_fun_function_no
    End Get
    End Property

    Private Shared ReadOnly m_fun_function_name As String = "fun_function_name"
    Public Shared ReadOnly Property fun_function_name() As System.String 
    Get
        Return m_fun_function_name
    End Get
    End Property

    Private Shared ReadOnly m_fun_task_no As String = "fun_task_no"
    Public Shared ReadOnly Property fun_task_no() As System.String 
    Get
        Return m_fun_task_no
    End Get
    End Property

    Private Shared ReadOnly m_fun_content As String = "fun_content"
    Public Shared ReadOnly Property fun_content() As System.String 
    Get
        Return m_fun_content
    End Get
    End Property

    Private Shared ReadOnly m_fun_special_flag As String = "fun_special_flag"
    Public Shared ReadOnly Property fun_special_flag() As System.String 
    Get
        Return m_fun_special_flag
    End Get
    End Property

    Private Shared ReadOnly m_fun_display_order As String = "fun_display_order"
    Public Shared ReadOnly Property fun_display_order() As System.String 
    Get
        Return m_fun_display_order
    End Get
    End Property

    Private Shared ReadOnly m_fun_flag_no As String = "fun_flag_no"
    Public Shared ReadOnly Property fun_flag_no() As System.String 
    Get
        Return m_fun_flag_no
    End Get
    End Property

    Private Shared ReadOnly m_fun_creator_no As String = "fun_creator_no"
    Public Shared ReadOnly Property fun_creator_no() As System.String 
    Get
        Return m_fun_creator_no
    End Get
    End Property

    Private Shared ReadOnly m_fun_create_datetime As String = "fun_create_datetime"
    Public Shared ReadOnly Property fun_create_datetime() As System.String 
    Get
        Return m_fun_create_datetime
    End Get
    End Property

    Private Shared ReadOnly m_fun_operator_no As String = "fun_operator_no"
    Public Shared ReadOnly Property fun_operator_no() As System.String 
    Get
        Return m_fun_operator_no
    End Get
    End Property

    Private Shared ReadOnly m_fun_update_datetime As String = "fun_update_datetime"
    Public Shared ReadOnly Property fun_update_datetime() As System.String 
    Get
        Return m_fun_update_datetime
    End Get
    End Property

    Private Shared ReadOnly m_Fun_System_Memo As String = "Fun_System_Memo"
    Public Shared ReadOnly Property Fun_System_Memo() As System.String 
    Get
        Return m_Fun_System_Memo
    End Get
    End Property

  End Class

End Class
