Imports System.Data.SqlClient
Public Class JobSaAssignRecordDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2018/10/9 下午 05:22:27
    Public Shared ReadOnly tableName as String="JOB_SA_Assign_Record"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "JOB_Code", "Assign_Date", "Project_ID", "PG_Employee_Code", "Finish_Date",   _
             "System_Code", "Function_Code", "Issue_Classify", "Issue_Deadline", "Issue_Desc",   _
             "Reply_Date", "FID", "RTF_FID", "Create_User", "Create_Time",   _
             "Modified_User", "Modified_Time", "Reject_Flag", "Cancel", "Cancel_User",   _
             "Cancel_Time", "Cancel_Reason", "Mail_Subject", "Mail_Group_Id", "Test_Report_Flag",   _
             "Assign_Source", "SD_Confirm", "SD_Note", "SD_Employee_Code", "Issue_Level",   _
             "Issue_Cost_Time", "Job_Status", "Estimate_Cost", "SD_Estimate_Cost", "SD_Cost_Time",   _
             "SD_Issue_Deadline", "SD_Confirm_Date", "Hospital_Code", "Job_Special_Status"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.DateTime", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.String", "System.Int32", "System.DateTime", "System.String",   _
             "System.DateTime", "System.String", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.DateTime", "System.String", "System.String", "System.String",   _
             "System.DateTime", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.Decimal", "System.Int32", "System.Decimal", "System.Decimal", "System.Decimal",   _
             "System.DateTime", "System.DateTime", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             200, -1, 10, 20, -1,   _
             10, 100, -1, -1, 2000,   _
             -1, 50, 50, 20, -1,   _
             20, -1, 1, 1, 20,   _
             -1, 200, 300, 10, 1,   _
             1, 1, 500, 20, 1,   _
             -1, -1, -1, -1, -1,   _
             -1, -1, 20, 1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = JobSaAssignRecordDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("JOB_Code") = New Object
        dataRow("Assign_Date") = New Object
        dataRow("Project_ID") = New Object
        dataRow("PG_Employee_Code") = New Object
        dataRow("Finish_Date") = New Object
        dataRow("System_Code") = New Object
        dataRow("Function_Code") = New Object
        dataRow("Issue_Classify") = New Object
        dataRow("Issue_Deadline") = New Object
        dataRow("Issue_Desc") = New Object
        dataRow("Reply_Date") = New Object
        dataRow("FID") = New Object
        dataRow("RTF_FID") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Reject_Flag") = New Object
        dataRow("Cancel") = New Object
        dataRow("Cancel_User") = New Object
        dataRow("Cancel_Time") = New Object
        dataRow("Cancel_Reason") = New Object
        dataRow("Mail_Subject") = New Object
        dataRow("Mail_Group_Id") = New Object
        dataRow("Test_Report_Flag") = New Object
        dataRow("Assign_Source") = New Object
        dataRow("SD_Confirm") = New Object
        dataRow("SD_Note") = New Object
        dataRow("SD_Employee_Code") = New Object
        dataRow("Issue_Level") = New Object
        dataRow("Issue_Cost_Time") = New Object
        dataRow("Job_Status") = New Object
        dataRow("Estimate_Cost") = New Object
        dataRow("SD_Estimate_Cost") = New Object
        dataRow("SD_Cost_Time") = New Object
        dataRow("SD_Issue_Deadline") = New Object
        dataRow("SD_Confirm_Date") = New Object
        dataRow("Hospital_Code") = New Object
        dataRow("Job_Special_Status") = New Object
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
            dt.Columns.Add("JOB_Code")
            dt.Columns.Add("Assign_Date")
            dt.Columns.Add("Project_ID")
            dt.Columns.Add("PG_Employee_Code")
            dt.Columns.Add("Finish_Date")
            dt.Columns.Add("System_Code")
            dt.Columns.Add("Function_Code")
            dt.Columns.Add("Issue_Classify")
            dt.Columns.Add("Issue_Deadline")
            dt.Columns.Add("Issue_Desc")
            dt.Columns.Add("Reply_Date")
            dt.Columns.Add("FID")
            dt.Columns.Add("RTF_FID")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Reject_Flag")
            dt.Columns.Add("Cancel")
            dt.Columns.Add("Cancel_User")
            dt.Columns.Add("Cancel_Time")
            dt.Columns.Add("Cancel_Reason")
            dt.Columns.Add("Mail_Subject")
            dt.Columns.Add("Mail_Group_Id")
            dt.Columns.Add("Test_Report_Flag")
            dt.Columns.Add("Assign_Source")
            dt.Columns.Add("SD_Confirm")
            dt.Columns.Add("SD_Note")
            dt.Columns.Add("SD_Employee_Code")
            dt.Columns.Add("Issue_Level")
            dt.Columns.Add("Issue_Cost_Time")
            dt.Columns.Add("Job_Status")
            dt.Columns.Add("Estimate_Cost")
            dt.Columns.Add("SD_Estimate_Cost")
            dt.Columns.Add("SD_Cost_Time")
            dt.Columns.Add("SD_Issue_Deadline")
            dt.Columns.Add("SD_Confirm_Date")
            dt.Columns.Add("Hospital_Code")
            dt.Columns.Add("Job_Special_Status")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("JOB_Code")
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
            dt.Columns.Add("JOB_Code")
            dt.Columns("JOB_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Assign_Date")
            dt.Columns("Assign_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Project_ID")
            dt.Columns("Project_ID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("PG_Employee_Code")
            dt.Columns("PG_Employee_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Finish_Date")
            dt.Columns("Finish_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("System_Code")
            dt.Columns("System_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Function_Code")
            dt.Columns("Function_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Issue_Classify")
            dt.Columns("Issue_Classify").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Issue_Deadline")
            dt.Columns("Issue_Deadline").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Issue_Desc")
            dt.Columns("Issue_Desc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Reply_Date")
            dt.Columns("Reply_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("FID")
            dt.Columns("FID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("RTF_FID")
            dt.Columns("RTF_FID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Reject_Flag")
            dt.Columns("Reject_Flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cancel")
            dt.Columns("Cancel").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cancel_User")
            dt.Columns("Cancel_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cancel_Time")
            dt.Columns("Cancel_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Cancel_Reason")
            dt.Columns("Cancel_Reason").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Mail_Subject")
            dt.Columns("Mail_Subject").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Mail_Group_Id")
            dt.Columns("Mail_Group_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Test_Report_Flag")
            dt.Columns("Test_Report_Flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Assign_Source")
            dt.Columns("Assign_Source").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("SD_Confirm")
            dt.Columns("SD_Confirm").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("SD_Note")
            dt.Columns("SD_Note").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("SD_Employee_Code")
            dt.Columns("SD_Employee_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Issue_Level")
            dt.Columns("Issue_Level").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Issue_Cost_Time")
            dt.Columns("Issue_Cost_Time").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Job_Status")
            dt.Columns("Job_Status").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Estimate_Cost")
            dt.Columns("Estimate_Cost").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("SD_Estimate_Cost")
            dt.Columns("SD_Estimate_Cost").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("SD_Cost_Time")
            dt.Columns("SD_Cost_Time").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("SD_Issue_Deadline")
            dt.Columns("SD_Issue_Deadline").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("SD_Confirm_Date")
            dt.Columns("SD_Confirm_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Hospital_Code")
            dt.Columns("Hospital_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Job_Special_Status")
            dt.Columns("Job_Special_Status").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("JOB_Code")
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
            dt.Columns.Add("JOB_Code")
            dt.Columns.Add("Assign_Date")
            dt.Columns.Add("Project_ID")
            dt.Columns.Add("PG_Employee_Code")
            dt.Columns.Add("Finish_Date")
            dt.Columns.Add("System_Code")
            dt.Columns.Add("Function_Code")
            dt.Columns.Add("Issue_Classify")
            dt.Columns.Add("Issue_Deadline")
            dt.Columns.Add("Issue_Desc")
            dt.Columns.Add("Reply_Date")
            dt.Columns.Add("FID")
            dt.Columns.Add("RTF_FID")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Reject_Flag")
            dt.Columns.Add("Cancel")
            dt.Columns.Add("Cancel_User")
            dt.Columns.Add("Cancel_Time")
            dt.Columns.Add("Cancel_Reason")
            dt.Columns.Add("Mail_Subject")
            dt.Columns.Add("Mail_Group_Id")
            dt.Columns.Add("Test_Report_Flag")
            dt.Columns.Add("Assign_Source")
            dt.Columns.Add("SD_Confirm")
            dt.Columns.Add("SD_Note")
            dt.Columns.Add("SD_Employee_Code")
            dt.Columns.Add("Issue_Level")
            dt.Columns.Add("Issue_Cost_Time")
            dt.Columns.Add("Job_Status")
            dt.Columns.Add("Estimate_Cost")
            dt.Columns.Add("SD_Estimate_Cost")
            dt.Columns.Add("SD_Cost_Time")
            dt.Columns.Add("SD_Issue_Deadline")
            dt.Columns.Add("SD_Confirm_Date")
            dt.Columns.Add("Hospital_Code")
            dt.Columns.Add("Job_Special_Status")
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

  Class JOBSAAssignRecordPt
    Private m_JOB_Code As String = "JOB_Code"
    Public ReadOnly Property JOB_Code() As System.String 
    Get
        Return m_JOB_Code
    End Get
    End Property

    Private m_Assign_Date As String = "Assign_Date"
    Public ReadOnly Property Assign_Date() As System.String 
    Get
        Return m_Assign_Date
    End Get
    End Property

    Private m_Project_ID As String = "Project_ID"
    Public ReadOnly Property Project_ID() As System.String 
    Get
        Return m_Project_ID
    End Get
    End Property

    Private m_PG_Employee_Code As String = "PG_Employee_Code"
    Public ReadOnly Property PG_Employee_Code() As System.String 
    Get
        Return m_PG_Employee_Code
    End Get
    End Property

    Private m_Finish_Date As String = "Finish_Date"
    Public ReadOnly Property Finish_Date() As System.String 
    Get
        Return m_Finish_Date
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

    Private m_Issue_Classify As String = "Issue_Classify"
    Public ReadOnly Property Issue_Classify() As System.String 
    Get
        Return m_Issue_Classify
    End Get
    End Property

    Private m_Issue_Deadline As String = "Issue_Deadline"
    Public ReadOnly Property Issue_Deadline() As System.String 
    Get
        Return m_Issue_Deadline
    End Get
    End Property

    Private m_Issue_Desc As String = "Issue_Desc"
    Public ReadOnly Property Issue_Desc() As System.String 
    Get
        Return m_Issue_Desc
    End Get
    End Property

    Private m_Reply_Date As String = "Reply_Date"
    Public ReadOnly Property Reply_Date() As System.String 
    Get
        Return m_Reply_Date
    End Get
    End Property

    Private m_FID As String = "FID"
    Public ReadOnly Property FID() As System.String 
    Get
        Return m_FID
    End Get
    End Property

    Private m_RTF_FID As String = "RTF_FID"
    Public ReadOnly Property RTF_FID() As System.String 
    Get
        Return m_RTF_FID
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

    Private m_Reject_Flag As String = "Reject_Flag"
    Public ReadOnly Property Reject_Flag() As System.String 
    Get
        Return m_Reject_Flag
    End Get
    End Property

    Private m_Cancel As String = "Cancel"
    Public ReadOnly Property Cancel() As System.String 
    Get
        Return m_Cancel
    End Get
    End Property

    Private m_Cancel_User As String = "Cancel_User"
    Public ReadOnly Property Cancel_User() As System.String 
    Get
        Return m_Cancel_User
    End Get
    End Property

    Private m_Cancel_Time As String = "Cancel_Time"
    Public ReadOnly Property Cancel_Time() As System.String 
    Get
        Return m_Cancel_Time
    End Get
    End Property

    Private m_Cancel_Reason As String = "Cancel_Reason"
    Public ReadOnly Property Cancel_Reason() As System.String 
    Get
        Return m_Cancel_Reason
    End Get
    End Property

    Private m_Mail_Subject As String = "Mail_Subject"
    Public ReadOnly Property Mail_Subject() As System.String 
    Get
        Return m_Mail_Subject
    End Get
    End Property

    Private m_Mail_Group_Id As String = "Mail_Group_Id"
    Public ReadOnly Property Mail_Group_Id() As System.String 
    Get
        Return m_Mail_Group_Id
    End Get
    End Property

    Private m_Test_Report_Flag As String = "Test_Report_Flag"
    Public ReadOnly Property Test_Report_Flag() As System.String 
    Get
        Return m_Test_Report_Flag
    End Get
    End Property

    Private m_Assign_Source As String = "Assign_Source"
    Public ReadOnly Property Assign_Source() As System.String 
    Get
        Return m_Assign_Source
    End Get
    End Property

    Private m_SD_Confirm As String = "SD_Confirm"
    Public ReadOnly Property SD_Confirm() As System.String 
    Get
        Return m_SD_Confirm
    End Get
    End Property

    Private m_SD_Note As String = "SD_Note"
    Public ReadOnly Property SD_Note() As System.String 
    Get
        Return m_SD_Note
    End Get
    End Property

    Private m_SD_Employee_Code As String = "SD_Employee_Code"
    Public ReadOnly Property SD_Employee_Code() As System.String 
    Get
        Return m_SD_Employee_Code
    End Get
    End Property

    Private m_Issue_Level As String = "Issue_Level"
    Public ReadOnly Property Issue_Level() As System.String 
    Get
        Return m_Issue_Level
    End Get
    End Property

    Private m_Issue_Cost_Time As String = "Issue_Cost_Time"
    Public ReadOnly Property Issue_Cost_Time() As System.String 
    Get
        Return m_Issue_Cost_Time
    End Get
    End Property

    Private m_Job_Status As String = "Job_Status"
    Public ReadOnly Property Job_Status() As System.String 
    Get
        Return m_Job_Status
    End Get
    End Property

    Private m_Estimate_Cost As String = "Estimate_Cost"
    Public ReadOnly Property Estimate_Cost() As System.String 
    Get
        Return m_Estimate_Cost
    End Get
    End Property

    Private m_SD_Estimate_Cost As String = "SD_Estimate_Cost"
    Public ReadOnly Property SD_Estimate_Cost() As System.String 
    Get
        Return m_SD_Estimate_Cost
    End Get
    End Property

    Private m_SD_Cost_Time As String = "SD_Cost_Time"
    Public ReadOnly Property SD_Cost_Time() As System.String 
    Get
        Return m_SD_Cost_Time
    End Get
    End Property

    Private m_SD_Issue_Deadline As String = "SD_Issue_Deadline"
    Public ReadOnly Property SD_Issue_Deadline() As System.String 
    Get
        Return m_SD_Issue_Deadline
    End Get
    End Property

    Private m_SD_Confirm_Date As String = "SD_Confirm_Date"
    Public ReadOnly Property SD_Confirm_Date() As System.String 
    Get
        Return m_SD_Confirm_Date
    End Get
    End Property

    Private m_Hospital_Code As String = "Hospital_Code"
    Public ReadOnly Property Hospital_Code() As System.String 
    Get
        Return m_Hospital_Code
    End Get
    End Property

    Private m_Job_Special_Status As String = "Job_Special_Status"
    Public ReadOnly Property Job_Special_Status() As System.String 
    Get
        Return m_Job_Special_Status
    End Get
    End Property

  End Class
  Class DBColumnName 
    Private Shared ReadOnly m_JOB_Code As String = "JOB_Code"
    Public Shared ReadOnly Property JOB_Code() As System.String 
    Get
        Return m_JOB_Code
    End Get
    End Property

    Private Shared ReadOnly m_Assign_Date As String = "Assign_Date"
    Public Shared ReadOnly Property Assign_Date() As System.String 
    Get
        Return m_Assign_Date
    End Get
    End Property

    Private Shared ReadOnly m_Project_ID As String = "Project_ID"
    Public Shared ReadOnly Property Project_ID() As System.String 
    Get
        Return m_Project_ID
    End Get
    End Property

    Private Shared ReadOnly m_PG_Employee_Code As String = "PG_Employee_Code"
    Public Shared ReadOnly Property PG_Employee_Code() As System.String 
    Get
        Return m_PG_Employee_Code
    End Get
    End Property

    Private Shared ReadOnly m_Finish_Date As String = "Finish_Date"
    Public Shared ReadOnly Property Finish_Date() As System.String 
    Get
        Return m_Finish_Date
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

    Private Shared ReadOnly m_Issue_Classify As String = "Issue_Classify"
    Public Shared ReadOnly Property Issue_Classify() As System.String 
    Get
        Return m_Issue_Classify
    End Get
    End Property

    Private Shared ReadOnly m_Issue_Deadline As String = "Issue_Deadline"
    Public Shared ReadOnly Property Issue_Deadline() As System.String 
    Get
        Return m_Issue_Deadline
    End Get
    End Property

    Private Shared ReadOnly m_Issue_Desc As String = "Issue_Desc"
    Public Shared ReadOnly Property Issue_Desc() As System.String 
    Get
        Return m_Issue_Desc
    End Get
    End Property

    Private Shared ReadOnly m_Reply_Date As String = "Reply_Date"
    Public Shared ReadOnly Property Reply_Date() As System.String 
    Get
        Return m_Reply_Date
    End Get
    End Property

    Private Shared ReadOnly m_FID As String = "FID"
    Public Shared ReadOnly Property FID() As System.String 
    Get
        Return m_FID
    End Get
    End Property

    Private Shared ReadOnly m_RTF_FID As String = "RTF_FID"
    Public Shared ReadOnly Property RTF_FID() As System.String 
    Get
        Return m_RTF_FID
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

    Private Shared ReadOnly m_Reject_Flag As String = "Reject_Flag"
    Public Shared ReadOnly Property Reject_Flag() As System.String 
    Get
        Return m_Reject_Flag
    End Get
    End Property

    Private Shared ReadOnly m_Cancel As String = "Cancel"
    Public Shared ReadOnly Property Cancel() As System.String 
    Get
        Return m_Cancel
    End Get
    End Property

    Private Shared ReadOnly m_Cancel_User As String = "Cancel_User"
    Public Shared ReadOnly Property Cancel_User() As System.String 
    Get
        Return m_Cancel_User
    End Get
    End Property

    Private Shared ReadOnly m_Cancel_Time As String = "Cancel_Time"
    Public Shared ReadOnly Property Cancel_Time() As System.String 
    Get
        Return m_Cancel_Time
    End Get
    End Property

    Private Shared ReadOnly m_Cancel_Reason As String = "Cancel_Reason"
    Public Shared ReadOnly Property Cancel_Reason() As System.String 
    Get
        Return m_Cancel_Reason
    End Get
    End Property

    Private Shared ReadOnly m_Mail_Subject As String = "Mail_Subject"
    Public Shared ReadOnly Property Mail_Subject() As System.String 
    Get
        Return m_Mail_Subject
    End Get
    End Property

    Private Shared ReadOnly m_Mail_Group_Id As String = "Mail_Group_Id"
    Public Shared ReadOnly Property Mail_Group_Id() As System.String 
    Get
        Return m_Mail_Group_Id
    End Get
    End Property

    Private Shared ReadOnly m_Test_Report_Flag As String = "Test_Report_Flag"
    Public Shared ReadOnly Property Test_Report_Flag() As System.String 
    Get
        Return m_Test_Report_Flag
    End Get
    End Property

    Private Shared ReadOnly m_Assign_Source As String = "Assign_Source"
    Public Shared ReadOnly Property Assign_Source() As System.String 
    Get
        Return m_Assign_Source
    End Get
    End Property

    Private Shared ReadOnly m_SD_Confirm As String = "SD_Confirm"
    Public Shared ReadOnly Property SD_Confirm() As System.String 
    Get
        Return m_SD_Confirm
    End Get
    End Property

    Private Shared ReadOnly m_SD_Note As String = "SD_Note"
    Public Shared ReadOnly Property SD_Note() As System.String 
    Get
        Return m_SD_Note
    End Get
    End Property

    Private Shared ReadOnly m_SD_Employee_Code As String = "SD_Employee_Code"
    Public Shared ReadOnly Property SD_Employee_Code() As System.String 
    Get
        Return m_SD_Employee_Code
    End Get
    End Property

    Private Shared ReadOnly m_Issue_Level As String = "Issue_Level"
    Public Shared ReadOnly Property Issue_Level() As System.String 
    Get
        Return m_Issue_Level
    End Get
    End Property

    Private Shared ReadOnly m_Issue_Cost_Time As String = "Issue_Cost_Time"
    Public Shared ReadOnly Property Issue_Cost_Time() As System.String 
    Get
        Return m_Issue_Cost_Time
    End Get
    End Property

    Private Shared ReadOnly m_Job_Status As String = "Job_Status"
    Public Shared ReadOnly Property Job_Status() As System.String 
    Get
        Return m_Job_Status
    End Get
    End Property

    Private Shared ReadOnly m_Estimate_Cost As String = "Estimate_Cost"
    Public Shared ReadOnly Property Estimate_Cost() As System.String 
    Get
        Return m_Estimate_Cost
    End Get
    End Property

    Private Shared ReadOnly m_SD_Estimate_Cost As String = "SD_Estimate_Cost"
    Public Shared ReadOnly Property SD_Estimate_Cost() As System.String 
    Get
        Return m_SD_Estimate_Cost
    End Get
    End Property

    Private Shared ReadOnly m_SD_Cost_Time As String = "SD_Cost_Time"
    Public Shared ReadOnly Property SD_Cost_Time() As System.String 
    Get
        Return m_SD_Cost_Time
    End Get
    End Property

    Private Shared ReadOnly m_SD_Issue_Deadline As String = "SD_Issue_Deadline"
    Public Shared ReadOnly Property SD_Issue_Deadline() As System.String 
    Get
        Return m_SD_Issue_Deadline
    End Get
    End Property

    Private Shared ReadOnly m_SD_Confirm_Date As String = "SD_Confirm_Date"
    Public Shared ReadOnly Property SD_Confirm_Date() As System.String 
    Get
        Return m_SD_Confirm_Date
    End Get
    End Property

    Private Shared ReadOnly m_Hospital_Code As String = "Hospital_Code"
    Public Shared ReadOnly Property Hospital_Code() As System.String 
    Get
        Return m_Hospital_Code
    End Get
    End Property

    Private Shared ReadOnly m_Job_Special_Status As String = "Job_Special_Status"
    Public Shared ReadOnly Property Job_Special_Status() As System.String 
    Get
        Return m_Job_Special_Status
    End Get
    End Property

  End Class

End Class
