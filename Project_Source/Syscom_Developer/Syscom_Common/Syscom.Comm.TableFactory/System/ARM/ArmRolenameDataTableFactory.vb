Imports System.Data.SqlClient
Public Class ArmRolenameDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/7/5 上午 10:36:13
    Public Shared ReadOnly tableName as String="ARM_RoleName"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "roleID", "roleName", "isValid", "opd_flag", "eis_flag",   _
             "pcs_flag", "creator_no", "create_datetime", "operator_no", "update_datetime",   _
             "IsAgent", "roleMember", "del_Flag"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime",   _
             "System.String", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             50, 50, 1, 1, 1,   _
             1, 10, -1, 10, -1,   _
             1, 50, 1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = ArmRolenameDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("roleID") = New Object
        dataRow("roleName") = New Object
        dataRow("isValid") = New Object
        dataRow("opd_flag") = New Object
        dataRow("eis_flag") = New Object
        dataRow("pcs_flag") = New Object
        dataRow("creator_no") = New Object
        dataRow("create_datetime") = New Object
        dataRow("operator_no") = New Object
        dataRow("update_datetime") = New Object
        dataRow("IsAgent") = New Object
        dataRow("roleMember") = New Object
        dataRow("del_Flag") = New Object
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
            dt.Columns.Add("roleID")
            dt.Columns.Add("roleName")
            dt.Columns.Add("isValid")
            dt.Columns.Add("opd_flag")
            dt.Columns.Add("eis_flag")
            dt.Columns.Add("pcs_flag")
            dt.Columns.Add("creator_no")
            dt.Columns.Add("create_datetime")
            dt.Columns.Add("operator_no")
            dt.Columns.Add("update_datetime")
            dt.Columns.Add("IsAgent")
            dt.Columns.Add("roleMember")
            dt.Columns.Add("del_Flag")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("roleID")
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
            dt.Columns.Add("roleID")
            dt.Columns("roleID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("roleName")
            dt.Columns("roleName").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("isValid")
            dt.Columns("isValid").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("opd_flag")
            dt.Columns("opd_flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("eis_flag")
            dt.Columns("eis_flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("pcs_flag")
            dt.Columns("pcs_flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("creator_no")
            dt.Columns("creator_no").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("create_datetime")
            dt.Columns("create_datetime").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("operator_no")
            dt.Columns("operator_no").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("update_datetime")
            dt.Columns("update_datetime").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("IsAgent")
            dt.Columns("IsAgent").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("roleMember")
            dt.Columns("roleMember").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("del_Flag")
            dt.Columns("del_Flag").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("roleID")
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
            dt.Columns.Add("roleID")
            dt.Columns.Add("roleName")
            dt.Columns.Add("isValid")
            dt.Columns.Add("opd_flag")
            dt.Columns.Add("eis_flag")
            dt.Columns.Add("pcs_flag")
            dt.Columns.Add("creator_no")
            dt.Columns.Add("create_datetime")
            dt.Columns.Add("operator_no")
            dt.Columns.Add("update_datetime")
            dt.Columns.Add("IsAgent")
            dt.Columns.Add("roleMember")
            dt.Columns.Add("del_Flag")
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

  Class ARMRoleNamePt
    Private m_roleID As String = "roleID"
    Public ReadOnly Property roleID() As System.String 
    Get
        Return m_roleID
    End Get
    End Property

    Private m_roleName As String = "roleName"
    Public ReadOnly Property roleName() As System.String 
    Get
        Return m_roleName
    End Get
    End Property

    Private m_isValid As String = "isValid"
    Public ReadOnly Property isValid() As System.String 
    Get
        Return m_isValid
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

    Private m_creator_no As String = "creator_no"
    Public ReadOnly Property creator_no() As System.String 
    Get
        Return m_creator_no
    End Get
    End Property

    Private m_create_datetime As String = "create_datetime"
    Public ReadOnly Property create_datetime() As System.String 
    Get
        Return m_create_datetime
    End Get
    End Property

    Private m_operator_no As String = "operator_no"
    Public ReadOnly Property operator_no() As System.String 
    Get
        Return m_operator_no
    End Get
    End Property

    Private m_update_datetime As String = "update_datetime"
    Public ReadOnly Property update_datetime() As System.String 
    Get
        Return m_update_datetime
    End Get
    End Property

    Private m_IsAgent As String = "IsAgent"
    Public ReadOnly Property IsAgent() As System.String 
    Get
        Return m_IsAgent
    End Get
    End Property

    Private m_roleMember As String = "roleMember"
    Public ReadOnly Property roleMember() As System.String 
    Get
        Return m_roleMember
    End Get
    End Property

    Private m_del_Flag As String = "del_Flag"
    Public ReadOnly Property del_Flag() As System.String 
    Get
        Return m_del_Flag
    End Get
    End Property

  End Class

End Class
