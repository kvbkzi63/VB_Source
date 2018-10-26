Imports System.Data.SqlClient
Public Class JobServiceRecordDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/11/15 下午 02:36:02
    Public Shared ReadOnly tableName as String="JOB_Service_Record"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Issue_Id", "JOB_Code", "Project_Id", "System_Code", "Function_Code",   _
             "Receive_DateTime", "Issue_Source", "Issue_Description", "Issue_Classify", "Issue_Status",   _
             "Contact_User", "Contact_Way", "Contact_Note", "Processing_Approach", "Processing_Employee_Code",   _
             "Processing_Cost", "Finish_Date", "Estimated_Finish_Date", "Note", "Att_FID",   _
             "Create_User", "Create_Time", "Modified_User", "Modified_Time", "Hospital_Code",   _
             "Cancel", "Cancel_Reason", "Cancel_Time", "Cancel_User"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.Int32", "System.String", "System.String", "System.String", "System.String",   _
             "System.DateTime", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.DateTime", "System.DateTime", "System.String", "System.String",   _
             "System.String", "System.DateTime", "System.String", "System.DateTime", "System.String",   _
             "System.String", "System.String", "System.DateTime", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             -1, 200, 10, 100, 100,   _
             -1, 1, 1000, 1, 1,   _
             50, 1, 50, 100, 10,   _
             20, -1, -1, 1000, 200,   _
             10, -1, 10, -1, 20,   _
             1, 100, -1, 10}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = JobServiceRecordDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Issue_Id") = New Object
        dataRow("JOB_Code") = New Object
        dataRow("Project_Id") = New Object
        dataRow("System_Code") = New Object
        dataRow("Function_Code") = New Object
        dataRow("Receive_DateTime") = New Object
        dataRow("Issue_Source") = New Object
        dataRow("Issue_Description") = New Object
        dataRow("Issue_Classify") = New Object
        dataRow("Issue_Status") = New Object
        dataRow("Contact_User") = New Object
        dataRow("Contact_Way") = New Object
        dataRow("Contact_Note") = New Object
        dataRow("Processing_Approach") = New Object
        dataRow("Processing_Employee_Code") = New Object
        dataRow("Processing_Cost") = New Object
        dataRow("Finish_Date") = New Object
        dataRow("Estimated_Finish_Date") = New Object
        dataRow("Note") = New Object
        dataRow("Att_FID") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Hospital_Code") = New Object
        dataRow("Cancel") = New Object
        dataRow("Cancel_Reason") = New Object
        dataRow("Cancel_Time") = New Object
        dataRow("Cancel_User") = New Object
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
            dt.Columns.Add("Issue_Id")
            dt.Columns.Add("JOB_Code")
            dt.Columns.Add("Project_Id")
            dt.Columns.Add("System_Code")
            dt.Columns.Add("Function_Code")
            dt.Columns.Add("Receive_DateTime")
            dt.Columns.Add("Issue_Source")
            dt.Columns.Add("Issue_Description")
            dt.Columns.Add("Issue_Classify")
            dt.Columns.Add("Issue_Status")
            dt.Columns.Add("Contact_User")
            dt.Columns.Add("Contact_Way")
            dt.Columns.Add("Contact_Note")
            dt.Columns.Add("Processing_Approach")
            dt.Columns.Add("Processing_Employee_Code")
            dt.Columns.Add("Processing_Cost")
            dt.Columns.Add("Finish_Date")
            dt.Columns.Add("Estimated_Finish_Date")
            dt.Columns.Add("Note")
            dt.Columns.Add("Att_FID")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Hospital_Code")
            dt.Columns.Add("Cancel")
            dt.Columns.Add("Cancel_Reason")
            dt.Columns.Add("Cancel_Time")
            dt.Columns.Add("Cancel_User")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Issue_Id")
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
            dt.Columns.Add("Issue_Id")
            dt.Columns("Issue_Id").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("JOB_Code")
            dt.Columns("JOB_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Project_Id")
            dt.Columns("Project_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("System_Code")
            dt.Columns("System_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Function_Code")
            dt.Columns("Function_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Receive_DateTime")
            dt.Columns("Receive_DateTime").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Issue_Source")
            dt.Columns("Issue_Source").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Issue_Description")
            dt.Columns("Issue_Description").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Issue_Classify")
            dt.Columns("Issue_Classify").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Issue_Status")
            dt.Columns("Issue_Status").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_User")
            dt.Columns("Contact_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Way")
            dt.Columns("Contact_Way").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Contact_Note")
            dt.Columns("Contact_Note").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Processing_Approach")
            dt.Columns("Processing_Approach").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Processing_Employee_Code")
            dt.Columns("Processing_Employee_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Processing_Cost")
            dt.Columns("Processing_Cost").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Finish_Date")
            dt.Columns("Finish_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Estimated_Finish_Date")
            dt.Columns("Estimated_Finish_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Note")
            dt.Columns("Note").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Att_FID")
            dt.Columns("Att_FID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Hospital_Code")
            dt.Columns("Hospital_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cancel")
            dt.Columns("Cancel").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cancel_Reason")
            dt.Columns("Cancel_Reason").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cancel_Time")
            dt.Columns("Cancel_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Cancel_User")
            dt.Columns("Cancel_User").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Issue_Id")
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
            dt.Columns.Add("Issue_Id")
            dt.Columns.Add("JOB_Code")
            dt.Columns.Add("Project_Id")
            dt.Columns.Add("System_Code")
            dt.Columns.Add("Function_Code")
            dt.Columns.Add("Receive_DateTime")
            dt.Columns.Add("Issue_Source")
            dt.Columns.Add("Issue_Description")
            dt.Columns.Add("Issue_Classify")
            dt.Columns.Add("Issue_Status")
            dt.Columns.Add("Contact_User")
            dt.Columns.Add("Contact_Way")
            dt.Columns.Add("Contact_Note")
            dt.Columns.Add("Processing_Approach")
            dt.Columns.Add("Processing_Employee_Code")
            dt.Columns.Add("Processing_Cost")
            dt.Columns.Add("Finish_Date")
            dt.Columns.Add("Estimated_Finish_Date")
            dt.Columns.Add("Note")
            dt.Columns.Add("Att_FID")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Hospital_Code")
            dt.Columns.Add("Cancel")
            dt.Columns.Add("Cancel_Reason")
            dt.Columns.Add("Cancel_Time")
            dt.Columns.Add("Cancel_User")
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

  Class JOBServiceRecordPt
    Private m_Issue_Id As String = "Issue_Id"
    Public ReadOnly Property Issue_Id() As System.String 
    Get
        Return m_Issue_Id
    End Get
    End Property

    Private m_JOB_Code As String = "JOB_Code"
    Public ReadOnly Property JOB_Code() As System.String 
    Get
        Return m_JOB_Code
    End Get
    End Property

    Private m_Project_Id As String = "Project_Id"
    Public ReadOnly Property Project_Id() As System.String 
    Get
        Return m_Project_Id
    End Get
    End Property

    Private m_System_Code As String = "System_Code"
    Public ReadOnly Property System_Code() As System.String 
    Get
        Return m_System_Code
    End Get
    End Property

    Private m_Function_Code As String = "Function_Code"
    Public ReadOnly Property Function_Code() As System.String 
    Get
        Return m_Function_Code
    End Get
    End Property

    Private m_Receive_DateTime As String = "Receive_DateTime"
    Public ReadOnly Property Receive_DateTime() As System.String 
    Get
        Return m_Receive_DateTime
    End Get
    End Property

    Private m_Issue_Source As String = "Issue_Source"
    Public ReadOnly Property Issue_Source() As System.String 
    Get
        Return m_Issue_Source
    End Get
    End Property

    Private m_Issue_Description As String = "Issue_Description"
    Public ReadOnly Property Issue_Description() As System.String 
    Get
        Return m_Issue_Description
    End Get
    End Property

    Private m_Issue_Classify As String = "Issue_Classify"
    Public ReadOnly Property Issue_Classify() As System.String 
    Get
        Return m_Issue_Classify
    End Get
    End Property

    Private m_Issue_Status As String = "Issue_Status"
    Public ReadOnly Property Issue_Status() As System.String 
    Get
        Return m_Issue_Status
    End Get
    End Property

    Private m_Contact_User As String = "Contact_User"
    Public ReadOnly Property Contact_User() As System.String 
    Get
        Return m_Contact_User
    End Get
    End Property

    Private m_Contact_Way As String = "Contact_Way"
    Public ReadOnly Property Contact_Way() As System.String 
    Get
        Return m_Contact_Way
    End Get
    End Property

    Private m_Contact_Note As String = "Contact_Note"
    Public ReadOnly Property Contact_Note() As System.String 
    Get
        Return m_Contact_Note
    End Get
    End Property

    Private m_Processing_Approach As String = "Processing_Approach"
    Public ReadOnly Property Processing_Approach() As System.String 
    Get
        Return m_Processing_Approach
    End Get
    End Property

    Private m_Processing_Employee_Code As String = "Processing_Employee_Code"
    Public ReadOnly Property Processing_Employee_Code() As System.String 
    Get
        Return m_Processing_Employee_Code
    End Get
    End Property

    Private m_Processing_Cost As String = "Processing_Cost"
    Public ReadOnly Property Processing_Cost() As System.String 
    Get
        Return m_Processing_Cost
    End Get
    End Property

    Private m_Finish_Date As String = "Finish_Date"
    Public ReadOnly Property Finish_Date() As System.String 
    Get
        Return m_Finish_Date
    End Get
    End Property

    Private m_Estimated_Finish_Date As String = "Estimated_Finish_Date"
    Public ReadOnly Property Estimated_Finish_Date() As System.String 
    Get
        Return m_Estimated_Finish_Date
    End Get
    End Property

    Private m_Note As String = "Note"
    Public ReadOnly Property Note() As System.String 
    Get
        Return m_Note
    End Get
    End Property

    Private m_Att_FID As String = "Att_FID"
    Public ReadOnly Property Att_FID() As System.String 
    Get
        Return m_Att_FID
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

    Private m_Hospital_Code As String = "Hospital_Code"
    Public ReadOnly Property Hospital_Code() As System.String 
    Get
        Return m_Hospital_Code
    End Get
    End Property

    Private m_Cancel As String = "Cancel"
    Public ReadOnly Property Cancel() As System.String 
    Get
        Return m_Cancel
    End Get
    End Property

    Private m_Cancel_Reason As String = "Cancel_Reason"
    Public ReadOnly Property Cancel_Reason() As System.String 
    Get
        Return m_Cancel_Reason
    End Get
    End Property

    Private m_Cancel_Time As String = "Cancel_Time"
    Public ReadOnly Property Cancel_Time() As System.String 
    Get
        Return m_Cancel_Time
    End Get
    End Property

    Private m_Cancel_User As String = "Cancel_User"
    Public ReadOnly Property Cancel_User() As System.String 
    Get
        Return m_Cancel_User
    End Get
    End Property

  End Class
  Class DBColumnName 
    Private Shared ReadOnly m_Issue_Id As String = "Issue_Id"
    Public Shared ReadOnly Property Issue_Id() As System.String 
    Get
        Return m_Issue_Id
    End Get
    End Property

    Private Shared ReadOnly m_JOB_Code As String = "JOB_Code"
    Public Shared ReadOnly Property JOB_Code() As System.String 
    Get
        Return m_JOB_Code
    End Get
    End Property

    Private Shared ReadOnly m_Project_Id As String = "Project_Id"
    Public Shared ReadOnly Property Project_Id() As System.String 
    Get
        Return m_Project_Id
    End Get
    End Property

    Private Shared ReadOnly m_System_Code As String = "System_Code"
    Public Shared ReadOnly Property System_Code() As System.String 
    Get
        Return m_System_Code
    End Get
    End Property

    Private Shared ReadOnly m_Function_Code As String = "Function_Code"
    Public Shared ReadOnly Property Function_Code() As System.String 
    Get
        Return m_Function_Code
    End Get
    End Property

    Private Shared ReadOnly m_Receive_DateTime As String = "Receive_DateTime"
    Public Shared ReadOnly Property Receive_DateTime() As System.String 
    Get
        Return m_Receive_DateTime
    End Get
    End Property

    Private Shared ReadOnly m_Issue_Source As String = "Issue_Source"
    Public Shared ReadOnly Property Issue_Source() As System.String 
    Get
        Return m_Issue_Source
    End Get
    End Property

    Private Shared ReadOnly m_Issue_Description As String = "Issue_Description"
    Public Shared ReadOnly Property Issue_Description() As System.String 
    Get
        Return m_Issue_Description
    End Get
    End Property

    Private Shared ReadOnly m_Issue_Classify As String = "Issue_Classify"
    Public Shared ReadOnly Property Issue_Classify() As System.String 
    Get
        Return m_Issue_Classify
    End Get
    End Property

    Private Shared ReadOnly m_Issue_Status As String = "Issue_Status"
    Public Shared ReadOnly Property Issue_Status() As System.String 
    Get
        Return m_Issue_Status
    End Get
    End Property

    Private Shared ReadOnly m_Contact_User As String = "Contact_User"
    Public Shared ReadOnly Property Contact_User() As System.String 
    Get
        Return m_Contact_User
    End Get
    End Property

    Private Shared ReadOnly m_Contact_Way As String = "Contact_Way"
    Public Shared ReadOnly Property Contact_Way() As System.String 
    Get
        Return m_Contact_Way
    End Get
    End Property

    Private Shared ReadOnly m_Contact_Note As String = "Contact_Note"
    Public Shared ReadOnly Property Contact_Note() As System.String 
    Get
        Return m_Contact_Note
    End Get
    End Property

    Private Shared ReadOnly m_Processing_Approach As String = "Processing_Approach"
    Public Shared ReadOnly Property Processing_Approach() As System.String 
    Get
        Return m_Processing_Approach
    End Get
    End Property

    Private Shared ReadOnly m_Processing_Employee_Code As String = "Processing_Employee_Code"
    Public Shared ReadOnly Property Processing_Employee_Code() As System.String 
    Get
        Return m_Processing_Employee_Code
    End Get
    End Property

    Private Shared ReadOnly m_Processing_Cost As String = "Processing_Cost"
    Public Shared ReadOnly Property Processing_Cost() As System.String 
    Get
        Return m_Processing_Cost
    End Get
    End Property

    Private Shared ReadOnly m_Finish_Date As String = "Finish_Date"
    Public Shared ReadOnly Property Finish_Date() As System.String 
    Get
        Return m_Finish_Date
    End Get
    End Property

    Private Shared ReadOnly m_Estimated_Finish_Date As String = "Estimated_Finish_Date"
    Public Shared ReadOnly Property Estimated_Finish_Date() As System.String 
    Get
        Return m_Estimated_Finish_Date
    End Get
    End Property

    Private Shared ReadOnly m_Note As String = "Note"
    Public Shared ReadOnly Property Note() As System.String 
    Get
        Return m_Note
    End Get
    End Property

    Private Shared ReadOnly m_Att_FID As String = "Att_FID"
    Public Shared ReadOnly Property Att_FID() As System.String 
    Get
        Return m_Att_FID
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

    Private Shared ReadOnly m_Hospital_Code As String = "Hospital_Code"
    Public Shared ReadOnly Property Hospital_Code() As System.String 
    Get
        Return m_Hospital_Code
    End Get
    End Property

    Private Shared ReadOnly m_Cancel As String = "Cancel"
    Public Shared ReadOnly Property Cancel() As System.String 
    Get
        Return m_Cancel
    End Get
    End Property

    Private Shared ReadOnly m_Cancel_Reason As String = "Cancel_Reason"
    Public Shared ReadOnly Property Cancel_Reason() As System.String 
    Get
        Return m_Cancel_Reason
    End Get
    End Property

    Private Shared ReadOnly m_Cancel_Time As String = "Cancel_Time"
    Public Shared ReadOnly Property Cancel_Time() As System.String 
    Get
        Return m_Cancel_Time
    End Get
    End Property

    Private Shared ReadOnly m_Cancel_User As String = "Cancel_User"
    Public Shared ReadOnly Property Cancel_User() As System.String 
    Get
        Return m_Cancel_User
    End Get
    End Property

  End Class

End Class
