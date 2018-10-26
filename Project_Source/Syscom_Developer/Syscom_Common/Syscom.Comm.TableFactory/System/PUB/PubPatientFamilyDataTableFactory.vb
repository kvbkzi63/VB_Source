Imports System.Data.SqlClient
Public Class PubPatientFamilyDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:52
    Public Shared ReadOnly tableName as String="PUB_Patient_Family"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Chart_No", "Patient_Family_No", "Title_Id", "Family_Name", "Idno_Type_Id",   _
             "Idno", "Family_Birth_Date", "Sex_Id", "State_Id", "Create_User",   _
             "Create_Time", "Modified_User", "Modified_Time", "Dc"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Int32", "System.String", "System.String", "System.String",   _
             "System.String", "System.DateTime", "System.String", "System.String", "System.String",   _
             "System.DateTime", "System.String", "System.DateTime", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, -1, 5, 50, 5,   _
             20, -1, 5, 5, 10,   _
             -1, 10, -1, 1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubPatientFamilyDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Chart_No") = New Object
        dataRow("Patient_Family_No") = New Object
        dataRow("Title_Id") = New Object
        dataRow("Family_Name") = New Object
        dataRow("Idno_Type_Id") = New Object
        dataRow("Idno") = New Object
        dataRow("Family_Birth_Date") = New Object
        dataRow("Sex_Id") = New Object
        dataRow("State_Id") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Dc") = New Object
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
            dt.Columns.Add("Patient_Family_No")
            dt.Columns.Add("Title_Id")
            dt.Columns.Add("Family_Name")
            dt.Columns.Add("Idno_Type_Id")
            dt.Columns.Add("Idno")
            dt.Columns.Add("Family_Birth_Date")
            dt.Columns.Add("Sex_Id")
            dt.Columns.Add("State_Id")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Dc")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Patient_Family_No")
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
            dt.Columns.Add("Patient_Family_No")
            dt.Columns("Patient_Family_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Title_Id")
            dt.Columns("Title_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Family_Name")
            dt.Columns("Family_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Idno_Type_Id")
            dt.Columns("Idno_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Idno")
            dt.Columns("Idno").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Family_Birth_Date")
            dt.Columns("Family_Birth_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Sex_Id")
            dt.Columns("Sex_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("State_Id")
            dt.Columns("State_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Dc")
            dt.Columns("Dc").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Patient_Family_No")
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
            dt.Columns.Add("Patient_Family_No")
            dt.Columns.Add("Title_Id")
            dt.Columns.Add("Family_Name")
            dt.Columns.Add("Idno_Type_Id")
            dt.Columns.Add("Idno")
            dt.Columns.Add("Family_Birth_Date")
            dt.Columns.Add("Sex_Id")
            dt.Columns.Add("State_Id")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Dc")
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

  Class PUBPatientFamilyPt
    Private m_Chart_No As String = "Chart_No"
    Public ReadOnly Property Chart_No() As System.String 
    Get
        Return m_Chart_No
    End Get
    End Property

    Private m_Patient_Family_No As String = "Patient_Family_No"
    Public ReadOnly Property Patient_Family_No() As System.String 
    Get
        Return m_Patient_Family_No
    End Get
    End Property

    Private m_Title_Id As String = "Title_Id"
    Public ReadOnly Property Title_Id() As System.String 
    Get
        Return m_Title_Id
    End Get
    End Property

    Private m_Family_Name As String = "Family_Name"
    Public ReadOnly Property Family_Name() As System.String 
    Get
        Return m_Family_Name
    End Get
    End Property

    Private m_Idno_Type_Id As String = "Idno_Type_Id"
    Public ReadOnly Property Idno_Type_Id() As System.String 
    Get
        Return m_Idno_Type_Id
    End Get
    End Property

    Private m_Idno As String = "Idno"
    Public ReadOnly Property Idno() As System.String 
    Get
        Return m_Idno
    End Get
    End Property

    Private m_Family_Birth_Date As String = "Family_Birth_Date"
    Public ReadOnly Property Family_Birth_Date() As System.String 
    Get
        Return m_Family_Birth_Date
    End Get
    End Property

    Private m_Sex_Id As String = "Sex_Id"
    Public ReadOnly Property Sex_Id() As System.String 
    Get
        Return m_Sex_Id
    End Get
    End Property

    Private m_State_Id As String = "State_Id"
    Public ReadOnly Property State_Id() As System.String 
    Get
        Return m_State_Id
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

    Private m_Dc As String = "Dc"
    Public ReadOnly Property Dc() As System.String 
    Get
        Return m_Dc
    End Get
    End Property

  End Class

End Class
