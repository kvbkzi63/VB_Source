Imports System.Data.SqlClient
Public Class JobSaDbmodifiedRecordDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/7/28 下午 08:28:01
    Public Shared ReadOnly tableName as String="JOB_SA_DBModified_Record"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() {
             "Project_ID", "Seq_No", "DBA_Employee_Code", "DB_Name", "Table_Name",
             "Table_Ch_Name", "Index", "Restrict", "Modified_Classify", "Sql_Script",
             "Is_Modified", "Reject_Reason", "Modified_FID", "Create_User", "Create_Time",
             "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() {
             "System.String", "System.Int32", "System.String", "System.String", "System.String",
             "System.String", "System.String", "System.String", "System.String", "System.String",
             "System.String", "System.String", "System.String", "System.String", "System.DateTime",
             "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() {
             10, -1, 10, 50, 100,
             100, 200, 20, 20, 4000,
             1, 500, 100, 20, -1,
             20, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub example()
        Dim dataSet As DataSet = New DataSet
        Dim dataTable As DataTable = JobSaDbmodifiedRecordDataTableFactory.getDataTableWithSchema
        Dim dataRow As DataRow = dataTable.NewRow()
        '使用自己的資料來源取代 New Object 
        dataRow("Project_ID") = New Object
        dataRow("Seq_No") = New Object
        dataRow("DBA_Employee_Code") = New Object
        dataRow("DB_Name") = New Object
        dataRow("Table_Name") = New Object
        dataRow("Table_Ch_Name") = New Object
        dataRow("Index") = New Object
        dataRow("Restrict") = New Object
        dataRow("Modified_Classify") = New Object
        dataRow("Sql_Script") = New Object
        dataRow("Is_Modified") = New Object
        dataRow("Reject_Reason") = New Object
        dataRow("Modified_FID") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataTable.Rows.Add(dataRow)
        dataSet.Tables.Add(dataTable)
    End Sub

    ''' <summary>
    '''取得資料庫表格的 DataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTable() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName)
            dt.Columns.Add("Project_ID")
            dt.Columns.Add("Seq_No")
            dt.Columns.Add("DBA_Employee_Code")
            dt.Columns.Add("DB_Name")
            dt.Columns.Add("Table_Name")
            dt.Columns.Add("Table_Ch_Name")
            dt.Columns.Add("Index")
            dt.Columns.Add("Restrict")
            dt.Columns.Add("Modified_Classify")
            dt.Columns.Add("Sql_Script")
            dt.Columns.Add("Is_Modified")
            dt.Columns.Add("Reject_Reason")
            dt.Columns.Add("Modified_FID")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(1) As DataColumn
            pkColArray(0) = dt.Columns("Project_ID")
            pkColArray(1) = dt.Columns("Seq_No")
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
            dt.Columns.Add("Project_ID")
            dt.Columns("Project_ID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Seq_No")
            dt.Columns("Seq_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("DBA_Employee_Code")
            dt.Columns("DBA_Employee_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("DB_Name")
            dt.Columns("DB_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Table_Name")
            dt.Columns("Table_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Table_Ch_Name")
            dt.Columns("Table_Ch_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Index")
            dt.Columns("Index").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Restrict")
            dt.Columns("Restrict").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Classify")
            dt.Columns("Modified_Classify").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sql_Script")
            dt.Columns("Sql_Script").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Modified")
            dt.Columns("Is_Modified").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Reject_Reason")
            dt.Columns("Reject_Reason").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_FID")
            dt.Columns("Modified_FID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(1) As DataColumn
            pkColArray(0) = dt.Columns("Project_ID")
            pkColArray(1) = dt.Columns("Seq_No")
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
            dt.Columns.Add("Project_ID")
            dt.Columns.Add("Seq_No")
            dt.Columns.Add("DBA_Employee_Code")
            dt.Columns.Add("DB_Name")
            dt.Columns.Add("Table_Name")
            dt.Columns.Add("Table_Ch_Name")
            dt.Columns.Add("Index")
            dt.Columns.Add("Restrict")
            dt.Columns.Add("Modified_Classify")
            dt.Columns.Add("Sql_Script")
            dt.Columns.Add("Is_Modified")
            dt.Columns.Add("Reject_Reason")
            dt.Columns.Add("Modified_FID")
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

            Dim dt As DataTable = getDataTable()

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

            Dim dt As DataTable = getDataTableWithSchema()

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

            Dim dt As DataTable = getDataTableWithNoPK()

            ds.Tables.Add(dt)

            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Class JOBSADBModifiedRecordPt
        Private m_Project_ID As String = "Project_ID"
        Public ReadOnly Property Project_ID() As System.String
            Get
                Return m_Project_ID
            End Get
        End Property

        Private m_Seq_No As String = "Seq_No"
        Public ReadOnly Property Seq_No() As System.String
            Get
                Return m_Seq_No
            End Get
        End Property

        Private m_DBA_Employee_Code As String = "DBA_Employee_Code"
        Public ReadOnly Property DBA_Employee_Code() As System.String
            Get
                Return m_DBA_Employee_Code
            End Get
        End Property

        Private m_DB_Name As String = "DB_Name"
        Public ReadOnly Property DB_Name() As System.String
            Get
                Return m_DB_Name
            End Get
        End Property

        Private m_Table_Name As String = "Table_Name"
        Public ReadOnly Property Table_Name() As System.String
            Get
                Return m_Table_Name
            End Get
        End Property

        Private m_Table_Ch_Name As String = "Table_Ch_Name"
        Public ReadOnly Property Table_Ch_Name() As System.String
            Get
                Return m_Table_Ch_Name
            End Get
        End Property

        Private m_Index As String = "Index"
        Public ReadOnly Property Index() As System.String
            Get
                Return m_Index
            End Get
        End Property

        Private m_Restrict As String = "Restrict"
        Public ReadOnly Property Restrict() As System.String
            Get
                Return m_Restrict
            End Get
        End Property

        Private m_Modified_Classify As String = "Modified_Classify"
        Public ReadOnly Property Modified_Classify() As System.String
            Get
                Return m_Modified_Classify
            End Get
    End Property

    Private m_Sql_Script As String = "Sql_Script"
    Public ReadOnly Property Sql_Script() As System.String 
    Get
        Return m_Sql_Script
    End Get
    End Property

    Private m_Is_Modified As String = "Is_Modified"
    Public ReadOnly Property Is_Modified() As System.String 
    Get
        Return m_Is_Modified
    End Get
    End Property

    Private m_Reject_Reason As String = "Reject_Reason"
    Public ReadOnly Property Reject_Reason() As System.String 
    Get
        Return m_Reject_Reason
    End Get
    End Property

    Private m_Modified_FID As String = "Modified_FID"
    Public ReadOnly Property Modified_FID() As System.String 
    Get
        Return m_Modified_FID
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
