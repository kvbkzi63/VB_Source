Imports System.Data.SqlClient
Public Class PubPatientToccDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/10/27 下午 02:40:30
    Public Shared ReadOnly tableName as String="PUB_Patient_TOCC"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Chart_No", "Idno", "Medical_Date", "Travel_History", "Travel_Description",   _
             "Occupation", "Occupation_Description", "Contact", "Contact_Description", "Cluster",   _
             "Cluster_Description", "Create_User", "Create_Time", "Modified_User", "Modified_Time"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.DateTime", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 20, -1, 1, 50,   _
             1, 50, 1, 50, 1,   _
             50, 10, -1, 10, -1  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubPatientToccDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Chart_No") = New Object
        dataRow("Idno") = New Object
        dataRow("Medical_Date") = New Object
        dataRow("Travel_History") = New Object
        dataRow("Travel_Description") = New Object
        dataRow("Occupation") = New Object
        dataRow("Occupation_Description") = New Object
        dataRow("Contact") = New Object
        dataRow("Contact_Description") = New Object
        dataRow("Cluster") = New Object
        dataRow("Cluster_Description") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
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
            dt.Columns.Add("Idno")
            dt.Columns.Add("Medical_Date")
            dt.Columns.Add("Travel_History")
            dt.Columns.Add("Travel_Description")
            dt.Columns.Add("Occupation")
            dt.Columns.Add("Occupation_Description")
            dt.Columns.Add("Contact")
            dt.Columns.Add("Contact_Description")
            dt.Columns.Add("Cluster")
            dt.Columns.Add("Cluster_Description")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Idno")
            pkColArray(2) = dt.Columns("Medical_Date")
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
            dt.Columns.Add("Idno")
            dt.Columns("Idno").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Medical_Date")
            dt.Columns("Medical_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Travel_History")
            dt.Columns("Travel_History").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Travel_Description")
            dt.Columns("Travel_Description").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Occupation")
            dt.Columns("Occupation").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Occupation_Description")
            dt.Columns("Occupation_Description").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact")
            dt.Columns("Contact").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Description")
            dt.Columns("Contact_Description").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cluster")
            dt.Columns("Cluster").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cluster_Description")
            dt.Columns("Cluster_Description").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Idno")
            pkColArray(2) = dt.Columns("Medical_Date")
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
            dt.Columns.Add("Idno")
            dt.Columns.Add("Medical_Date")
            dt.Columns.Add("Travel_History")
            dt.Columns.Add("Travel_Description")
            dt.Columns.Add("Occupation")
            dt.Columns.Add("Occupation_Description")
            dt.Columns.Add("Contact")
            dt.Columns.Add("Contact_Description")
            dt.Columns.Add("Cluster")
            dt.Columns.Add("Cluster_Description")
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

  Class PUBPatientTOCCPt
    Private m_Chart_No As String = "Chart_No"
    Public ReadOnly Property Chart_No() As System.String 
    Get
        Return m_Chart_No
    End Get
    End Property

    Private m_Idno As String = "Idno"
    Public ReadOnly Property Idno() As System.String 
    Get
        Return m_Idno
    End Get
    End Property

    Private m_Medical_Date As String = "Medical_Date"
    Public ReadOnly Property Medical_Date() As System.String 
    Get
        Return m_Medical_Date
    End Get
    End Property

    Private m_Travel_History As String = "Travel_History"
    Public ReadOnly Property Travel_History() As System.String 
    Get
        Return m_Travel_History
    End Get
    End Property

    Private m_Travel_Description As String = "Travel_Description"
    Public ReadOnly Property Travel_Description() As System.String 
    Get
        Return m_Travel_Description
    End Get
    End Property

    Private m_Occupation As String = "Occupation"
    Public ReadOnly Property Occupation() As System.String 
    Get
        Return m_Occupation
    End Get
    End Property

    Private m_Occupation_Description As String = "Occupation_Description"
    Public ReadOnly Property Occupation_Description() As System.String 
    Get
        Return m_Occupation_Description
    End Get
    End Property

    Private m_Contact As String = "Contact"
    Public ReadOnly Property Contact() As System.String 
    Get
        Return m_Contact
    End Get
    End Property

    Private m_Contact_Description As String = "Contact_Description"
    Public ReadOnly Property Contact_Description() As System.String 
    Get
        Return m_Contact_Description
    End Get
    End Property

    Private m_Cluster As String = "Cluster"
    Public ReadOnly Property Cluster() As System.String 
    Get
        Return m_Cluster
    End Get
    End Property

    Private m_Cluster_Description As String = "Cluster_Description"
    Public ReadOnly Property Cluster_Description() As System.String 
    Get
        Return m_Cluster_Description
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
