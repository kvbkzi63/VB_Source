Imports System.Data.SqlClient
Public Class PubContractDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:47
    Public Shared ReadOnly tableName as String="PUB_Contract"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Contract_Code", "Sub_Identity_Code", "Contract_Name", "Is_Use_Set", "Upper_Amt",   _
             "Upper_Amt_Type_Id", "Check_Quota_Id", "Project_Director", "Drug_Code", "Drug_Name",   _
             "Drug_Committee_Sn", "Project_Effect_Date", "Project_End_Date", "Receipt_Title", "Contact_Name",   _
             "Contact_Tel", "Contact_Tel_Mobile", "Contact_Fax", "Contact_Email", "Contact_Postal_Code",   _
             "Contact_Address", "Dis_Rate", "Add_Rate", "Memo", "Dc",   _
             "Create_User", "Create_Time", "Modified_User", "Modified_Time", "Contract_Type_Id"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.Decimal",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.DateTime", "System.DateTime", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.Decimal", "System.Decimal", "System.String", "System.String",   _
             "System.String", "System.DateTime", "System.String", "System.DateTime", "System.String"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             6, 2, 50, 1, -1,   _
             5, 5, 50, 20, 50,   _
             20, -1, -1, 50, 50,   _
             20, 20, 20, 50, 5,   _
             100, -1, -1, 300, 1,   _
             10, -1, 10, -1, 5  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubContractDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Contract_Code") = New Object
        dataRow("Sub_Identity_Code") = New Object
        dataRow("Contract_Name") = New Object
        dataRow("Is_Use_Set") = New Object
        dataRow("Upper_Amt") = New Object
        dataRow("Upper_Amt_Type_Id") = New Object
        dataRow("Check_Quota_Id") = New Object
        dataRow("Project_Director") = New Object
        dataRow("Drug_Code") = New Object
        dataRow("Drug_Name") = New Object
        dataRow("Drug_Committee_Sn") = New Object
        dataRow("Project_Effect_Date") = New Object
        dataRow("Project_End_Date") = New Object
        dataRow("Receipt_Title") = New Object
        dataRow("Contact_Name") = New Object
        dataRow("Contact_Tel") = New Object
        dataRow("Contact_Tel_Mobile") = New Object
        dataRow("Contact_Fax") = New Object
        dataRow("Contact_Email") = New Object
        dataRow("Contact_Postal_Code") = New Object
        dataRow("Contact_Address") = New Object
        dataRow("Dis_Rate") = New Object
        dataRow("Add_Rate") = New Object
        dataRow("Memo") = New Object
        dataRow("Dc") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Contract_Type_Id") = New Object
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
            dt.Columns.Add("Contract_Code")
            dt.Columns.Add("Sub_Identity_Code")
            dt.Columns.Add("Contract_Name")
            dt.Columns.Add("Is_Use_Set")
            dt.Columns.Add("Upper_Amt")
            dt.Columns.Add("Upper_Amt_Type_Id")
            dt.Columns.Add("Check_Quota_Id")
            dt.Columns.Add("Project_Director")
            dt.Columns.Add("Drug_Code")
            dt.Columns.Add("Drug_Name")
            dt.Columns.Add("Drug_Committee_Sn")
            dt.Columns.Add("Project_Effect_Date")
            dt.Columns.Add("Project_End_Date")
            dt.Columns.Add("Receipt_Title")
            dt.Columns.Add("Contact_Name")
            dt.Columns.Add("Contact_Tel")
            dt.Columns.Add("Contact_Tel_Mobile")
            dt.Columns.Add("Contact_Fax")
            dt.Columns.Add("Contact_Email")
            dt.Columns.Add("Contact_Postal_Code")
            dt.Columns.Add("Contact_Address")
            dt.Columns.Add("Dis_Rate")
            dt.Columns.Add("Add_Rate")
            dt.Columns.Add("Memo")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Contract_Type_Id")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Contract_Code")
            pkColArray(1) = dt.Columns("Sub_Identity_Code")
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
            dt.Columns.Add("Contract_Code")
            dt.Columns("Contract_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sub_Identity_Code")
            dt.Columns("Sub_Identity_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contract_Name")
            dt.Columns("Contract_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Use_Set")
            dt.Columns("Is_Use_Set").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Upper_Amt")
            dt.Columns("Upper_Amt").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Upper_Amt_Type_Id")
            dt.Columns("Upper_Amt_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Check_Quota_Id")
            dt.Columns("Check_Quota_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Project_Director")
            dt.Columns("Project_Director").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Drug_Code")
            dt.Columns("Drug_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Drug_Name")
            dt.Columns("Drug_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Drug_Committee_Sn")
            dt.Columns("Drug_Committee_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Project_Effect_Date")
            dt.Columns("Project_Effect_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Project_End_Date")
            dt.Columns("Project_End_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Receipt_Title")
            dt.Columns("Receipt_Title").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Name")
            dt.Columns("Contact_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Tel")
            dt.Columns("Contact_Tel").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Tel_Mobile")
            dt.Columns("Contact_Tel_Mobile").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Fax")
            dt.Columns("Contact_Fax").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Email")
            dt.Columns("Contact_Email").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Postal_Code")
            dt.Columns("Contact_Postal_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Address")
            dt.Columns("Contact_Address").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dis_Rate")
            dt.Columns("Dis_Rate").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Add_Rate")
            dt.Columns("Add_Rate").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Memo")
            dt.Columns("Memo").DataType = System.Type.GetType("System.String")
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
            dt.Columns.Add("Contract_Type_Id")
            dt.Columns("Contract_Type_Id").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Contract_Code")
            pkColArray(1) = dt.Columns("Sub_Identity_Code")
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
            dt.Columns.Add("Contract_Code")
            dt.Columns.Add("Sub_Identity_Code")
            dt.Columns.Add("Contract_Name")
            dt.Columns.Add("Is_Use_Set")
            dt.Columns.Add("Upper_Amt")
            dt.Columns.Add("Upper_Amt_Type_Id")
            dt.Columns.Add("Check_Quota_Id")
            dt.Columns.Add("Project_Director")
            dt.Columns.Add("Drug_Code")
            dt.Columns.Add("Drug_Name")
            dt.Columns.Add("Drug_Committee_Sn")
            dt.Columns.Add("Project_Effect_Date")
            dt.Columns.Add("Project_End_Date")
            dt.Columns.Add("Receipt_Title")
            dt.Columns.Add("Contact_Name")
            dt.Columns.Add("Contact_Tel")
            dt.Columns.Add("Contact_Tel_Mobile")
            dt.Columns.Add("Contact_Fax")
            dt.Columns.Add("Contact_Email")
            dt.Columns.Add("Contact_Postal_Code")
            dt.Columns.Add("Contact_Address")
            dt.Columns.Add("Dis_Rate")
            dt.Columns.Add("Add_Rate")
            dt.Columns.Add("Memo")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Contract_Type_Id")
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

  Class PUBContractPt
    Private m_Contract_Code As String = "Contract_Code"
    Public ReadOnly Property Contract_Code() As System.String 
    Get
        Return m_Contract_Code
    End Get
    End Property

    Private m_Sub_Identity_Code As String = "Sub_Identity_Code"
    Public ReadOnly Property Sub_Identity_Code() As System.String 
    Get
        Return m_Sub_Identity_Code
    End Get
    End Property

    Private m_Contract_Name As String = "Contract_Name"
    Public ReadOnly Property Contract_Name() As System.String 
    Get
        Return m_Contract_Name
    End Get
    End Property

    Private m_Is_Use_Set As String = "Is_Use_Set"
    Public ReadOnly Property Is_Use_Set() As System.String 
    Get
        Return m_Is_Use_Set
    End Get
    End Property

    Private m_Upper_Amt As String = "Upper_Amt"
    Public ReadOnly Property Upper_Amt() As System.String 
    Get
        Return m_Upper_Amt
    End Get
    End Property

    Private m_Upper_Amt_Type_Id As String = "Upper_Amt_Type_Id"
    Public ReadOnly Property Upper_Amt_Type_Id() As System.String 
    Get
        Return m_Upper_Amt_Type_Id
    End Get
    End Property

    Private m_Check_Quota_Id As String = "Check_Quota_Id"
    Public ReadOnly Property Check_Quota_Id() As System.String 
    Get
        Return m_Check_Quota_Id
    End Get
    End Property

    Private m_Project_Director As String = "Project_Director"
    Public ReadOnly Property Project_Director() As System.String 
    Get
        Return m_Project_Director
    End Get
    End Property

    Private m_Drug_Code As String = "Drug_Code"
    Public ReadOnly Property Drug_Code() As System.String 
    Get
        Return m_Drug_Code
    End Get
    End Property

    Private m_Drug_Name As String = "Drug_Name"
    Public ReadOnly Property Drug_Name() As System.String 
    Get
        Return m_Drug_Name
    End Get
    End Property

    Private m_Drug_Committee_Sn As String = "Drug_Committee_Sn"
    Public ReadOnly Property Drug_Committee_Sn() As System.String 
    Get
        Return m_Drug_Committee_Sn
    End Get
    End Property

    Private m_Project_Effect_Date As String = "Project_Effect_Date"
    Public ReadOnly Property Project_Effect_Date() As System.String 
    Get
        Return m_Project_Effect_Date
    End Get
    End Property

    Private m_Project_End_Date As String = "Project_End_Date"
    Public ReadOnly Property Project_End_Date() As System.String 
    Get
        Return m_Project_End_Date
    End Get
    End Property

    Private m_Receipt_Title As String = "Receipt_Title"
    Public ReadOnly Property Receipt_Title() As System.String 
    Get
        Return m_Receipt_Title
    End Get
    End Property

    Private m_Contact_Name As String = "Contact_Name"
    Public ReadOnly Property Contact_Name() As System.String 
    Get
        Return m_Contact_Name
    End Get
    End Property

    Private m_Contact_Tel As String = "Contact_Tel"
    Public ReadOnly Property Contact_Tel() As System.String 
    Get
        Return m_Contact_Tel
    End Get
    End Property

    Private m_Contact_Tel_Mobile As String = "Contact_Tel_Mobile"
    Public ReadOnly Property Contact_Tel_Mobile() As System.String 
    Get
        Return m_Contact_Tel_Mobile
    End Get
    End Property

    Private m_Contact_Fax As String = "Contact_Fax"
    Public ReadOnly Property Contact_Fax() As System.String 
    Get
        Return m_Contact_Fax
    End Get
    End Property

    Private m_Contact_Email As String = "Contact_Email"
    Public ReadOnly Property Contact_Email() As System.String 
    Get
        Return m_Contact_Email
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

    Private m_Dis_Rate As String = "Dis_Rate"
    Public ReadOnly Property Dis_Rate() As System.String 
    Get
        Return m_Dis_Rate
    End Get
    End Property

    Private m_Add_Rate As String = "Add_Rate"
    Public ReadOnly Property Add_Rate() As System.String 
    Get
        Return m_Add_Rate
    End Get
    End Property

    Private m_Memo As String = "Memo"
    Public ReadOnly Property Memo() As System.String 
    Get
        Return m_Memo
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

    Private m_Contract_Type_Id As String = "Contract_Type_Id"
    Public ReadOnly Property Contract_Type_Id() As System.String 
    Get
        Return m_Contract_Type_Id
    End Get
    End Property

  End Class

End Class
