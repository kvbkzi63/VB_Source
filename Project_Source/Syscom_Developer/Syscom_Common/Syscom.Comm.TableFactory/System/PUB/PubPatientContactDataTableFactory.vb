Imports System.Data.SqlClient
Public Class PubPatientContactDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:52
    Public Shared ReadOnly tableName as String="PUB_Patient_Contact"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Chart_No", "Patient_Contact_No", "Contact_Name", "Relation_Type_Id", "Contact_Tel_Home",   _
             "Contact_Tel_Office", "Contact_Tel_Mobile", "Contact_Postal_Code", "Contact_Address", "Contact_Email",   _
             "Dc", "Create_User", "Create_Time", "Modified_User", "Modified_Time",   _
             "Keyin_Unit", "Contact_Sort_Value", "Contact_Memo", "Special_Identity", "Dist_Code",   _
             "Vil_Code"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Int32", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime",   _
             "System.String", "System.Int32", "System.String", "System.String", "System.String",   _
             "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, -1, 50, 10, 30,   _
             30, 30, 5, 100, 50,   _
             1, 10, -1, 10, -1,   _
             5, -1, 100, 20, 7,   _
             11}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubPatientContactDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Chart_No") = New Object
        dataRow("Patient_Contact_No") = New Object
        dataRow("Contact_Name") = New Object
        dataRow("Relation_Type_Id") = New Object
        dataRow("Contact_Tel_Home") = New Object
        dataRow("Contact_Tel_Office") = New Object
        dataRow("Contact_Tel_Mobile") = New Object
        dataRow("Contact_Postal_Code") = New Object
        dataRow("Contact_Address") = New Object
        dataRow("Contact_Email") = New Object
        dataRow("Dc") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Keyin_Unit") = New Object
        dataRow("Contact_Sort_Value") = New Object
        dataRow("Contact_Memo") = New Object
        dataRow("Special_Identity") = New Object
        dataRow("Dist_Code") = New Object
        dataRow("Vil_Code") = New Object
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
            dt.Columns.Add("Chart_No")
            dt.Columns.Add("Patient_Contact_No")
            dt.Columns.Add("Contact_Name")
            dt.Columns.Add("Relation_Type_Id")
            dt.Columns.Add("Contact_Tel_Home")
            dt.Columns.Add("Contact_Tel_Office")
            dt.Columns.Add("Contact_Tel_Mobile")
            dt.Columns.Add("Contact_Postal_Code")
            dt.Columns.Add("Contact_Address")
            dt.Columns.Add("Contact_Email")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Keyin_Unit")
            dt.Columns.Add("Contact_Sort_Value")
            dt.Columns.Add("Contact_Memo")
            dt.Columns.Add("Special_Identity")
            dt.Columns.Add("Dist_Code")
            dt.Columns.Add("Vil_Code")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Patient_Contact_No")
            pkColArray(2) = dt.Columns("Keyin_Unit")
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
            dt.Columns.Add("Chart_No")
            dt.Columns("Chart_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Patient_Contact_No")
            dt.Columns("Patient_Contact_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Contact_Name")
            dt.Columns("Contact_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Relation_Type_Id")
            dt.Columns("Relation_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Tel_Home")
            dt.Columns("Contact_Tel_Home").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Tel_Office")
            dt.Columns("Contact_Tel_Office").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Tel_Mobile")
            dt.Columns("Contact_Tel_Mobile").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Postal_Code")
            dt.Columns("Contact_Postal_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Address")
            dt.Columns("Contact_Address").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Email")
            dt.Columns("Contact_Email").DataType = System.Type.GetType("System.String")
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
            dt.Columns.Add("Keyin_Unit")
            dt.Columns("Keyin_Unit").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Sort_Value")
            dt.Columns("Contact_Sort_Value").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Contact_Memo")
            dt.Columns("Contact_Memo").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Special_Identity")
            dt.Columns("Special_Identity").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dist_Code")
            dt.Columns("Dist_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Vil_Code")
            dt.Columns("Vil_Code").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Patient_Contact_No")
            pkColArray(2) = dt.Columns("Keyin_Unit")
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
            dt.Columns.Add("Chart_No")
            dt.Columns.Add("Patient_Contact_No")
            dt.Columns.Add("Contact_Name")
            dt.Columns.Add("Relation_Type_Id")
            dt.Columns.Add("Contact_Tel_Home")
            dt.Columns.Add("Contact_Tel_Office")
            dt.Columns.Add("Contact_Tel_Mobile")
            dt.Columns.Add("Contact_Postal_Code")
            dt.Columns.Add("Contact_Address")
            dt.Columns.Add("Contact_Email")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Keyin_Unit")
            dt.Columns.Add("Contact_Sort_Value")
            dt.Columns.Add("Contact_Memo")
            dt.Columns.Add("Special_Identity")
            dt.Columns.Add("Dist_Code")
            dt.Columns.Add("Vil_Code")
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

  Class PUBPatientContactPt
    Private m_Chart_No As String = "Chart_No"
    Public ReadOnly Property Chart_No() As System.String 
    Get
        Return m_Chart_No
    End Get
    End Property

    Private m_Patient_Contact_No As String = "Patient_Contact_No"
    Public ReadOnly Property Patient_Contact_No() As System.String 
    Get
        Return m_Patient_Contact_No
    End Get
    End Property

    Private m_Contact_Name As String = "Contact_Name"
    Public ReadOnly Property Contact_Name() As System.String 
    Get
        Return m_Contact_Name
    End Get
    End Property

    Private m_Relation_Type_Id As String = "Relation_Type_Id"
    Public ReadOnly Property Relation_Type_Id() As System.String 
    Get
        Return m_Relation_Type_Id
    End Get
    End Property

    Private m_Contact_Tel_Home As String = "Contact_Tel_Home"
    Public ReadOnly Property Contact_Tel_Home() As System.String 
    Get
        Return m_Contact_Tel_Home
    End Get
    End Property

    Private m_Contact_Tel_Office As String = "Contact_Tel_Office"
    Public ReadOnly Property Contact_Tel_Office() As System.String 
    Get
        Return m_Contact_Tel_Office
    End Get
    End Property

    Private m_Contact_Tel_Mobile As String = "Contact_Tel_Mobile"
    Public ReadOnly Property Contact_Tel_Mobile() As System.String 
    Get
        Return m_Contact_Tel_Mobile
    End Get
    End Property

    Private m_Contact_Postal_Code As String = "Contact_Postal_Code"
    Public ReadOnly Property Contact_Postal_Code() As System.String 
    Get
        Return m_Contact_Postal_Code
    End Get
    End Property

    Private m_Contact_Address As String = "Contact_Address"
    Public ReadOnly Property Contact_Address() As System.String 
    Get
        Return m_Contact_Address
    End Get
    End Property

    Private m_Contact_Email As String = "Contact_Email"
    Public ReadOnly Property Contact_Email() As System.String 
    Get
        Return m_Contact_Email
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

    Private m_Keyin_Unit As String = "Keyin_Unit"
    Public ReadOnly Property Keyin_Unit() As System.String 
    Get
        Return m_Keyin_Unit
    End Get
    End Property

    Private m_Contact_Sort_Value As String = "Contact_Sort_Value"
    Public ReadOnly Property Contact_Sort_Value() As System.String 
    Get
        Return m_Contact_Sort_Value
    End Get
    End Property

    Private m_Contact_Memo As String = "Contact_Memo"
    Public ReadOnly Property Contact_Memo() As System.String 
    Get
        Return m_Contact_Memo
    End Get
    End Property

    Private m_Special_Identity As String = "Special_Identity"
    Public ReadOnly Property Special_Identity() As System.String 
    Get
        Return m_Special_Identity
    End Get
    End Property

    Private m_Dist_Code As String = "Dist_Code"
    Public ReadOnly Property Dist_Code() As System.String 
    Get
        Return m_Dist_Code
    End Get
    End Property

    Private m_Vil_Code As String = "Vil_Code"
    Public ReadOnly Property Vil_Code() As System.String 
    Get
        Return m_Vil_Code
    End Get
    End Property

  End Class

End Class
