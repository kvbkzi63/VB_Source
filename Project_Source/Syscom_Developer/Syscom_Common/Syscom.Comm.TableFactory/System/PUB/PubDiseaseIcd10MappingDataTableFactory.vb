Imports System.Data.SqlClient
Public Class PubDiseaseIcd10MappingDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/6/28 上午 09:46:52
    Public Shared ReadOnly tableName As String = "PUB_Disease_ICD10_Mapping"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Disease_Type_Id", "ICD_Code", "ICD10_Code", "Mapping_Status", "Create_User", _
             "Create_Time", "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.DateTime", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             5, 10, 10, 10, 10, _
             -1, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub example()
        Dim dataSet As DataSet = New DataSet
        Dim dataTable As DataTable = PubDiseaseIcd10MappingDataTableFactory.getDataTableWithSchema
        Dim dataRow As DataRow = dataTable.NewRow()
        '使用自己的資料來源取代 New Object 
        dataRow("Disease_Type_Id") = New Object
        dataRow("ICD_Code") = New Object
        dataRow("ICD10_Code") = New Object
        dataRow("Mapping_Status") = New Object
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
            dt.Columns.Add("Disease_Type_Id")
            dt.Columns.Add("ICD_Code")
            dt.Columns.Add("ICD10_Code")
            dt.Columns.Add("Mapping_Status")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(2) As DataColumn
            pkColArray(0) = dt.Columns("Disease_Type_Id")
            pkColArray(1) = dt.Columns("ICD_Code")
            pkColArray(2) = dt.Columns("ICD10_Code")
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
            dt.Columns.Add("Disease_Type_Id")
            dt.Columns("Disease_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ICD_Code")
            dt.Columns("ICD_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ICD10_Code")
            dt.Columns("ICD10_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Mapping_Status")
            dt.Columns("Mapping_Status").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(2) As DataColumn
            pkColArray(0) = dt.Columns("Disease_Type_Id")
            pkColArray(1) = dt.Columns("ICD_Code")
            pkColArray(2) = dt.Columns("ICD10_Code")
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
            dt.Columns.Add("Disease_Type_Id")
            dt.Columns.Add("ICD_Code")
            dt.Columns.Add("ICD10_Code")
            dt.Columns.Add("Mapping_Status")
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

    Class PUBDiseaseICD10MappingPt
        Private m_Disease_Type_Id As String = "Disease_Type_Id"
        Public ReadOnly Property Disease_Type_Id() As System.String
            Get
                Return m_Disease_Type_Id
            End Get
        End Property

        Private m_ICD_Code As String = "ICD_Code"
        Public ReadOnly Property ICD_Code() As System.String
            Get
                Return m_ICD_Code
            End Get
        End Property

        Private m_ICD10_Code As String = "ICD10_Code"
        Public ReadOnly Property ICD10_Code() As System.String
            Get
                Return m_ICD10_Code
            End Get
        End Property

        Private m_Mapping_Status As String = "Mapping_Status"
        Public ReadOnly Property Mapping_Status() As System.String
            Get
                Return m_Mapping_Status
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
