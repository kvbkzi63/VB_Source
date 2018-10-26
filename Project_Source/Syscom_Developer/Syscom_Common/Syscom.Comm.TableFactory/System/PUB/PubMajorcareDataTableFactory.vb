Imports System.Data.SqlClient
Public Class PubMajorcareDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/12/21 下午 01:40:16
    Public Shared ReadOnly tableName As String = "PUB_Majorcare"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Majorcare_Code", "Majorcare_Name", "Majorcare_Type_Id", "Case_Type_Id", "Is_Dr_Use", _
             "Add_Ratio", "Examine_Order_Code", "Create_User", "Create_Time", "Modified_User", _
             "Modified_Time", "Order_Code_List"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.Decimal", "System.String", "System.String", "System.DateTime", "System.String", _
             "System.DateTime", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             2, 100, 5, 5, 1, _
             -1, 20, 10, -1, 10, _
             -1, 100}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub example()
        Dim dataSet As DataSet = New DataSet
        Dim dataTable As DataTable = PubMajorcareDataTableFactory.getDataTableWithSchema
        Dim dataRow As DataRow = dataTable.NewRow()
        '使用自己的資料來源取代 New Object 
        dataRow("Majorcare_Code") = New Object
        dataRow("Majorcare_Name") = New Object
        dataRow("Majorcare_Type_Id") = New Object
        dataRow("Case_Type_Id") = New Object
        dataRow("Is_Dr_Use") = New Object
        dataRow("Add_Ratio") = New Object
        dataRow("Examine_Order_Code") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Order_Code_List") = New Object
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
            dt.Columns.Add("Majorcare_Code")
            dt.Columns.Add("Majorcare_Name")
            dt.Columns.Add("Majorcare_Type_Id")
            dt.Columns.Add("Case_Type_Id")
            dt.Columns.Add("Is_Dr_Use")
            dt.Columns.Add("Add_Ratio")
            dt.Columns.Add("Examine_Order_Code")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Order_Code_List")
            Dim pkColArray(0) As DataColumn
            pkColArray(0) = dt.Columns("Majorcare_Code")
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
            dt.Columns.Add("Majorcare_Code")
            dt.Columns("Majorcare_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Majorcare_Name")
            dt.Columns("Majorcare_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Majorcare_Type_Id")
            dt.Columns("Majorcare_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Case_Type_Id")
            dt.Columns("Case_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Dr_Use")
            dt.Columns("Is_Dr_Use").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Add_Ratio")
            dt.Columns("Add_Ratio").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Examine_Order_Code")
            dt.Columns("Examine_Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Order_Code_List")
            dt.Columns("Order_Code_List").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn
            pkColArray(0) = dt.Columns("Majorcare_Code")
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
            dt.Columns.Add("Majorcare_Code")
            dt.Columns.Add("Majorcare_Name")
            dt.Columns.Add("Majorcare_Type_Id")
            dt.Columns.Add("Case_Type_Id")
            dt.Columns.Add("Is_Dr_Use")
            dt.Columns.Add("Add_Ratio")
            dt.Columns.Add("Examine_Order_Code")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Order_Code_List")
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

    Class PUBMajorcarePt
        Private m_Majorcare_Code As String = "Majorcare_Code"
        Public ReadOnly Property Majorcare_Code() As System.String
            Get
                Return m_Majorcare_Code
            End Get
        End Property

        Private m_Majorcare_Name As String = "Majorcare_Name"
        Public ReadOnly Property Majorcare_Name() As System.String
            Get
                Return m_Majorcare_Name
            End Get
        End Property

        Private m_Majorcare_Type_Id As String = "Majorcare_Type_Id"
        Public ReadOnly Property Majorcare_Type_Id() As System.String
            Get
                Return m_Majorcare_Type_Id
            End Get
        End Property

        Private m_Case_Type_Id As String = "Case_Type_Id"
        Public ReadOnly Property Case_Type_Id() As System.String
            Get
                Return m_Case_Type_Id
            End Get
        End Property

        Private m_Is_Dr_Use As String = "Is_Dr_Use"
        Public ReadOnly Property Is_Dr_Use() As System.String
            Get
                Return m_Is_Dr_Use
            End Get
        End Property

        Private m_Add_Ratio As String = "Add_Ratio"
        Public ReadOnly Property Add_Ratio() As System.String
            Get
                Return m_Add_Ratio
            End Get
        End Property

        Private m_Examine_Order_Code As String = "Examine_Order_Code"
        Public ReadOnly Property Examine_Order_Code() As System.String
            Get
                Return m_Examine_Order_Code
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

        Private m_Order_Code_List As String = "Order_Code_List"
        Public ReadOnly Property Order_Code_List() As System.String
            Get
                Return m_Order_Code_List
            End Get
        End Property

    End Class

End Class
