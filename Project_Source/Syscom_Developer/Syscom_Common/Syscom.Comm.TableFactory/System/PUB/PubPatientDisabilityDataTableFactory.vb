Imports System.Data.SqlClient
Public Class PubPatientDisabilityDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:52
    Public Shared ReadOnly tableName as String="PUB_Patient_Disability"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Chart_No", "Patient_Disability_No", "Effect_Date", "End_Date", "Patient_Disability_Memo",   _
             "Disability_Type_Id", "Disability_Degree_Id", "Disability_Card_Sn", "Create_User", "Create_Time",   _
             "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Int32", "System.DateTime", "System.DateTime", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, -1, -1, -1, 200,   _
             5, 5, 10, 10, -1,   _
             10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubPatientDisabilityDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Chart_No") = New Object
        dataRow("Patient_Disability_No") = New Object
        dataRow("Effect_Date") = New Object
        dataRow("End_Date") = New Object
        dataRow("Patient_Disability_Memo") = New Object
        dataRow("Disability_Type_Id") = New Object
        dataRow("Disability_Degree_Id") = New Object
        dataRow("Disability_Card_Sn") = New Object
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
            dt.Columns.Add("Patient_Disability_No")
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Patient_Disability_Memo")
            dt.Columns.Add("Disability_Type_Id")
            dt.Columns.Add("Disability_Degree_Id")
            dt.Columns.Add("Disability_Card_Sn")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Patient_Disability_No")
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
            dt.Columns.Add("Patient_Disability_No")
            dt.Columns("Patient_Disability_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Effect_Date")
            dt.Columns("Effect_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("End_Date")
            dt.Columns("End_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Patient_Disability_Memo")
            dt.Columns("Patient_Disability_Memo").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Disability_Type_Id")
            dt.Columns("Disability_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Disability_Degree_Id")
            dt.Columns("Disability_Degree_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Disability_Card_Sn")
            dt.Columns("Disability_Card_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Patient_Disability_No")
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
            dt.Columns.Add("Patient_Disability_No")
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Patient_Disability_Memo")
            dt.Columns.Add("Disability_Type_Id")
            dt.Columns.Add("Disability_Degree_Id")
            dt.Columns.Add("Disability_Card_Sn")
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

  Class PUBPatientDisabilityPt
    Private m_Chart_No As String = "Chart_No"
    Public ReadOnly Property Chart_No() As System.String 
    Get
        Return m_Chart_No
    End Get
    End Property

    Private m_Patient_Disability_No As String = "Patient_Disability_No"
    Public ReadOnly Property Patient_Disability_No() As System.String 
    Get
        Return m_Patient_Disability_No
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

    Private m_Patient_Disability_Memo As String = "Patient_Disability_Memo"
    Public ReadOnly Property Patient_Disability_Memo() As System.String 
    Get
        Return m_Patient_Disability_Memo
    End Get
    End Property

    Private m_Disability_Type_Id As String = "Disability_Type_Id"
    Public ReadOnly Property Disability_Type_Id() As System.String 
    Get
        Return m_Disability_Type_Id
    End Get
    End Property

    Private m_Disability_Degree_Id As String = "Disability_Degree_Id"
    Public ReadOnly Property Disability_Degree_Id() As System.String 
    Get
        Return m_Disability_Degree_Id
    End Get
    End Property

    Private m_Disability_Card_Sn As String = "Disability_Card_Sn"
    Public ReadOnly Property Disability_Card_Sn() As System.String 
    Get
        Return m_Disability_Card_Sn
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
