Imports System.Data.SqlClient
Public Class PubOrderExaminationDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/3/29 下午 04:55:01
    Public Shared ReadOnly tableName as String="PUB_Order_Examination"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Order_Code", "Default_Main_Body_Site_Code", "Default_Body_Site_Code", "Default_Side_Id", "Is_Main_Body_Site",   _
             "Is_Body_Site", "Is_Side_Id", "Is_Scheduled", "Is_Same_Specimen_Add", "Is_Print_Order_Note",   _
             "Opd_Report_Time", "Emg_Report_Time", "Ipd_Report_Time", "Default_Specimen_Id", "Default_Vessel_Id",   _
             "Is_PACS", "Is_With_Contrast", "Is_Scheduled_Ipd", "Deliver_System", "Nhi_Body_Site_Code",   _
             "Is_No_Check_In", "Is_No_Separate", "Is_Loan_Chart", "Second_Order_Code", "Is_No_Print",   _
             "Create_User", "Create_Time", "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.Decimal", "System.Decimal", "System.Decimal", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.DateTime", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             20, 5, 5, 5, 1,   _
             1, 1, 1, 1, 1,   _
             -1, -1, -1, 5, 5,   _
             1, 1, 1, 10, 10,   _
             1, 1, 1, 20, 1,   _
             10, -1, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubOrderExaminationDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Order_Code") = New Object
        dataRow("Default_Main_Body_Site_Code") = New Object
        dataRow("Default_Body_Site_Code") = New Object
        dataRow("Default_Side_Id") = New Object
        dataRow("Is_Main_Body_Site") = New Object
        dataRow("Is_Body_Site") = New Object
        dataRow("Is_Side_Id") = New Object
        dataRow("Is_Scheduled") = New Object
        dataRow("Is_Same_Specimen_Add") = New Object
        dataRow("Is_Print_Order_Note") = New Object
        dataRow("Opd_Report_Time") = New Object
        dataRow("Emg_Report_Time") = New Object
        dataRow("Ipd_Report_Time") = New Object
        dataRow("Default_Specimen_Id") = New Object
        dataRow("Default_Vessel_Id") = New Object
        dataRow("Is_PACS") = New Object
        dataRow("Is_With_Contrast") = New Object
        dataRow("Is_Scheduled_Ipd") = New Object
        dataRow("Deliver_System") = New Object
        dataRow("Nhi_Body_Site_Code") = New Object
        dataRow("Is_No_Check_In") = New Object
        dataRow("Is_No_Separate") = New Object
        dataRow("Is_Loan_Chart") = New Object
        dataRow("Second_Order_Code") = New Object
        dataRow("Is_No_Print") = New Object
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
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Default_Main_Body_Site_Code")
            dt.Columns.Add("Default_Body_Site_Code")
            dt.Columns.Add("Default_Side_Id")
            dt.Columns.Add("Is_Main_Body_Site")
            dt.Columns.Add("Is_Body_Site")
            dt.Columns.Add("Is_Side_Id")
            dt.Columns.Add("Is_Scheduled")
            dt.Columns.Add("Is_Same_Specimen_Add")
            dt.Columns.Add("Is_Print_Order_Note")
            dt.Columns.Add("Opd_Report_Time")
            dt.Columns.Add("Emg_Report_Time")
            dt.Columns.Add("Ipd_Report_Time")
            dt.Columns.Add("Default_Specimen_Id")
            dt.Columns.Add("Default_Vessel_Id")
            dt.Columns.Add("Is_PACS")
            dt.Columns.Add("Is_With_Contrast")
            dt.Columns.Add("Is_Scheduled_Ipd")
            dt.Columns.Add("Deliver_System")
            dt.Columns.Add("Nhi_Body_Site_Code")
            dt.Columns.Add("Is_No_Check_In")
            dt.Columns.Add("Is_No_Separate")
            dt.Columns.Add("Is_Loan_Chart")
            dt.Columns.Add("Second_Order_Code")
            dt.Columns.Add("Is_No_Print")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Order_Code")
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
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Default_Main_Body_Site_Code")
            dt.Columns("Default_Main_Body_Site_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Default_Body_Site_Code")
            dt.Columns("Default_Body_Site_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Default_Side_Id")
            dt.Columns("Default_Side_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Main_Body_Site")
            dt.Columns("Is_Main_Body_Site").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Body_Site")
            dt.Columns("Is_Body_Site").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Side_Id")
            dt.Columns("Is_Side_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Scheduled")
            dt.Columns("Is_Scheduled").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Same_Specimen_Add")
            dt.Columns("Is_Same_Specimen_Add").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Print_Order_Note")
            dt.Columns("Is_Print_Order_Note").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Opd_Report_Time")
            dt.Columns("Opd_Report_Time").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Emg_Report_Time")
            dt.Columns("Emg_Report_Time").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Ipd_Report_Time")
            dt.Columns("Ipd_Report_Time").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Default_Specimen_Id")
            dt.Columns("Default_Specimen_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Default_Vessel_Id")
            dt.Columns("Default_Vessel_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_PACS")
            dt.Columns("Is_PACS").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_With_Contrast")
            dt.Columns("Is_With_Contrast").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Scheduled_Ipd")
            dt.Columns("Is_Scheduled_Ipd").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Deliver_System")
            dt.Columns("Deliver_System").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Nhi_Body_Site_Code")
            dt.Columns("Nhi_Body_Site_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_No_Check_In")
            dt.Columns("Is_No_Check_In").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_No_Separate")
            dt.Columns("Is_No_Separate").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Loan_Chart")
            dt.Columns("Is_Loan_Chart").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Second_Order_Code")
            dt.Columns("Second_Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_No_Print")
            dt.Columns("Is_No_Print").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Order_Code")
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
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Default_Main_Body_Site_Code")
            dt.Columns.Add("Default_Body_Site_Code")
            dt.Columns.Add("Default_Side_Id")
            dt.Columns.Add("Is_Main_Body_Site")
            dt.Columns.Add("Is_Body_Site")
            dt.Columns.Add("Is_Side_Id")
            dt.Columns.Add("Is_Scheduled")
            dt.Columns.Add("Is_Same_Specimen_Add")
            dt.Columns.Add("Is_Print_Order_Note")
            dt.Columns.Add("Opd_Report_Time")
            dt.Columns.Add("Emg_Report_Time")
            dt.Columns.Add("Ipd_Report_Time")
            dt.Columns.Add("Default_Specimen_Id")
            dt.Columns.Add("Default_Vessel_Id")
            dt.Columns.Add("Is_PACS")
            dt.Columns.Add("Is_With_Contrast")
            dt.Columns.Add("Is_Scheduled_Ipd")
            dt.Columns.Add("Deliver_System")
            dt.Columns.Add("Nhi_Body_Site_Code")
            dt.Columns.Add("Is_No_Check_In")
            dt.Columns.Add("Is_No_Separate")
            dt.Columns.Add("Is_Loan_Chart")
            dt.Columns.Add("Second_Order_Code")
            dt.Columns.Add("Is_No_Print")
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

  Class PUBOrderExaminationPt
    Private m_Order_Code As String = "Order_Code"
    Public ReadOnly Property Order_Code() As System.String 
    Get
        Return m_Order_Code
    End Get
    End Property

    Private m_Default_Main_Body_Site_Code As String = "Default_Main_Body_Site_Code"
    Public ReadOnly Property Default_Main_Body_Site_Code() As System.String 
    Get
        Return m_Default_Main_Body_Site_Code
    End Get
    End Property

    Private m_Default_Body_Site_Code As String = "Default_Body_Site_Code"
    Public ReadOnly Property Default_Body_Site_Code() As System.String 
    Get
        Return m_Default_Body_Site_Code
    End Get
    End Property

    Private m_Default_Side_Id As String = "Default_Side_Id"
    Public ReadOnly Property Default_Side_Id() As System.String 
    Get
        Return m_Default_Side_Id
    End Get
    End Property

    Private m_Is_Main_Body_Site As String = "Is_Main_Body_Site"
    Public ReadOnly Property Is_Main_Body_Site() As System.String 
    Get
        Return m_Is_Main_Body_Site
    End Get
    End Property

    Private m_Is_Body_Site As String = "Is_Body_Site"
    Public ReadOnly Property Is_Body_Site() As System.String 
    Get
        Return m_Is_Body_Site
    End Get
    End Property

    Private m_Is_Side_Id As String = "Is_Side_Id"
    Public ReadOnly Property Is_Side_Id() As System.String 
    Get
        Return m_Is_Side_Id
    End Get
    End Property

    Private m_Is_Scheduled As String = "Is_Scheduled"
    Public ReadOnly Property Is_Scheduled() As System.String 
    Get
        Return m_Is_Scheduled
    End Get
    End Property

    Private m_Is_Same_Specimen_Add As String = "Is_Same_Specimen_Add"
    Public ReadOnly Property Is_Same_Specimen_Add() As System.String 
    Get
        Return m_Is_Same_Specimen_Add
    End Get
    End Property

    Private m_Is_Print_Order_Note As String = "Is_Print_Order_Note"
    Public ReadOnly Property Is_Print_Order_Note() As System.String 
    Get
        Return m_Is_Print_Order_Note
    End Get
    End Property

    Private m_Opd_Report_Time As String = "Opd_Report_Time"
    Public ReadOnly Property Opd_Report_Time() As System.String 
    Get
        Return m_Opd_Report_Time
    End Get
    End Property

    Private m_Emg_Report_Time As String = "Emg_Report_Time"
    Public ReadOnly Property Emg_Report_Time() As System.String 
    Get
        Return m_Emg_Report_Time
    End Get
    End Property

    Private m_Ipd_Report_Time As String = "Ipd_Report_Time"
    Public ReadOnly Property Ipd_Report_Time() As System.String 
    Get
        Return m_Ipd_Report_Time
    End Get
    End Property

    Private m_Default_Specimen_Id As String = "Default_Specimen_Id"
    Public ReadOnly Property Default_Specimen_Id() As System.String 
    Get
        Return m_Default_Specimen_Id
    End Get
    End Property

    Private m_Default_Vessel_Id As String = "Default_Vessel_Id"
    Public ReadOnly Property Default_Vessel_Id() As System.String 
    Get
        Return m_Default_Vessel_Id
    End Get
    End Property

    Private m_Is_PACS As String = "Is_PACS"
    Public ReadOnly Property Is_PACS() As System.String 
    Get
        Return m_Is_PACS
    End Get
    End Property

    Private m_Is_With_Contrast As String = "Is_With_Contrast"
    Public ReadOnly Property Is_With_Contrast() As System.String 
    Get
        Return m_Is_With_Contrast
    End Get
    End Property

    Private m_Is_Scheduled_Ipd As String = "Is_Scheduled_Ipd"
    Public ReadOnly Property Is_Scheduled_Ipd() As System.String 
    Get
        Return m_Is_Scheduled_Ipd
    End Get
    End Property

    Private m_Deliver_System As String = "Deliver_System"
    Public ReadOnly Property Deliver_System() As System.String 
    Get
        Return m_Deliver_System
    End Get
    End Property

    Private m_Nhi_Body_Site_Code As String = "Nhi_Body_Site_Code"
    Public ReadOnly Property Nhi_Body_Site_Code() As System.String 
    Get
        Return m_Nhi_Body_Site_Code
    End Get
    End Property

    Private m_Is_No_Check_In As String = "Is_No_Check_In"
    Public ReadOnly Property Is_No_Check_In() As System.String 
    Get
        Return m_Is_No_Check_In
    End Get
    End Property

    Private m_Is_No_Separate As String = "Is_No_Separate"
    Public ReadOnly Property Is_No_Separate() As System.String 
    Get
        Return m_Is_No_Separate
    End Get
    End Property

    Private m_Is_Loan_Chart As String = "Is_Loan_Chart"
    Public ReadOnly Property Is_Loan_Chart() As System.String 
    Get
        Return m_Is_Loan_Chart
    End Get
    End Property

    Private m_Second_Order_Code As String = "Second_Order_Code"
    Public ReadOnly Property Second_Order_Code() As System.String 
    Get
        Return m_Second_Order_Code
    End Get
    End Property

    Private m_Is_No_Print As String = "Is_No_Print"
    Public ReadOnly Property Is_No_Print() As System.String 
    Get
        Return m_Is_No_Print
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
