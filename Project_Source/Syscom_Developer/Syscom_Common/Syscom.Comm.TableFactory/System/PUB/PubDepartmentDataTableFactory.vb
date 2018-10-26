Imports System.Data.SqlClient
Public Class PubDepartmentDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/9/20 上午 10:17:49
    Public Shared ReadOnly tableName as String="PUB_Department"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Dept_Code", "Dept_Name", "Dept_En_Name", "Short_Name", "NHI_Opd_Dept_Code",   _
             "NHI_Ipd_Dept_Code", "Effect_Date", "End_Date", "Belong_Dept_Code", "Is_Reg_Dept",   _
             "Dc", "Create_User", "Create_Time", "Modified_User", "Modified_Time",   _
             "Is_Emg_Dept", "Is_Ipd_Dept", "Emg_Dept_Name", "Emg_Dept_En_Name", "Ipd_Dept_Name",   _
             "Ipd_Dept_En_Name", "Sort_Value", "Emg_Sort_Value", "Ipd_Sort_Value", "Upper_Dept_Code",   _
             "Is_Nrs_Station", "Dept_Level_Id", "Acc_Dept"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.DateTime", "System.DateTime", "System.String", "System.String",   _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.Int32", "System.Int32", "System.Int32", "System.String",   _
             "System.String", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             6, 100, 100, 20, 2,   _
             2, -1, -1, 6, 1,   _
             1, 10, -1, 10, -1,   _
             1, 1, 100, 100, 100,   _
             100, -1, -1, -1, 6,   _
             1, 5, 6}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubDepartmentDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Dept_Code") = New Object
        dataRow("Dept_Name") = New Object
        dataRow("Dept_En_Name") = New Object
        dataRow("Short_Name") = New Object
        dataRow("NHI_Opd_Dept_Code") = New Object
        dataRow("NHI_Ipd_Dept_Code") = New Object
        dataRow("Effect_Date") = New Object
        dataRow("End_Date") = New Object
        dataRow("Belong_Dept_Code") = New Object
        dataRow("Is_Reg_Dept") = New Object
        dataRow("Dc") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Is_Emg_Dept") = New Object
        dataRow("Is_Ipd_Dept") = New Object
        dataRow("Emg_Dept_Name") = New Object
        dataRow("Emg_Dept_En_Name") = New Object
        dataRow("Ipd_Dept_Name") = New Object
        dataRow("Ipd_Dept_En_Name") = New Object
        dataRow("Sort_Value") = New Object
        dataRow("Emg_Sort_Value") = New Object
        dataRow("Ipd_Sort_Value") = New Object
        dataRow("Upper_Dept_Code") = New Object
        dataRow("Is_Nrs_Station") = New Object
        dataRow("Dept_Level_Id") = New Object
        dataRow("Acc_Dept") = New Object
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
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Dept_Name")
            dt.Columns.Add("Dept_En_Name")
            dt.Columns.Add("Short_Name")
            dt.Columns.Add("NHI_Opd_Dept_Code")
            dt.Columns.Add("NHI_Ipd_Dept_Code")
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Belong_Dept_Code")
            dt.Columns.Add("Is_Reg_Dept")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Is_Emg_Dept")
            dt.Columns.Add("Is_Ipd_Dept")
            dt.Columns.Add("Emg_Dept_Name")
            dt.Columns.Add("Emg_Dept_En_Name")
            dt.Columns.Add("Ipd_Dept_Name")
            dt.Columns.Add("Ipd_Dept_En_Name")
            dt.Columns.Add("Sort_Value")
            dt.Columns.Add("Emg_Sort_Value")
            dt.Columns.Add("Ipd_Sort_Value")
            dt.Columns.Add("Upper_Dept_Code")
            dt.Columns.Add("Is_Nrs_Station")
            dt.Columns.Add("Dept_Level_Id")
            dt.Columns.Add("Acc_Dept")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Dept_Code")
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
            dt.Columns.Add("Dept_Code")
            dt.Columns("Dept_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dept_Name")
            dt.Columns("Dept_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dept_En_Name")
            dt.Columns("Dept_En_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Short_Name")
            dt.Columns("Short_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("NHI_Opd_Dept_Code")
            dt.Columns("NHI_Opd_Dept_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("NHI_Ipd_Dept_Code")
            dt.Columns("NHI_Ipd_Dept_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Effect_Date")
            dt.Columns("Effect_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("End_Date")
            dt.Columns("End_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Belong_Dept_Code")
            dt.Columns("Belong_Dept_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Reg_Dept")
            dt.Columns("Is_Reg_Dept").DataType = System.Type.GetType("System.String")
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
            dt.Columns.Add("Is_Emg_Dept")
            dt.Columns("Is_Emg_Dept").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Ipd_Dept")
            dt.Columns("Is_Ipd_Dept").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Emg_Dept_Name")
            dt.Columns("Emg_Dept_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Emg_Dept_En_Name")
            dt.Columns("Emg_Dept_En_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Ipd_Dept_Name")
            dt.Columns("Ipd_Dept_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Ipd_Dept_En_Name")
            dt.Columns("Ipd_Dept_En_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sort_Value")
            dt.Columns("Sort_Value").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Emg_Sort_Value")
            dt.Columns("Emg_Sort_Value").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Ipd_Sort_Value")
            dt.Columns("Ipd_Sort_Value").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Upper_Dept_Code")
            dt.Columns("Upper_Dept_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Nrs_Station")
            dt.Columns("Is_Nrs_Station").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dept_Level_Id")
            dt.Columns("Dept_Level_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Acc_Dept")
            dt.Columns("Acc_Dept").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Dept_Code")
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
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Dept_Name")
            dt.Columns.Add("Dept_En_Name")
            dt.Columns.Add("Short_Name")
            dt.Columns.Add("NHI_Opd_Dept_Code")
            dt.Columns.Add("NHI_Ipd_Dept_Code")
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Belong_Dept_Code")
            dt.Columns.Add("Is_Reg_Dept")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Is_Emg_Dept")
            dt.Columns.Add("Is_Ipd_Dept")
            dt.Columns.Add("Emg_Dept_Name")
            dt.Columns.Add("Emg_Dept_En_Name")
            dt.Columns.Add("Ipd_Dept_Name")
            dt.Columns.Add("Ipd_Dept_En_Name")
            dt.Columns.Add("Sort_Value")
            dt.Columns.Add("Emg_Sort_Value")
            dt.Columns.Add("Ipd_Sort_Value")
            dt.Columns.Add("Upper_Dept_Code")
            dt.Columns.Add("Is_Nrs_Station")
            dt.Columns.Add("Dept_Level_Id")
            dt.Columns.Add("Acc_Dept")
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

  Class PUBDepartmentPt
    Private m_Dept_Code As String = "Dept_Code"
    Public ReadOnly Property Dept_Code() As System.String 
    Get
        Return m_Dept_Code
    End Get
    End Property

    Private m_Dept_Name As String = "Dept_Name"
    Public ReadOnly Property Dept_Name() As System.String 
    Get
        Return m_Dept_Name
    End Get
    End Property

    Private m_Dept_En_Name As String = "Dept_En_Name"
    Public ReadOnly Property Dept_En_Name() As System.String 
    Get
        Return m_Dept_En_Name
    End Get
    End Property

    Private m_Short_Name As String = "Short_Name"
    Public ReadOnly Property Short_Name() As System.String 
    Get
        Return m_Short_Name
    End Get
    End Property

    Private m_NHI_Opd_Dept_Code As String = "NHI_Opd_Dept_Code"
    Public ReadOnly Property NHI_Opd_Dept_Code() As System.String 
    Get
        Return m_NHI_Opd_Dept_Code
    End Get
    End Property

    Private m_NHI_Ipd_Dept_Code As String = "NHI_Ipd_Dept_Code"
    Public ReadOnly Property NHI_Ipd_Dept_Code() As System.String 
    Get
        Return m_NHI_Ipd_Dept_Code
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

    Private m_Belong_Dept_Code As String = "Belong_Dept_Code"
    Public ReadOnly Property Belong_Dept_Code() As System.String 
    Get
        Return m_Belong_Dept_Code
    End Get
    End Property

    Private m_Is_Reg_Dept As String = "Is_Reg_Dept"
    Public ReadOnly Property Is_Reg_Dept() As System.String 
    Get
        Return m_Is_Reg_Dept
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

    Private m_Is_Emg_Dept As String = "Is_Emg_Dept"
    Public ReadOnly Property Is_Emg_Dept() As System.String 
    Get
        Return m_Is_Emg_Dept
    End Get
    End Property

    Private m_Is_Ipd_Dept As String = "Is_Ipd_Dept"
    Public ReadOnly Property Is_Ipd_Dept() As System.String 
    Get
        Return m_Is_Ipd_Dept
    End Get
    End Property

    Private m_Emg_Dept_Name As String = "Emg_Dept_Name"
    Public ReadOnly Property Emg_Dept_Name() As System.String 
    Get
        Return m_Emg_Dept_Name
    End Get
    End Property

    Private m_Emg_Dept_En_Name As String = "Emg_Dept_En_Name"
    Public ReadOnly Property Emg_Dept_En_Name() As System.String 
    Get
        Return m_Emg_Dept_En_Name
    End Get
    End Property

    Private m_Ipd_Dept_Name As String = "Ipd_Dept_Name"
    Public ReadOnly Property Ipd_Dept_Name() As System.String 
    Get
        Return m_Ipd_Dept_Name
    End Get
    End Property

    Private m_Ipd_Dept_En_Name As String = "Ipd_Dept_En_Name"
    Public ReadOnly Property Ipd_Dept_En_Name() As System.String 
    Get
        Return m_Ipd_Dept_En_Name
    End Get
    End Property

    Private m_Sort_Value As String = "Sort_Value"
    Public ReadOnly Property Sort_Value() As System.String 
    Get
        Return m_Sort_Value
    End Get
    End Property

    Private m_Emg_Sort_Value As String = "Emg_Sort_Value"
    Public ReadOnly Property Emg_Sort_Value() As System.String 
    Get
        Return m_Emg_Sort_Value
    End Get
    End Property

    Private m_Ipd_Sort_Value As String = "Ipd_Sort_Value"
    Public ReadOnly Property Ipd_Sort_Value() As System.String 
    Get
        Return m_Ipd_Sort_Value
    End Get
    End Property

    Private m_Upper_Dept_Code As String = "Upper_Dept_Code"
    Public ReadOnly Property Upper_Dept_Code() As System.String 
    Get
        Return m_Upper_Dept_Code
    End Get
    End Property

    Private m_Is_Nrs_Station As String = "Is_Nrs_Station"
    Public ReadOnly Property Is_Nrs_Station() As System.String 
    Get
        Return m_Is_Nrs_Station
    End Get
    End Property

    Private m_Dept_Level_Id As String = "Dept_Level_Id"
    Public ReadOnly Property Dept_Level_Id() As System.String 
    Get
        Return m_Dept_Level_Id
    End Get
    End Property

    Private m_Acc_Dept As String = "Acc_Dept"
    Public ReadOnly Property Acc_Dept() As System.String 
    Get
        Return m_Acc_Dept
    End Get
    End Property

  End Class

End Class
