Imports System.Data.SqlClient
Public Class ArmRolerightsDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/7/5 上午 10:36:13
    Public Shared ReadOnly tableName as String="ARM_Rolerights"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "rrs_role_id", "rrs_rights_id", "rrs_rights_type", "opd_flag", "eis_flag",   _
             "pcs_flag", "btnInsert_flag", "btnUpdate_flag", "btnDelete_flag", "btnQuery_flag",   _
             "btnSave_flag", "btnPrint_flag"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             50, 50, 3, 1, 1,   _
             1, 1, 1, 1, 1,   _
             1, 1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = ArmRolerightsDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("rrs_role_id") = New Object
        dataRow("rrs_rights_id") = New Object
        dataRow("rrs_rights_type") = New Object
        dataRow("opd_flag") = New Object
        dataRow("eis_flag") = New Object
        dataRow("pcs_flag") = New Object
        dataRow("btnInsert_flag") = New Object
        dataRow("btnUpdate_flag") = New Object
        dataRow("btnDelete_flag") = New Object
        dataRow("btnQuery_flag") = New Object
        dataRow("btnSave_flag") = New Object
        dataRow("btnPrint_flag") = New Object
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
            dt.Columns.Add("rrs_role_id")
            dt.Columns.Add("rrs_rights_id")
            dt.Columns.Add("rrs_rights_type")
            dt.Columns.Add("opd_flag")
            dt.Columns.Add("eis_flag")
            dt.Columns.Add("pcs_flag")
            dt.Columns.Add("btnInsert_flag")
            dt.Columns.Add("btnUpdate_flag")
            dt.Columns.Add("btnDelete_flag")
            dt.Columns.Add("btnQuery_flag")
            dt.Columns.Add("btnSave_flag")
            dt.Columns.Add("btnPrint_flag")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("rrs_role_id")
            pkColArray(1) = dt.Columns("rrs_rights_id")
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
            dt.Columns.Add("rrs_role_id")
            dt.Columns("rrs_role_id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("rrs_rights_id")
            dt.Columns("rrs_rights_id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("rrs_rights_type")
            dt.Columns("rrs_rights_type").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("opd_flag")
            dt.Columns("opd_flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("eis_flag")
            dt.Columns("eis_flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("pcs_flag")
            dt.Columns("pcs_flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("btnInsert_flag")
            dt.Columns("btnInsert_flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("btnUpdate_flag")
            dt.Columns("btnUpdate_flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("btnDelete_flag")
            dt.Columns("btnDelete_flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("btnQuery_flag")
            dt.Columns("btnQuery_flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("btnSave_flag")
            dt.Columns("btnSave_flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("btnPrint_flag")
            dt.Columns("btnPrint_flag").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("rrs_role_id")
            pkColArray(1) = dt.Columns("rrs_rights_id")
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
            dt.Columns.Add("rrs_role_id")
            dt.Columns.Add("rrs_rights_id")
            dt.Columns.Add("rrs_rights_type")
            dt.Columns.Add("opd_flag")
            dt.Columns.Add("eis_flag")
            dt.Columns.Add("pcs_flag")
            dt.Columns.Add("btnInsert_flag")
            dt.Columns.Add("btnUpdate_flag")
            dt.Columns.Add("btnDelete_flag")
            dt.Columns.Add("btnQuery_flag")
            dt.Columns.Add("btnSave_flag")
            dt.Columns.Add("btnPrint_flag")
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

  Class ARMRolerightsPt
    Private m_rrs_role_id As String = "rrs_role_id"
    Public ReadOnly Property rrs_role_id() As System.String 
    Get
        Return m_rrs_role_id
    End Get
    End Property

    Private m_rrs_rights_id As String = "rrs_rights_id"
    Public ReadOnly Property rrs_rights_id() As System.String 
    Get
        Return m_rrs_rights_id
    End Get
    End Property

    Private m_rrs_rights_type As String = "rrs_rights_type"
    Public ReadOnly Property rrs_rights_type() As System.String 
    Get
        Return m_rrs_rights_type
    End Get
    End Property

    Private m_opd_flag As String = "opd_flag"
    Public ReadOnly Property opd_flag() As System.String 
    Get
        Return m_opd_flag
    End Get
    End Property

    Private m_eis_flag As String = "eis_flag"
    Public ReadOnly Property eis_flag() As System.String 
    Get
        Return m_eis_flag
    End Get
    End Property

    Private m_pcs_flag As String = "pcs_flag"
    Public ReadOnly Property pcs_flag() As System.String 
    Get
        Return m_pcs_flag
    End Get
    End Property

    Private m_btnInsert_flag As String = "btnInsert_flag"
    Public ReadOnly Property btnInsert_flag() As System.String 
    Get
        Return m_btnInsert_flag
    End Get
    End Property

    Private m_btnUpdate_flag As String = "btnUpdate_flag"
    Public ReadOnly Property btnUpdate_flag() As System.String 
    Get
        Return m_btnUpdate_flag
    End Get
    End Property

    Private m_btnDelete_flag As String = "btnDelete_flag"
    Public ReadOnly Property btnDelete_flag() As System.String 
    Get
        Return m_btnDelete_flag
    End Get
    End Property

    Private m_btnQuery_flag As String = "btnQuery_flag"
    Public ReadOnly Property btnQuery_flag() As System.String 
    Get
        Return m_btnQuery_flag
    End Get
    End Property

    Private m_btnSave_flag As String = "btnSave_flag"
    Public ReadOnly Property btnSave_flag() As System.String 
    Get
        Return m_btnSave_flag
    End Get
    End Property

    Private m_btnPrint_flag As String = "btnPrint_flag"
    Public ReadOnly Property btnPrint_flag() As System.String 
    Get
        Return m_btnPrint_flag
    End Get
    End Property

  End Class

End Class
