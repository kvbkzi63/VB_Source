Imports System.Data.SqlClient
Public Class PubDeptSectDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/11/11 上午 09:34:04
    Public Shared ReadOnly tableName As String = "PUB_Dept_Sect"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Dept_Code", "Section_Id", "Dept_Sect_Name", "Dept_Sect_En_Name", "Dept_Sect_Alias_Name", _
             "Dept_Sect_Alias_En_Name", "Dc", "Create_User", "Create_Time", "Modified_User", _
             "Modified_Time", "Health_Opd_Dept_Code", "Health_Ipd_Dept_Code", "Dept_Sect_Kind_Id"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.DateTime", "System.String", _
             "System.DateTime", "System.String", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             6, 5, 100, 100, 100, _
             100, 1, 10, -1, 10, _
             -1, 6, 6, 5}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub example()
        Dim dataSet As DataSet = New DataSet
        Dim dataTable As DataTable = PubDeptSectDataTableFactory.getDataTableWithSchema
        Dim dataRow As DataRow = dataTable.NewRow()
        '使用自己的資料來源取代 New Object 
        dataRow("Dept_Code") = New Object
        dataRow("Section_Id") = New Object
        dataRow("Dept_Sect_Name") = New Object
        dataRow("Dept_Sect_En_Name") = New Object
        dataRow("Dept_Sect_Alias_Name") = New Object
        dataRow("Dept_Sect_Alias_En_Name") = New Object
        dataRow("Dc") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Health_Opd_Dept_Code") = New Object
        dataRow("Health_Ipd_Dept_Code") = New Object
        dataRow("Dept_Sect_Kind_Id") = New Object
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
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Section_Id")
            dt.Columns.Add("Dept_Sect_Name")
            dt.Columns.Add("Dept_Sect_En_Name")
            dt.Columns.Add("Dept_Sect_Alias_Name")
            dt.Columns.Add("Dept_Sect_Alias_En_Name")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Health_Opd_Dept_Code")
            dt.Columns.Add("Health_Ipd_Dept_Code")
            dt.Columns.Add("Dept_Sect_Kind_Id")
            Dim pkColArray(1) As DataColumn
            pkColArray(0) = dt.Columns("Dept_Code")
            pkColArray(1) = dt.Columns("Section_Id")
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
            dt.Columns.Add("Dept_Code")
            dt.Columns("Dept_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Section_Id")
            dt.Columns("Section_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dept_Sect_Name")
            dt.Columns("Dept_Sect_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dept_Sect_En_Name")
            dt.Columns("Dept_Sect_En_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dept_Sect_Alias_Name")
            dt.Columns("Dept_Sect_Alias_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dept_Sect_Alias_En_Name")
            dt.Columns("Dept_Sect_Alias_En_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dc")
            dt.Columns("Dc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Health_Opd_Dept_Code")
            dt.Columns("Health_Opd_Dept_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Health_Ipd_Dept_Code")
            dt.Columns("Health_Ipd_Dept_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dept_Sect_Kind_Id")
            dt.Columns("Dept_Sect_Kind_Id").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn
            pkColArray(0) = dt.Columns("Dept_Code")
            pkColArray(1) = dt.Columns("Section_Id")
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
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Section_Id")
            dt.Columns.Add("Dept_Sect_Name")
            dt.Columns.Add("Dept_Sect_En_Name")
            dt.Columns.Add("Dept_Sect_Alias_Name")
            dt.Columns.Add("Dept_Sect_Alias_En_Name")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Health_Opd_Dept_Code")
            dt.Columns.Add("Health_Ipd_Dept_Code")
            dt.Columns.Add("Dept_Sect_Kind_Id")
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

    Class PUBDeptSectPt
        Private m_Dept_Code As String = "Dept_Code"
        Public ReadOnly Property Dept_Code() As System.String
            Get
                Return m_Dept_Code
            End Get
        End Property

        Private m_Section_Id As String = "Section_Id"
        Public ReadOnly Property Section_Id() As System.String
            Get
                Return m_Section_Id
            End Get
        End Property

        Private m_Dept_Sect_Name As String = "Dept_Sect_Name"
        Public ReadOnly Property Dept_Sect_Name() As System.String
            Get
                Return m_Dept_Sect_Name
            End Get
        End Property

        Private m_Dept_Sect_En_Name As String = "Dept_Sect_En_Name"
        Public ReadOnly Property Dept_Sect_En_Name() As System.String
            Get
                Return m_Dept_Sect_En_Name
            End Get
        End Property

        Private m_Dept_Sect_Alias_Name As String = "Dept_Sect_Alias_Name"
        Public ReadOnly Property Dept_Sect_Alias_Name() As System.String
            Get
                Return m_Dept_Sect_Alias_Name
            End Get
        End Property

        Private m_Dept_Sect_Alias_En_Name As String = "Dept_Sect_Alias_En_Name"
        Public ReadOnly Property Dept_Sect_Alias_En_Name() As System.String
            Get
                Return m_Dept_Sect_Alias_En_Name
            End Get
        End Property

        Private m_Dc As String = "Dc"
        Public ReadOnly Property Dc() As System.String
            Get
                Return m_Dc
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

        Private m_Health_Opd_Dept_Code As String = "Health_Opd_Dept_Code"
        Public ReadOnly Property Health_Opd_Dept_Code() As System.String
            Get
                Return m_Health_Opd_Dept_Code
            End Get
        End Property

        Private m_Health_Ipd_Dept_Code As String = "Health_Ipd_Dept_Code"
        Public ReadOnly Property Health_Ipd_Dept_Code() As System.String
            Get
                Return m_Health_Ipd_Dept_Code
            End Get
        End Property

        Private m_Dept_Sect_Kind_Id As String = "Dept_Sect_Kind_Id"
        Public ReadOnly Property Dept_Sect_Kind_Id() As System.String
            Get
                Return m_Dept_Sect_Kind_Id
            End Get
        End Property

    End Class

End Class
