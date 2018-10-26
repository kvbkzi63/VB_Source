Imports System.Data.SqlClient
Public Class PubMedicalTypeDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/11/11 上午 11:01:34
    Public Shared ReadOnly tableName As String = "PUB_Medical_Type"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Medical_Type_Id", "Medical_Type_Name", "Medical_Type_Ctrl_Id", "Dis_Identity_Code", "Contract_Code1", _
             "Contract_Code2", "Part_Code", "Card_Sn", "IC_Medical_Type_Id", "Case_Type_Id", _
             "Dc", "Create_User", "Create_Time", "Modified_User", "Modified_Time", _
             "PED_Sort", "SUR_Sort", "MED_Sort", "ENT_Sort", "URO_Sort", _
             "REH_Sort", "IPD_Sort", "Is_Register_Fee", "Is_Examine", "Is_Pha_Services", _
             "OPD_Sort", "EMG_Sort"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime", _
             "System.Int32", "System.Int32", "System.Int32", "System.Int32", "System.Int32", _
             "System.Int32", "System.Int32", "System.String", "System.String", "System.String", _
             "System.Int32", "System.Int32"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             5, 50, 5, 2, 6, _
             6, 3, 4, 5, 5, _
             1, 10, -1, 10, -1, _
             -1, -1, -1, -1, -1, _
             -1, -1, 1, 1, 1, _
             -1, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub example()
        Dim dataSet As DataSet = New DataSet
        Dim dataTable As DataTable = PubMedicalTypeDataTableFactory.getDataTableWithSchema
        Dim dataRow As DataRow = dataTable.NewRow()
        '使用自己的資料來源取代 New Object 
        dataRow("Medical_Type_Id") = New Object
        dataRow("Medical_Type_Name") = New Object
        dataRow("Medical_Type_Ctrl_Id") = New Object
        dataRow("Dis_Identity_Code") = New Object
        dataRow("Contract_Code1") = New Object
        dataRow("Contract_Code2") = New Object
        dataRow("Part_Code") = New Object
        dataRow("Card_Sn") = New Object
        dataRow("IC_Medical_Type_Id") = New Object
        dataRow("Case_Type_Id") = New Object
        dataRow("Dc") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("PED_Sort") = New Object
        dataRow("SUR_Sort") = New Object
        dataRow("MED_Sort") = New Object
        dataRow("ENT_Sort") = New Object
        dataRow("URO_Sort") = New Object
        dataRow("REH_Sort") = New Object
        dataRow("IPD_Sort") = New Object
        dataRow("Is_Register_Fee") = New Object
        dataRow("Is_Examine") = New Object
        dataRow("Is_Pha_Services") = New Object
        dataRow("OPD_Sort") = New Object
        dataRow("EMG_Sort") = New Object
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
            dt.Columns.Add("Medical_Type_Id")
            dt.Columns.Add("Medical_Type_Name")
            dt.Columns.Add("Medical_Type_Ctrl_Id")
            dt.Columns.Add("Dis_Identity_Code")
            dt.Columns.Add("Contract_Code1")
            dt.Columns.Add("Contract_Code2")
            dt.Columns.Add("Part_Code")
            dt.Columns.Add("Card_Sn")
            dt.Columns.Add("IC_Medical_Type_Id")
            dt.Columns.Add("Case_Type_Id")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("PED_Sort")
            dt.Columns.Add("SUR_Sort")
            dt.Columns.Add("MED_Sort")
            dt.Columns.Add("ENT_Sort")
            dt.Columns.Add("URO_Sort")
            dt.Columns.Add("REH_Sort")
            dt.Columns.Add("IPD_Sort")
            dt.Columns.Add("Is_Register_Fee")
            dt.Columns.Add("Is_Examine")
            dt.Columns.Add("Is_Pha_Services")
            dt.Columns.Add("OPD_Sort")
            dt.Columns.Add("EMG_Sort")
            Dim pkColArray(0) As DataColumn
            pkColArray(0) = dt.Columns("Medical_Type_Id")
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
            dt.Columns.Add("Medical_Type_Id")
            dt.Columns("Medical_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Medical_Type_Name")
            dt.Columns("Medical_Type_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Medical_Type_Ctrl_Id")
            dt.Columns("Medical_Type_Ctrl_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dis_Identity_Code")
            dt.Columns("Dis_Identity_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contract_Code1")
            dt.Columns("Contract_Code1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contract_Code2")
            dt.Columns("Contract_Code2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Part_Code")
            dt.Columns("Part_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Card_Sn")
            dt.Columns("Card_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("IC_Medical_Type_Id")
            dt.Columns("IC_Medical_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Case_Type_Id")
            dt.Columns("Case_Type_Id").DataType = System.Type.GetType("System.String")
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
            dt.Columns.Add("PED_Sort")
            dt.Columns("PED_Sort").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("SUR_Sort")
            dt.Columns("SUR_Sort").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("MED_Sort")
            dt.Columns("MED_Sort").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("ENT_Sort")
            dt.Columns("ENT_Sort").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("URO_Sort")
            dt.Columns("URO_Sort").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("REH_Sort")
            dt.Columns("REH_Sort").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("IPD_Sort")
            dt.Columns("IPD_Sort").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Is_Register_Fee")
            dt.Columns("Is_Register_Fee").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Examine")
            dt.Columns("Is_Examine").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Pha_Services")
            dt.Columns("Is_Pha_Services").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("OPD_Sort")
            dt.Columns("OPD_Sort").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("EMG_Sort")
            dt.Columns("EMG_Sort").DataType = System.Type.GetType("System.Int32")
            Dim pkColArray(0) As DataColumn
            pkColArray(0) = dt.Columns("Medical_Type_Id")
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
            dt.Columns.Add("Medical_Type_Id")
            dt.Columns.Add("Medical_Type_Name")
            dt.Columns.Add("Medical_Type_Ctrl_Id")
            dt.Columns.Add("Dis_Identity_Code")
            dt.Columns.Add("Contract_Code1")
            dt.Columns.Add("Contract_Code2")
            dt.Columns.Add("Part_Code")
            dt.Columns.Add("Card_Sn")
            dt.Columns.Add("IC_Medical_Type_Id")
            dt.Columns.Add("Case_Type_Id")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("PED_Sort")
            dt.Columns.Add("SUR_Sort")
            dt.Columns.Add("MED_Sort")
            dt.Columns.Add("ENT_Sort")
            dt.Columns.Add("URO_Sort")
            dt.Columns.Add("REH_Sort")
            dt.Columns.Add("IPD_Sort")
            dt.Columns.Add("Is_Register_Fee")
            dt.Columns.Add("Is_Examine")
            dt.Columns.Add("Is_Pha_Services")
            dt.Columns.Add("OPD_Sort")
            dt.Columns.Add("EMG_Sort")
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

    Class PUBMedicalTypePt
        Private m_Medical_Type_Id As String = "Medical_Type_Id"
        Public ReadOnly Property Medical_Type_Id() As System.String
            Get
                Return m_Medical_Type_Id
            End Get
        End Property

        Private m_Medical_Type_Name As String = "Medical_Type_Name"
        Public ReadOnly Property Medical_Type_Name() As System.String
            Get
                Return m_Medical_Type_Name
            End Get
        End Property

        Private m_Medical_Type_Ctrl_Id As String = "Medical_Type_Ctrl_Id"
        Public ReadOnly Property Medical_Type_Ctrl_Id() As System.String
            Get
                Return m_Medical_Type_Ctrl_Id
            End Get
        End Property

        Private m_Dis_Identity_Code As String = "Dis_Identity_Code"
        Public ReadOnly Property Dis_Identity_Code() As System.String
            Get
                Return m_Dis_Identity_Code
            End Get
        End Property

        Private m_Contract_Code1 As String = "Contract_Code1"
        Public ReadOnly Property Contract_Code1() As System.String
            Get
                Return m_Contract_Code1
            End Get
        End Property

        Private m_Contract_Code2 As String = "Contract_Code2"
        Public ReadOnly Property Contract_Code2() As System.String
            Get
                Return m_Contract_Code2
            End Get
        End Property

        Private m_Part_Code As String = "Part_Code"
        Public ReadOnly Property Part_Code() As System.String
            Get
                Return m_Part_Code
            End Get
        End Property

        Private m_Card_Sn As String = "Card_Sn"
        Public ReadOnly Property Card_Sn() As System.String
            Get
                Return m_Card_Sn
            End Get
        End Property

        Private m_IC_Medical_Type_Id As String = "IC_Medical_Type_Id"
        Public ReadOnly Property IC_Medical_Type_Id() As System.String
            Get
                Return m_IC_Medical_Type_Id
            End Get
        End Property

        Private m_Case_Type_Id As String = "Case_Type_Id"
        Public ReadOnly Property Case_Type_Id() As System.String
            Get
                Return m_Case_Type_Id
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

        Private m_PED_Sort As String = "PED_Sort"
        Public ReadOnly Property PED_Sort() As System.String
            Get
                Return m_PED_Sort
            End Get
        End Property

        Private m_SUR_Sort As String = "SUR_Sort"
        Public ReadOnly Property SUR_Sort() As System.String
            Get
                Return m_SUR_Sort
            End Get
        End Property

        Private m_MED_Sort As String = "MED_Sort"
        Public ReadOnly Property MED_Sort() As System.String
            Get
                Return m_MED_Sort
            End Get
        End Property

        Private m_ENT_Sort As String = "ENT_Sort"
        Public ReadOnly Property ENT_Sort() As System.String
            Get
                Return m_ENT_Sort
            End Get
        End Property

        Private m_URO_Sort As String = "URO_Sort"
        Public ReadOnly Property URO_Sort() As System.String
            Get
                Return m_URO_Sort
            End Get
        End Property

        Private m_REH_Sort As String = "REH_Sort"
        Public ReadOnly Property REH_Sort() As System.String
            Get
                Return m_REH_Sort
            End Get
        End Property

        Private m_IPD_Sort As String = "IPD_Sort"
        Public ReadOnly Property IPD_Sort() As System.String
            Get
                Return m_IPD_Sort
            End Get
        End Property

        Private m_Is_Register_Fee As String = "Is_Register_Fee"
        Public ReadOnly Property Is_Register_Fee() As System.String
            Get
                Return m_Is_Register_Fee
            End Get
        End Property

        Private m_Is_Examine As String = "Is_Examine"
        Public ReadOnly Property Is_Examine() As System.String
            Get
                Return m_Is_Examine
            End Get
        End Property

        Private m_Is_Pha_Services As String = "Is_Pha_Services"
        Public ReadOnly Property Is_Pha_Services() As System.String
            Get
                Return m_Is_Pha_Services
            End Get
        End Property

        Private m_OPD_Sort As String = "OPD_Sort"
        Public ReadOnly Property OPD_Sort() As System.String
            Get
                Return m_OPD_Sort
            End Get
        End Property

        Private m_EMG_Sort As String = "EMG_Sort"
        Public ReadOnly Property EMG_Sort() As System.String
            Get
                Return m_EMG_Sort
            End Get
        End Property

    End Class

End Class
