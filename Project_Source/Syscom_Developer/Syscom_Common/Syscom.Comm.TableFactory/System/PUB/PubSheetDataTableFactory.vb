Imports System.Data.SqlClient
Public Class PubSheetDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/4/25 上午 10:25:24
    Public Shared ReadOnly tableName as String="PUB_Sheet"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Sheet_Code", "Sheet_Name", "Dept_Code", "Is_Emergency_Sheet", "Is_Indication",   _
             "Is_Print_Indication", "Sheet_Collect_Note", "Sheet_Note", "Sheet_Type_Id", "Lis_Sheet_Limit_Cnt",   _
             "Sheet_Sort_Value", "Dc", "Create_User", "Create_Time", "Modified_User",   _
             "Modified_Time", "Is_Print", "Lab_Group_Id", "Report_Title", "Sheet_Short_Name",   _
             "Finish_Sign_Hours", "Finish_Rpt_Hours", "In_Out_Id", "Finish_Total_Hours"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.Int32",   _
             "System.Int32", "System.String", "System.String", "System.DateTime", "System.String",   _
             "System.DateTime", "System.String", "System.String", "System.String", "System.String",   _
             "System.Decimal", "System.Decimal", "System.String", "System.Decimal"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 50, 6, 1, 1,   _
             1, 1073741823, 1073741823, 5, -1,   _
             -1, 1, 10, -1, 10,   _
             -1, 1, 5, 50, 20,   _
             -1, -1, 5, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubSheetDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Sheet_Code") = New Object
        dataRow("Sheet_Name") = New Object
        dataRow("Dept_Code") = New Object
        dataRow("Is_Emergency_Sheet") = New Object
        dataRow("Is_Indication") = New Object
        dataRow("Is_Print_Indication") = New Object
        dataRow("Sheet_Collect_Note") = New Object
        dataRow("Sheet_Note") = New Object
        dataRow("Sheet_Type_Id") = New Object
        dataRow("Lis_Sheet_Limit_Cnt") = New Object
        dataRow("Sheet_Sort_Value") = New Object
        dataRow("Dc") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Is_Print") = New Object
        dataRow("Lab_Group_Id") = New Object
        dataRow("Report_Title") = New Object
        dataRow("Sheet_Short_Name") = New Object
        dataRow("Finish_Sign_Hours") = New Object
        dataRow("Finish_Rpt_Hours") = New Object
        dataRow("In_Out_Id") = New Object
        dataRow("Finish_Total_Hours") = New Object
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
            dt.Columns.Add("Sheet_Code")
            dt.Columns.Add("Sheet_Name")
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Is_Emergency_Sheet")
            dt.Columns.Add("Is_Indication")
            dt.Columns.Add("Is_Print_Indication")
            dt.Columns.Add("Sheet_Collect_Note")
            dt.Columns.Add("Sheet_Note")
            dt.Columns.Add("Sheet_Type_Id")
            dt.Columns.Add("Lis_Sheet_Limit_Cnt")
            dt.Columns.Add("Sheet_Sort_Value")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Is_Print")
            dt.Columns.Add("Lab_Group_Id")
            dt.Columns.Add("Report_Title")
            dt.Columns.Add("Sheet_Short_Name")
            dt.Columns.Add("Finish_Sign_Hours")
            dt.Columns.Add("Finish_Rpt_Hours")
            dt.Columns.Add("In_Out_Id")
            dt.Columns.Add("Finish_Total_Hours")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Sheet_Code")
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
            dt.Columns.Add("Sheet_Code")
            dt.Columns("Sheet_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sheet_Name")
            dt.Columns("Sheet_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dept_Code")
            dt.Columns("Dept_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Emergency_Sheet")
            dt.Columns("Is_Emergency_Sheet").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Indication")
            dt.Columns("Is_Indication").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Print_Indication")
            dt.Columns("Is_Print_Indication").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sheet_Collect_Note")
            dt.Columns("Sheet_Collect_Note").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sheet_Note")
            dt.Columns("Sheet_Note").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sheet_Type_Id")
            dt.Columns("Sheet_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Lis_Sheet_Limit_Cnt")
            dt.Columns("Lis_Sheet_Limit_Cnt").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Sheet_Sort_Value")
            dt.Columns("Sheet_Sort_Value").DataType = System.Type.GetType("System.Int32")
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
            dt.Columns.Add("Is_Print")
            dt.Columns("Is_Print").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Lab_Group_Id")
            dt.Columns("Lab_Group_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Report_Title")
            dt.Columns("Report_Title").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sheet_Short_Name")
            dt.Columns("Sheet_Short_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Finish_Sign_Hours")
            dt.Columns("Finish_Sign_Hours").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Finish_Rpt_Hours")
            dt.Columns("Finish_Rpt_Hours").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("In_Out_Id")
            dt.Columns("In_Out_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Finish_Total_Hours")
            dt.Columns("Finish_Total_Hours").DataType = System.Type.GetType("System.Decimal")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Sheet_Code")
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
            dt.Columns.Add("Sheet_Code")
            dt.Columns.Add("Sheet_Name")
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Is_Emergency_Sheet")
            dt.Columns.Add("Is_Indication")
            dt.Columns.Add("Is_Print_Indication")
            dt.Columns.Add("Sheet_Collect_Note")
            dt.Columns.Add("Sheet_Note")
            dt.Columns.Add("Sheet_Type_Id")
            dt.Columns.Add("Lis_Sheet_Limit_Cnt")
            dt.Columns.Add("Sheet_Sort_Value")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Is_Print")
            dt.Columns.Add("Lab_Group_Id")
            dt.Columns.Add("Report_Title")
            dt.Columns.Add("Sheet_Short_Name")
            dt.Columns.Add("Finish_Sign_Hours")
            dt.Columns.Add("Finish_Rpt_Hours")
            dt.Columns.Add("In_Out_Id")
            dt.Columns.Add("Finish_Total_Hours")
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

  Class PUBSheetPt
    Private m_Sheet_Code As String = "Sheet_Code"
    Public ReadOnly Property Sheet_Code() As System.String 
    Get
        Return m_Sheet_Code
    End Get
    End Property

    Private m_Sheet_Name As String = "Sheet_Name"
    Public ReadOnly Property Sheet_Name() As System.String 
    Get
        Return m_Sheet_Name
    End Get
    End Property

    Private m_Dept_Code As String = "Dept_Code"
    Public ReadOnly Property Dept_Code() As System.String 
    Get
        Return m_Dept_Code
    End Get
    End Property

    Private m_Is_Emergency_Sheet As String = "Is_Emergency_Sheet"
    Public ReadOnly Property Is_Emergency_Sheet() As System.String 
    Get
        Return m_Is_Emergency_Sheet
    End Get
    End Property

    Private m_Is_Indication As String = "Is_Indication"
    Public ReadOnly Property Is_Indication() As System.String 
    Get
        Return m_Is_Indication
    End Get
    End Property

    Private m_Is_Print_Indication As String = "Is_Print_Indication"
    Public ReadOnly Property Is_Print_Indication() As System.String 
    Get
        Return m_Is_Print_Indication
    End Get
    End Property

    Private m_Sheet_Collect_Note As String = "Sheet_Collect_Note"
    Public ReadOnly Property Sheet_Collect_Note() As System.String 
    Get
        Return m_Sheet_Collect_Note
    End Get
    End Property

    Private m_Sheet_Note As String = "Sheet_Note"
    Public ReadOnly Property Sheet_Note() As System.String 
    Get
        Return m_Sheet_Note
    End Get
    End Property

    Private m_Sheet_Type_Id As String = "Sheet_Type_Id"
    Public ReadOnly Property Sheet_Type_Id() As System.String 
    Get
        Return m_Sheet_Type_Id
    End Get
    End Property

    Private m_Lis_Sheet_Limit_Cnt As String = "Lis_Sheet_Limit_Cnt"
    Public ReadOnly Property Lis_Sheet_Limit_Cnt() As System.String 
    Get
        Return m_Lis_Sheet_Limit_Cnt
    End Get
    End Property

    Private m_Sheet_Sort_Value As String = "Sheet_Sort_Value"
    Public ReadOnly Property Sheet_Sort_Value() As System.String 
    Get
        Return m_Sheet_Sort_Value
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

    Private m_Is_Print As String = "Is_Print"
    Public ReadOnly Property Is_Print() As System.String 
    Get
        Return m_Is_Print
    End Get
    End Property

    Private m_Lab_Group_Id As String = "Lab_Group_Id"
    Public ReadOnly Property Lab_Group_Id() As System.String 
    Get
        Return m_Lab_Group_Id
    End Get
    End Property

    Private m_Report_Title As String = "Report_Title"
    Public ReadOnly Property Report_Title() As System.String 
    Get
        Return m_Report_Title
    End Get
    End Property

    Private m_Sheet_Short_Name As String = "Sheet_Short_Name"
    Public ReadOnly Property Sheet_Short_Name() As System.String 
    Get
        Return m_Sheet_Short_Name
    End Get
    End Property

    Private m_Finish_Sign_Hours As String = "Finish_Sign_Hours"
    Public ReadOnly Property Finish_Sign_Hours() As System.String 
    Get
        Return m_Finish_Sign_Hours
    End Get
    End Property

    Private m_Finish_Rpt_Hours As String = "Finish_Rpt_Hours"
    Public ReadOnly Property Finish_Rpt_Hours() As System.String 
    Get
        Return m_Finish_Rpt_Hours
    End Get
    End Property

    Private m_In_Out_Id As String = "In_Out_Id"
    Public ReadOnly Property In_Out_Id() As System.String 
    Get
        Return m_In_Out_Id
    End Get
    End Property

    Private m_Finish_Total_Hours As String = "Finish_Total_Hours"
    Public ReadOnly Property Finish_Total_Hours() As System.String 
    Get
        Return m_Finish_Total_Hours
    End Get
    End Property

  End Class

End Class
