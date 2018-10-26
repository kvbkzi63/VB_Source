Imports System.Data.SqlClient
Public Class PubDoctorDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:48
    Public Shared ReadOnly tableName as String="PUB_Doctor"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Employee_Code", "Doctor_Code", "Level_Id", "Dept_Code", "Announce_Effect_Date",   _
             "Announce_End_Date", "Parttime_Hosp", "Create_User", "Create_Time", "Modified_User",   _
             "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.DateTime",   _
             "System.DateTime", "System.String", "System.String", "System.DateTime", "System.String",   _
             "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 10, 5, 6, -1,   _
             -1, 30, 10, -1, 10,   _
             -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubDoctorDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Employee_Code") = New Object
        dataRow("Doctor_Code") = New Object
        dataRow("Level_Id") = New Object
        dataRow("Dept_Code") = New Object
        dataRow("Announce_Effect_Date") = New Object
        dataRow("Announce_End_Date") = New Object
        dataRow("Parttime_Hosp") = New Object
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
            dt.Columns.Add("Employee_Code")
            dt.Columns.Add("Doctor_Code")
            dt.Columns.Add("Level_Id")
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Announce_Effect_Date")
            dt.Columns.Add("Announce_End_Date")
            dt.Columns.Add("Parttime_Hosp")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Employee_Code")
            pkColArray(1) = dt.Columns("Doctor_Code")
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
            dt.Columns.Add("Employee_Code")
            dt.Columns("Employee_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Doctor_Code")
            dt.Columns("Doctor_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Level_Id")
            dt.Columns("Level_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dept_Code")
            dt.Columns("Dept_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Announce_Effect_Date")
            dt.Columns("Announce_Effect_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Announce_End_Date")
            dt.Columns("Announce_End_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Parttime_Hosp")
            dt.Columns("Parttime_Hosp").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Employee_Code")
            pkColArray(1) = dt.Columns("Doctor_Code")
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
            dt.Columns.Add("Employee_Code")
            dt.Columns.Add("Doctor_Code")
            dt.Columns.Add("Level_Id")
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Announce_Effect_Date")
            dt.Columns.Add("Announce_End_Date")
            dt.Columns.Add("Parttime_Hosp")
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

  Class PUBDoctorPt
    Private m_Employee_Code As String = "Employee_Code"
    Public ReadOnly Property Employee_Code() As System.String 
    Get
        Return m_Employee_Code
    End Get
    End Property

    Private m_Doctor_Code As String = "Doctor_Code"
    Public ReadOnly Property Doctor_Code() As System.String 
    Get
        Return m_Doctor_Code
    End Get
    End Property

    Private m_Level_Id As String = "Level_Id"
    Public ReadOnly Property Level_Id() As System.String 
    Get
        Return m_Level_Id
    End Get
    End Property

    Private m_Dept_Code As String = "Dept_Code"
    Public ReadOnly Property Dept_Code() As System.String 
    Get
        Return m_Dept_Code
    End Get
    End Property

    Private m_Announce_Effect_Date As String = "Announce_Effect_Date"
    Public ReadOnly Property Announce_Effect_Date() As System.String 
    Get
        Return m_Announce_Effect_Date
    End Get
    End Property

    Private m_Announce_End_Date As String = "Announce_End_Date"
    Public ReadOnly Property Announce_End_Date() As System.String 
    Get
        Return m_Announce_End_Date
    End Get
    End Property

    Private m_Parttime_Hosp As String = "Parttime_Hosp"
    Public ReadOnly Property Parttime_Hosp() As System.String 
    Get
        Return m_Parttime_Hosp
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
