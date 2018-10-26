Imports System.Data.SqlClient
Public Class JobQaTestRecordDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2018/3/9 上午 09:16:24
    Public Shared ReadOnly tableName as String="Job_QA_Test_Record"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Version_Id", "Project_Id", "Hospital_Code", "Deploy_Kind", "Deploy_Date",   _
             "Test_Version", "Version_Desc", "Total_Amount", "Total_UnClose", "Total_Closed",   _
             "Total_UnTest", "Urgent_UnClose", "Urgent_Closed", "Important_UnClose", "Important_Closed",   _
             "Normal_UnClose", "Normal_Closed", "Close_Flag", "Create_User", "Create_Time",   _
             "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.DateTime",   _
             "System.Int32", "System.String", "System.Int32", "System.Int32", "System.Int32",   _
             "System.Int32", "System.Int32", "System.Int32", "System.Int32", "System.Int32",   _
             "System.Int32", "System.Int32", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             20, 20, 20, 1, -1,   _
             -1, 500, -1, -1, -1,   _
             -1, -1, -1, -1, -1,   _
             -1, -1, 1, 10, -1,   _
             10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = JobQaTestRecordDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Version_Id") = New Object
        dataRow("Project_Id") = New Object
        dataRow("Hospital_Code") = New Object
        dataRow("Deploy_Kind") = New Object
        dataRow("Deploy_Date") = New Object
        dataRow("Test_Version") = New Object
        dataRow("Version_Desc") = New Object
        dataRow("Total_Amount") = New Object
        dataRow("Total_UnClose") = New Object
        dataRow("Total_Closed") = New Object
        dataRow("Total_UnTest") = New Object
        dataRow("Urgent_UnClose") = New Object
        dataRow("Urgent_Closed") = New Object
        dataRow("Important_UnClose") = New Object
        dataRow("Important_Closed") = New Object
        dataRow("Normal_UnClose") = New Object
        dataRow("Normal_Closed") = New Object
        dataRow("Close_Flag") = New Object
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
            dt.Columns.Add("Version_Id")
            dt.Columns.Add("Project_Id")
            dt.Columns.Add("Hospital_Code")
            dt.Columns.Add("Deploy_Kind")
            dt.Columns.Add("Deploy_Date")
            dt.Columns.Add("Test_Version")
            dt.Columns.Add("Version_Desc")
            dt.Columns.Add("Total_Amount")
            dt.Columns.Add("Total_UnClose")
            dt.Columns.Add("Total_Closed")
            dt.Columns.Add("Total_UnTest")
            dt.Columns.Add("Urgent_UnClose")
            dt.Columns.Add("Urgent_Closed")
            dt.Columns.Add("Important_UnClose")
            dt.Columns.Add("Important_Closed")
            dt.Columns.Add("Normal_UnClose")
            dt.Columns.Add("Normal_Closed")
            dt.Columns.Add("Close_Flag")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Version_Id")
            pkColArray(1) = dt.Columns("Project_Id")
            pkColArray(2) = dt.Columns("Hospital_Code")
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
            dt.Columns.Add("Version_Id")
            dt.Columns("Version_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Project_Id")
            dt.Columns("Project_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Hospital_Code")
            dt.Columns("Hospital_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Deploy_Kind")
            dt.Columns("Deploy_Kind").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Deploy_Date")
            dt.Columns("Deploy_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Test_Version")
            dt.Columns("Test_Version").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Version_Desc")
            dt.Columns("Version_Desc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Total_Amount")
            dt.Columns("Total_Amount").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Total_UnClose")
            dt.Columns("Total_UnClose").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Total_Closed")
            dt.Columns("Total_Closed").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Total_UnTest")
            dt.Columns("Total_UnTest").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Urgent_UnClose")
            dt.Columns("Urgent_UnClose").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Urgent_Closed")
            dt.Columns("Urgent_Closed").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Important_UnClose")
            dt.Columns("Important_UnClose").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Important_Closed")
            dt.Columns("Important_Closed").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Normal_UnClose")
            dt.Columns("Normal_UnClose").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Normal_Closed")
            dt.Columns("Normal_Closed").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Close_Flag")
            dt.Columns("Close_Flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Version_Id")
            pkColArray(1) = dt.Columns("Project_Id")
            pkColArray(2) = dt.Columns("Hospital_Code")
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
            dt.Columns.Add("Version_Id")
            dt.Columns.Add("Project_Id")
            dt.Columns.Add("Hospital_Code")
            dt.Columns.Add("Deploy_Kind")
            dt.Columns.Add("Deploy_Date")
            dt.Columns.Add("Test_Version")
            dt.Columns.Add("Version_Desc")
            dt.Columns.Add("Total_Amount")
            dt.Columns.Add("Total_UnClose")
            dt.Columns.Add("Total_Closed")
            dt.Columns.Add("Total_UnTest")
            dt.Columns.Add("Urgent_UnClose")
            dt.Columns.Add("Urgent_Closed")
            dt.Columns.Add("Important_UnClose")
            dt.Columns.Add("Important_Closed")
            dt.Columns.Add("Normal_UnClose")
            dt.Columns.Add("Normal_Closed")
            dt.Columns.Add("Close_Flag")
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

  Class JobQATestRecordPt
    Private m_Version_Id As String = "Version_Id"
    Public ReadOnly Property Version_Id() As System.String 
    Get
        Return m_Version_Id
    End Get
    End Property

    Private m_Project_Id As String = "Project_Id"
    Public ReadOnly Property Project_Id() As System.String 
    Get
        Return m_Project_Id
    End Get
    End Property

    Private m_Hospital_Code As String = "Hospital_Code"
    Public ReadOnly Property Hospital_Code() As System.String 
    Get
        Return m_Hospital_Code
    End Get
    End Property

    Private m_Deploy_Kind As String = "Deploy_Kind"
    Public ReadOnly Property Deploy_Kind() As System.String 
    Get
        Return m_Deploy_Kind
    End Get
    End Property

    Private m_Deploy_Date As String = "Deploy_Date"
    Public ReadOnly Property Deploy_Date() As System.String 
    Get
        Return m_Deploy_Date
    End Get
    End Property

    Private m_Test_Version As String = "Test_Version"
    Public ReadOnly Property Test_Version() As System.String 
    Get
        Return m_Test_Version
    End Get
    End Property

    Private m_Version_Desc As String = "Version_Desc"
    Public ReadOnly Property Version_Desc() As System.String 
    Get
        Return m_Version_Desc
    End Get
    End Property

    Private m_Total_Amount As String = "Total_Amount"
    Public ReadOnly Property Total_Amount() As System.String 
    Get
        Return m_Total_Amount
    End Get
    End Property

    Private m_Total_UnClose As String = "Total_UnClose"
    Public ReadOnly Property Total_UnClose() As System.String 
    Get
        Return m_Total_UnClose
    End Get
    End Property

    Private m_Total_Closed As String = "Total_Closed"
    Public ReadOnly Property Total_Closed() As System.String 
    Get
        Return m_Total_Closed
    End Get
    End Property

    Private m_Total_UnTest As String = "Total_UnTest"
    Public ReadOnly Property Total_UnTest() As System.String 
    Get
        Return m_Total_UnTest
    End Get
    End Property

    Private m_Urgent_UnClose As String = "Urgent_UnClose"
    Public ReadOnly Property Urgent_UnClose() As System.String 
    Get
        Return m_Urgent_UnClose
    End Get
    End Property

    Private m_Urgent_Closed As String = "Urgent_Closed"
    Public ReadOnly Property Urgent_Closed() As System.String 
    Get
        Return m_Urgent_Closed
    End Get
    End Property

    Private m_Important_UnClose As String = "Important_UnClose"
    Public ReadOnly Property Important_UnClose() As System.String 
    Get
        Return m_Important_UnClose
    End Get
    End Property

    Private m_Important_Closed As String = "Important_Closed"
    Public ReadOnly Property Important_Closed() As System.String 
    Get
        Return m_Important_Closed
    End Get
    End Property

    Private m_Normal_UnClose As String = "Normal_UnClose"
    Public ReadOnly Property Normal_UnClose() As System.String 
    Get
        Return m_Normal_UnClose
    End Get
    End Property

    Private m_Normal_Closed As String = "Normal_Closed"
    Public ReadOnly Property Normal_Closed() As System.String 
    Get
        Return m_Normal_Closed
    End Get
    End Property

    Private m_Close_Flag As String = "Close_Flag"
    Public ReadOnly Property Close_Flag() As System.String 
    Get
        Return m_Close_Flag
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
  Class DBColumnName 
    Private Shared ReadOnly m_Version_Id As String = "Version_Id"
    Public Shared ReadOnly Property Version_Id() As System.String 
    Get
        Return m_Version_Id
    End Get
    End Property

    Private Shared ReadOnly m_Project_Id As String = "Project_Id"
    Public Shared ReadOnly Property Project_Id() As System.String 
    Get
        Return m_Project_Id
    End Get
    End Property

    Private Shared ReadOnly m_Hospital_Code As String = "Hospital_Code"
    Public Shared ReadOnly Property Hospital_Code() As System.String 
    Get
        Return m_Hospital_Code
    End Get
    End Property

    Private Shared ReadOnly m_Deploy_Kind As String = "Deploy_Kind"
    Public Shared ReadOnly Property Deploy_Kind() As System.String 
    Get
        Return m_Deploy_Kind
    End Get
    End Property

    Private Shared ReadOnly m_Deploy_Date As String = "Deploy_Date"
    Public Shared ReadOnly Property Deploy_Date() As System.String 
    Get
        Return m_Deploy_Date
    End Get
    End Property

    Private Shared ReadOnly m_Test_Version As String = "Test_Version"
    Public Shared ReadOnly Property Test_Version() As System.String 
    Get
        Return m_Test_Version
    End Get
    End Property

    Private Shared ReadOnly m_Version_Desc As String = "Version_Desc"
    Public Shared ReadOnly Property Version_Desc() As System.String 
    Get
        Return m_Version_Desc
    End Get
    End Property

    Private Shared ReadOnly m_Total_Amount As String = "Total_Amount"
    Public Shared ReadOnly Property Total_Amount() As System.String 
    Get
        Return m_Total_Amount
    End Get
    End Property

    Private Shared ReadOnly m_Total_UnClose As String = "Total_UnClose"
    Public Shared ReadOnly Property Total_UnClose() As System.String 
    Get
        Return m_Total_UnClose
    End Get
    End Property

    Private Shared ReadOnly m_Total_Closed As String = "Total_Closed"
    Public Shared ReadOnly Property Total_Closed() As System.String 
    Get
        Return m_Total_Closed
    End Get
    End Property

    Private Shared ReadOnly m_Total_UnTest As String = "Total_UnTest"
    Public Shared ReadOnly Property Total_UnTest() As System.String 
    Get
        Return m_Total_UnTest
    End Get
    End Property

    Private Shared ReadOnly m_Urgent_UnClose As String = "Urgent_UnClose"
    Public Shared ReadOnly Property Urgent_UnClose() As System.String 
    Get
        Return m_Urgent_UnClose
    End Get
    End Property

    Private Shared ReadOnly m_Urgent_Closed As String = "Urgent_Closed"
    Public Shared ReadOnly Property Urgent_Closed() As System.String 
    Get
        Return m_Urgent_Closed
    End Get
    End Property

    Private Shared ReadOnly m_Important_UnClose As String = "Important_UnClose"
    Public Shared ReadOnly Property Important_UnClose() As System.String 
    Get
        Return m_Important_UnClose
    End Get
    End Property

    Private Shared ReadOnly m_Important_Closed As String = "Important_Closed"
    Public Shared ReadOnly Property Important_Closed() As System.String 
    Get
        Return m_Important_Closed
    End Get
    End Property

    Private Shared ReadOnly m_Normal_UnClose As String = "Normal_UnClose"
    Public Shared ReadOnly Property Normal_UnClose() As System.String 
    Get
        Return m_Normal_UnClose
    End Get
    End Property

    Private Shared ReadOnly m_Normal_Closed As String = "Normal_Closed"
    Public Shared ReadOnly Property Normal_Closed() As System.String 
    Get
        Return m_Normal_Closed
    End Get
    End Property

    Private Shared ReadOnly m_Close_Flag As String = "Close_Flag"
    Public Shared ReadOnly Property Close_Flag() As System.String 
    Get
        Return m_Close_Flag
    End Get
    End Property

    Private Shared ReadOnly m_Create_User As String = "Create_User"
    Public Shared ReadOnly Property Create_User() As System.String 
    Get
        Return m_Create_User
    End Get
    End Property

    Private Shared ReadOnly m_Create_Time As String = "Create_Time"
    Public Shared ReadOnly Property Create_Time() As System.String 
    Get
        Return m_Create_Time
    End Get
    End Property

    Private Shared ReadOnly m_Modified_User As String = "Modified_User"
    Public Shared ReadOnly Property Modified_User() As System.String 
    Get
        Return m_Modified_User
    End Get
    End Property

    Private Shared ReadOnly m_Modified_Time As String = "Modified_Time"
    Public Shared ReadOnly Property Modified_Time() As System.String 
    Get
        Return m_Modified_Time
    End Get
    End Property

  End Class

End Class
