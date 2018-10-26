Imports System.Data.SqlClient
Public Class OphInteractionDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/16 上午 09:45:52
    Public Shared ReadOnly tableName as String="OPH_Interaction"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Pharmacy_12_CodeA", "Pharmacy_12_CodeB", "Interaction_Level", "Interaction_Rate_Id", "Serious_Degree_Id",   _
             "Catalog_Id", "Restriction_Id", "Is_Online_Remind", "First_Occur_Date", "Pause_Date",   _
             "Remind_Words", "Effect", "Turn", "Process", "Discuss",   _
             "Reference", "Dc", "Create_User", "Create_Time", "Modified_User",   _
             "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.DateTime", "System.DateTime",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.DateTime", "System.String",   _
             "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             12, 12, 10, 1, 1,   _
             1, 1, 1, -1, -1,   _
             300, 1073741823, 1073741823, 1073741823, 1073741823,   _
             1073741823, 1, 10, -1, 10,   _
             -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = OphInteractionDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Pharmacy_12_CodeA") = New Object
        dataRow("Pharmacy_12_CodeB") = New Object
        dataRow("Interaction_Level") = New Object
        dataRow("Interaction_Rate_Id") = New Object
        dataRow("Serious_Degree_Id") = New Object
        dataRow("Catalog_Id") = New Object
        dataRow("Restriction_Id") = New Object
        dataRow("Is_Online_Remind") = New Object
        dataRow("First_Occur_Date") = New Object
        dataRow("Pause_Date") = New Object
        dataRow("Remind_Words") = New Object
        dataRow("Effect") = New Object
        dataRow("Turn") = New Object
        dataRow("Process") = New Object
        dataRow("Discuss") = New Object
        dataRow("Reference") = New Object
        dataRow("Dc") = New Object
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
            dt.Columns.Add("Pharmacy_12_CodeA")
            dt.Columns.Add("Pharmacy_12_CodeB")
            dt.Columns.Add("Interaction_Level")
            dt.Columns.Add("Interaction_Rate_Id")
            dt.Columns.Add("Serious_Degree_Id")
            dt.Columns.Add("Catalog_Id")
            dt.Columns.Add("Restriction_Id")
            dt.Columns.Add("Is_Online_Remind")
            dt.Columns.Add("First_Occur_Date")
            dt.Columns.Add("Pause_Date")
            dt.Columns.Add("Remind_Words")
            dt.Columns.Add("Effect")
            dt.Columns.Add("Turn")
            dt.Columns.Add("Process")
            dt.Columns.Add("Discuss")
            dt.Columns.Add("Reference")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Pharmacy_12_CodeA")
            pkColArray(1) = dt.Columns("Pharmacy_12_CodeB")
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
            dt.Columns.Add("Pharmacy_12_CodeA")
            dt.Columns("Pharmacy_12_CodeA").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Pharmacy_12_CodeB")
            dt.Columns("Pharmacy_12_CodeB").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Interaction_Level")
            dt.Columns("Interaction_Level").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Interaction_Rate_Id")
            dt.Columns("Interaction_Rate_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Serious_Degree_Id")
            dt.Columns("Serious_Degree_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Catalog_Id")
            dt.Columns("Catalog_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Restriction_Id")
            dt.Columns("Restriction_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Online_Remind")
            dt.Columns("Is_Online_Remind").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("First_Occur_Date")
            dt.Columns("First_Occur_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Pause_Date")
            dt.Columns("Pause_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Remind_Words")
            dt.Columns("Remind_Words").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Effect")
            dt.Columns("Effect").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Turn")
            dt.Columns("Turn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Process")
            dt.Columns("Process").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Discuss")
            dt.Columns("Discuss").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Reference")
            dt.Columns("Reference").DataType = System.Type.GetType("System.String")
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
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Pharmacy_12_CodeA")
            pkColArray(1) = dt.Columns("Pharmacy_12_CodeB")
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
            dt.Columns.Add("Pharmacy_12_CodeA")
            dt.Columns.Add("Pharmacy_12_CodeB")
            dt.Columns.Add("Interaction_Level")
            dt.Columns.Add("Interaction_Rate_Id")
            dt.Columns.Add("Serious_Degree_Id")
            dt.Columns.Add("Catalog_Id")
            dt.Columns.Add("Restriction_Id")
            dt.Columns.Add("Is_Online_Remind")
            dt.Columns.Add("First_Occur_Date")
            dt.Columns.Add("Pause_Date")
            dt.Columns.Add("Remind_Words")
            dt.Columns.Add("Effect")
            dt.Columns.Add("Turn")
            dt.Columns.Add("Process")
            dt.Columns.Add("Discuss")
            dt.Columns.Add("Reference")
            dt.Columns.Add("Dc")
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

  Class OPHInteractionPt
    Private m_Pharmacy_12_CodeA As String = "Pharmacy_12_CodeA"
    Public ReadOnly Property Pharmacy_12_CodeA() As System.String 
    Get
        Return m_Pharmacy_12_CodeA
    End Get
    End Property

    Private m_Pharmacy_12_CodeB As String = "Pharmacy_12_CodeB"
    Public ReadOnly Property Pharmacy_12_CodeB() As System.String 
    Get
        Return m_Pharmacy_12_CodeB
    End Get
    End Property

    Private m_Interaction_Level As String = "Interaction_Level"
    Public ReadOnly Property Interaction_Level() As System.String 
    Get
        Return m_Interaction_Level
    End Get
    End Property

    Private m_Interaction_Rate_Id As String = "Interaction_Rate_Id"
    Public ReadOnly Property Interaction_Rate_Id() As System.String 
    Get
        Return m_Interaction_Rate_Id
    End Get
    End Property

    Private m_Serious_Degree_Id As String = "Serious_Degree_Id"
    Public ReadOnly Property Serious_Degree_Id() As System.String 
    Get
        Return m_Serious_Degree_Id
    End Get
    End Property

    Private m_Catalog_Id As String = "Catalog_Id"
    Public ReadOnly Property Catalog_Id() As System.String 
    Get
        Return m_Catalog_Id
    End Get
    End Property

    Private m_Restriction_Id As String = "Restriction_Id"
    Public ReadOnly Property Restriction_Id() As System.String 
    Get
        Return m_Restriction_Id
    End Get
    End Property

    Private m_Is_Online_Remind As String = "Is_Online_Remind"
    Public ReadOnly Property Is_Online_Remind() As System.String 
    Get
        Return m_Is_Online_Remind
    End Get
    End Property

    Private m_First_Occur_Date As String = "First_Occur_Date"
    Public ReadOnly Property First_Occur_Date() As System.String 
    Get
        Return m_First_Occur_Date
    End Get
    End Property

    Private m_Pause_Date As String = "Pause_Date"
    Public ReadOnly Property Pause_Date() As System.String 
    Get
        Return m_Pause_Date
    End Get
    End Property

    Private m_Remind_Words As String = "Remind_Words"
    Public ReadOnly Property Remind_Words() As System.String 
    Get
        Return m_Remind_Words
    End Get
    End Property

    Private m_Effect As String = "Effect"
    Public ReadOnly Property Effect() As System.String 
    Get
        Return m_Effect
    End Get
    End Property

    Private m_Turn As String = "Turn"
    Public ReadOnly Property Turn() As System.String 
    Get
        Return m_Turn
    End Get
    End Property

    Private m_Process As String = "Process"
    Public ReadOnly Property Process() As System.String 
    Get
        Return m_Process
    End Get
    End Property

    Private m_Discuss As String = "Discuss"
    Public ReadOnly Property Discuss() As System.String 
    Get
        Return m_Discuss
    End Get
    End Property

    Private m_Reference As String = "Reference"
    Public ReadOnly Property Reference() As System.String 
    Get
        Return m_Reference
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

  End Class

End Class
