Imports System.Data.SqlClient
Public Class PubHospitalDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/10/18 上午 10:12:39
    Public Shared ReadOnly tableName As String = "PUB_Hospital"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Language_Type_Id", "Hospital_Code", "Effect_Date", "End_Date", "Hospital_Name", _
             "Hospital_Short_Name", "Telephone", "Fax", "Voice_Tel", "Postal_Code", _
             "Address", "Principal_Name", "Principal_Email", "Hospital_Level_Id", "URL", _
             "Unified_Business_No", "Create_User", "Create_Time", "Modified_User", "Modified_Time", _
             "License_No", "Receipt_Hospital_Name"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.DateTime", "System.DateTime", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime", _
             "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             5, 20, -1, -1, 50, _
             20, 20, 20, 20, 5, _
             100, 20, 100, 5, 100, _
             20, 10, -1, 10, -1, _
             20, 50}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub example()
        Dim dataSet As DataSet = New DataSet
        Dim dataTable As DataTable = PubHospitalDataTableFactory.getDataTableWithSchema
        Dim dataRow As DataRow = dataTable.NewRow()
        '使用自己的資料來源取代 New Object 
        dataRow("Language_Type_Id") = New Object
        dataRow("Hospital_Code") = New Object
        dataRow("Effect_Date") = New Object
        dataRow("End_Date") = New Object
        dataRow("Hospital_Name") = New Object
        dataRow("Hospital_Short_Name") = New Object
        dataRow("Telephone") = New Object
        dataRow("Fax") = New Object
        dataRow("Voice_Tel") = New Object
        dataRow("Postal_Code") = New Object
        dataRow("Address") = New Object
        dataRow("Principal_Name") = New Object
        dataRow("Principal_Email") = New Object
        dataRow("Hospital_Level_Id") = New Object
        dataRow("URL") = New Object
        dataRow("Unified_Business_No") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("License_No") = New Object
        dataRow("Receipt_Hospital_Name") = New Object
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
            dt.Columns.Add("Language_Type_Id")
            dt.Columns.Add("Hospital_Code")
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Hospital_Name")
            dt.Columns.Add("Hospital_Short_Name")
            dt.Columns.Add("Telephone")
            dt.Columns.Add("Fax")
            dt.Columns.Add("Voice_Tel")
            dt.Columns.Add("Postal_Code")
            dt.Columns.Add("Address")
            dt.Columns.Add("Principal_Name")
            dt.Columns.Add("Principal_Email")
            dt.Columns.Add("Hospital_Level_Id")
            dt.Columns.Add("URL")
            dt.Columns.Add("Unified_Business_No")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("License_No")
            dt.Columns.Add("Receipt_Hospital_Name")
            Dim pkColArray(2) As DataColumn
            pkColArray(0) = dt.Columns("Language_Type_Id")
            pkColArray(1) = dt.Columns("Hospital_Code")
            pkColArray(2) = dt.Columns("Effect_Date")
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
            dt.Columns.Add("Language_Type_Id")
            dt.Columns("Language_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Hospital_Code")
            dt.Columns("Hospital_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Effect_Date")
            dt.Columns("Effect_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("End_Date")
            dt.Columns("End_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Hospital_Name")
            dt.Columns("Hospital_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Hospital_Short_Name")
            dt.Columns("Hospital_Short_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Telephone")
            dt.Columns("Telephone").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Fax")
            dt.Columns("Fax").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Voice_Tel")
            dt.Columns("Voice_Tel").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Postal_Code")
            dt.Columns("Postal_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Address")
            dt.Columns("Address").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Principal_Name")
            dt.Columns("Principal_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Principal_Email")
            dt.Columns("Principal_Email").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Hospital_Level_Id")
            dt.Columns("Hospital_Level_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("URL")
            dt.Columns("URL").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Unified_Business_No")
            dt.Columns("Unified_Business_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("License_No")
            dt.Columns("License_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Receipt_Hospital_Name")
            dt.Columns("Receipt_Hospital_Name").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn
            pkColArray(0) = dt.Columns("Language_Type_Id")
            pkColArray(1) = dt.Columns("Hospital_Code")
            pkColArray(2) = dt.Columns("Effect_Date")
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
            dt.Columns.Add("Language_Type_Id")
            dt.Columns.Add("Hospital_Code")
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Hospital_Name")
            dt.Columns.Add("Hospital_Short_Name")
            dt.Columns.Add("Telephone")
            dt.Columns.Add("Fax")
            dt.Columns.Add("Voice_Tel")
            dt.Columns.Add("Postal_Code")
            dt.Columns.Add("Address")
            dt.Columns.Add("Principal_Name")
            dt.Columns.Add("Principal_Email")
            dt.Columns.Add("Hospital_Level_Id")
            dt.Columns.Add("URL")
            dt.Columns.Add("Unified_Business_No")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("License_No")
            dt.Columns.Add("Receipt_Hospital_Name")
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

    Class PUBHospitalPt
        Private m_Language_Type_Id As String = "Language_Type_Id"
        Public ReadOnly Property Language_Type_Id() As System.String
            Get
                Return m_Language_Type_Id
            End Get
        End Property

        Private m_Hospital_Code As String = "Hospital_Code"
        Public ReadOnly Property Hospital_Code() As System.String
            Get
                Return m_Hospital_Code
            End Get
        End Property

        Private m_Effect_Date As String = "Effect_Date"
        Public ReadOnly Property Effect_Date() As System.String
            Get
                Return m_Effect_Date
            End Get
        End Property

        Private m_End_Date As String = "End_Date"
        Public ReadOnly Property End_Date() As System.String
            Get
                Return m_End_Date
            End Get
        End Property

        Private m_Hospital_Name As String = "Hospital_Name"
        Public ReadOnly Property Hospital_Name() As System.String
            Get
                Return m_Hospital_Name
            End Get
        End Property

        Private m_Hospital_Short_Name As String = "Hospital_Short_Name"
        Public ReadOnly Property Hospital_Short_Name() As System.String
            Get
                Return m_Hospital_Short_Name
            End Get
        End Property

        Private m_Telephone As String = "Telephone"
        Public ReadOnly Property Telephone() As System.String
            Get
                Return m_Telephone
            End Get
        End Property

        Private m_Fax As String = "Fax"
        Public ReadOnly Property Fax() As System.String
            Get
                Return m_Fax
            End Get
        End Property

        Private m_Voice_Tel As String = "Voice_Tel"
        Public ReadOnly Property Voice_Tel() As System.String
            Get
                Return m_Voice_Tel
            End Get
        End Property

        Private m_Postal_Code As String = "Postal_Code"
        Public ReadOnly Property Postal_Code() As System.String
            Get
                Return m_Postal_Code
            End Get
        End Property

        Private m_Address As String = "Address"
        Public ReadOnly Property Address() As System.String
            Get
                Return m_Address
            End Get
        End Property

        Private m_Principal_Name As String = "Principal_Name"
        Public ReadOnly Property Principal_Name() As System.String
            Get
                Return m_Principal_Name
            End Get
        End Property

        Private m_Principal_Email As String = "Principal_Email"
        Public ReadOnly Property Principal_Email() As System.String
            Get
                Return m_Principal_Email
            End Get
        End Property

        Private m_Hospital_Level_Id As String = "Hospital_Level_Id"
        Public ReadOnly Property Hospital_Level_Id() As System.String
            Get
                Return m_Hospital_Level_Id
            End Get
        End Property

        Private m_URL As String = "URL"
        Public ReadOnly Property URL() As System.String
            Get
                Return m_URL
            End Get
        End Property

        Private m_Unified_Business_No As String = "Unified_Business_No"
        Public ReadOnly Property Unified_Business_No() As System.String
            Get
                Return m_Unified_Business_No
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

        Private m_License_No As String = "License_No"
        Public ReadOnly Property License_No() As System.String
            Get
                Return m_License_No
            End Get
        End Property

        Private m_Receipt_Hospital_Name As String = "Receipt_Hospital_Name"
        Public ReadOnly Property Receipt_Hospital_Name() As System.String
            Get
                Return m_Receipt_Hospital_Name
            End Get
        End Property

    End Class

End Class
