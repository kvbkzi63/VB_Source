Imports System.Data.SqlClient
Public Class PubPatientPersonalHabitsDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/8/4 下午 05:22:44
    Public Shared ReadOnly tableName as String="PUB_Patient_Personal_Habits"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Chart_No", "Smoke_Id", "Smoke_Advise", "Smoke_Qty", "Smoke_Year",   _
             "Drink_Wine_Id", "Wine_Kind", "Wine_Qty", "Wine_Year", "Eat_Nut_Id",   _
             "Nut_Advise", "Nut_Qty", "Nut_Year", "Exercise_Id", "Exercise_Year",   _
             "Last_Ask_Date", "Advise_Date", "Advise_User", "Create_User", "Create_Time",   _
             "Modified_User", "Modified_Time", "Is_Passive_Smoking", "Is_Smoker_Advise", "Smoker_Advise_Date",   _
             "Smoker_Name", "Smoker_Relation"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.Int32", "System.Decimal",   _
             "System.String", "System.String", "System.Decimal", "System.Decimal", "System.String",   _
             "System.String", "System.Int32", "System.Decimal", "System.String", "System.Decimal",   _
             "System.DateTime", "System.DateTime", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.DateTime", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 5, 1, -1, -1,   _
             5, 50, -1, -1, 5,   _
             1, -1, -1, 5, -1,   _
             -1, -1, 10, 10, -1,   _
             10, -1, 1, 1, -1,   _
             50, 10}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubPatientPersonalHabitsDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Chart_No") = New Object
        dataRow("Smoke_Id") = New Object
        dataRow("Smoke_Advise") = New Object
        dataRow("Smoke_Qty") = New Object
        dataRow("Smoke_Year") = New Object
        dataRow("Drink_Wine_Id") = New Object
        dataRow("Wine_Kind") = New Object
        dataRow("Wine_Qty") = New Object
        dataRow("Wine_Year") = New Object
        dataRow("Eat_Nut_Id") = New Object
        dataRow("Nut_Advise") = New Object
        dataRow("Nut_Qty") = New Object
        dataRow("Nut_Year") = New Object
        dataRow("Exercise_Id") = New Object
        dataRow("Exercise_Year") = New Object
        dataRow("Last_Ask_Date") = New Object
        dataRow("Advise_Date") = New Object
        dataRow("Advise_User") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Is_Passive_Smoking") = New Object
        dataRow("Is_Smoker_Advise") = New Object
        dataRow("Smoker_Advise_Date") = New Object
        dataRow("Smoker_Name") = New Object
        dataRow("Smoker_Relation") = New Object
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
            dt.Columns.Add("Smoke_Id")
            dt.Columns.Add("Smoke_Advise")
            dt.Columns.Add("Smoke_Qty")
            dt.Columns.Add("Smoke_Year")
            dt.Columns.Add("Drink_Wine_Id")
            dt.Columns.Add("Wine_Kind")
            dt.Columns.Add("Wine_Qty")
            dt.Columns.Add("Wine_Year")
            dt.Columns.Add("Eat_Nut_Id")
            dt.Columns.Add("Nut_Advise")
            dt.Columns.Add("Nut_Qty")
            dt.Columns.Add("Nut_Year")
            dt.Columns.Add("Exercise_Id")
            dt.Columns.Add("Exercise_Year")
            dt.Columns.Add("Last_Ask_Date")
            dt.Columns.Add("Advise_Date")
            dt.Columns.Add("Advise_User")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Is_Passive_Smoking")
            dt.Columns.Add("Is_Smoker_Advise")
            dt.Columns.Add("Smoker_Advise_Date")
            dt.Columns.Add("Smoker_Name")
            dt.Columns.Add("Smoker_Relation")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
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
            dt.Columns.Add("Smoke_Id")
            dt.Columns("Smoke_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Smoke_Advise")
            dt.Columns("Smoke_Advise").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Smoke_Qty")
            dt.Columns("Smoke_Qty").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Smoke_Year")
            dt.Columns("Smoke_Year").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Drink_Wine_Id")
            dt.Columns("Drink_Wine_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Wine_Kind")
            dt.Columns("Wine_Kind").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Wine_Qty")
            dt.Columns("Wine_Qty").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Wine_Year")
            dt.Columns("Wine_Year").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Eat_Nut_Id")
            dt.Columns("Eat_Nut_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Nut_Advise")
            dt.Columns("Nut_Advise").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Nut_Qty")
            dt.Columns("Nut_Qty").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Nut_Year")
            dt.Columns("Nut_Year").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Exercise_Id")
            dt.Columns("Exercise_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Exercise_Year")
            dt.Columns("Exercise_Year").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Last_Ask_Date")
            dt.Columns("Last_Ask_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Advise_Date")
            dt.Columns("Advise_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Advise_User")
            dt.Columns("Advise_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Is_Passive_Smoking")
            dt.Columns("Is_Passive_Smoking").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Smoker_Advise")
            dt.Columns("Is_Smoker_Advise").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Smoker_Advise_Date")
            dt.Columns("Smoker_Advise_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Smoker_Name")
            dt.Columns("Smoker_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Smoker_Relation")
            dt.Columns("Smoker_Relation").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
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
            dt.Columns.Add("Smoke_Id")
            dt.Columns.Add("Smoke_Advise")
            dt.Columns.Add("Smoke_Qty")
            dt.Columns.Add("Smoke_Year")
            dt.Columns.Add("Drink_Wine_Id")
            dt.Columns.Add("Wine_Kind")
            dt.Columns.Add("Wine_Qty")
            dt.Columns.Add("Wine_Year")
            dt.Columns.Add("Eat_Nut_Id")
            dt.Columns.Add("Nut_Advise")
            dt.Columns.Add("Nut_Qty")
            dt.Columns.Add("Nut_Year")
            dt.Columns.Add("Exercise_Id")
            dt.Columns.Add("Exercise_Year")
            dt.Columns.Add("Last_Ask_Date")
            dt.Columns.Add("Advise_Date")
            dt.Columns.Add("Advise_User")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Is_Passive_Smoking")
            dt.Columns.Add("Is_Smoker_Advise")
            dt.Columns.Add("Smoker_Advise_Date")
            dt.Columns.Add("Smoker_Name")
            dt.Columns.Add("Smoker_Relation")
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

  Class PUBPatientPersonalHabitsPt
    Private m_Chart_No As String = "Chart_No"
    Public ReadOnly Property Chart_No() As System.String 
    Get
        Return m_Chart_No
    End Get
    End Property

    Private m_Smoke_Id As String = "Smoke_Id"
    Public ReadOnly Property Smoke_Id() As System.String 
    Get
        Return m_Smoke_Id
    End Get
    End Property

    Private m_Smoke_Advise As String = "Smoke_Advise"
    Public ReadOnly Property Smoke_Advise() As System.String 
    Get
        Return m_Smoke_Advise
    End Get
    End Property

    Private m_Smoke_Qty As String = "Smoke_Qty"
    Public ReadOnly Property Smoke_Qty() As System.String 
    Get
        Return m_Smoke_Qty
    End Get
    End Property

    Private m_Smoke_Year As String = "Smoke_Year"
    Public ReadOnly Property Smoke_Year() As System.String 
    Get
        Return m_Smoke_Year
    End Get
    End Property

    Private m_Drink_Wine_Id As String = "Drink_Wine_Id"
    Public ReadOnly Property Drink_Wine_Id() As System.String 
    Get
        Return m_Drink_Wine_Id
    End Get
    End Property

    Private m_Wine_Kind As String = "Wine_Kind"
    Public ReadOnly Property Wine_Kind() As System.String 
    Get
        Return m_Wine_Kind
    End Get
    End Property

    Private m_Wine_Qty As String = "Wine_Qty"
    Public ReadOnly Property Wine_Qty() As System.String 
    Get
        Return m_Wine_Qty
    End Get
    End Property

    Private m_Wine_Year As String = "Wine_Year"
    Public ReadOnly Property Wine_Year() As System.String 
    Get
        Return m_Wine_Year
    End Get
    End Property

    Private m_Eat_Nut_Id As String = "Eat_Nut_Id"
    Public ReadOnly Property Eat_Nut_Id() As System.String 
    Get
        Return m_Eat_Nut_Id
    End Get
    End Property

    Private m_Nut_Advise As String = "Nut_Advise"
    Public ReadOnly Property Nut_Advise() As System.String 
    Get
        Return m_Nut_Advise
    End Get
    End Property

    Private m_Nut_Qty As String = "Nut_Qty"
    Public ReadOnly Property Nut_Qty() As System.String 
    Get
        Return m_Nut_Qty
    End Get
    End Property

    Private m_Nut_Year As String = "Nut_Year"
    Public ReadOnly Property Nut_Year() As System.String 
    Get
        Return m_Nut_Year
    End Get
    End Property

    Private m_Exercise_Id As String = "Exercise_Id"
    Public ReadOnly Property Exercise_Id() As System.String 
    Get
        Return m_Exercise_Id
    End Get
    End Property

    Private m_Exercise_Year As String = "Exercise_Year"
    Public ReadOnly Property Exercise_Year() As System.String 
    Get
        Return m_Exercise_Year
    End Get
    End Property

    Private m_Last_Ask_Date As String = "Last_Ask_Date"
    Public ReadOnly Property Last_Ask_Date() As System.String 
    Get
        Return m_Last_Ask_Date
    End Get
    End Property

    Private m_Advise_Date As String = "Advise_Date"
    Public ReadOnly Property Advise_Date() As System.String 
    Get
        Return m_Advise_Date
    End Get
    End Property

    Private m_Advise_User As String = "Advise_User"
    Public ReadOnly Property Advise_User() As System.String 
    Get
        Return m_Advise_User
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

    Private m_Is_Passive_Smoking As String = "Is_Passive_Smoking"
    Public ReadOnly Property Is_Passive_Smoking() As System.String 
    Get
        Return m_Is_Passive_Smoking
    End Get
    End Property

    Private m_Is_Smoker_Advise As String = "Is_Smoker_Advise"
    Public ReadOnly Property Is_Smoker_Advise() As System.String 
    Get
        Return m_Is_Smoker_Advise
    End Get
    End Property

    Private m_Smoker_Advise_Date As String = "Smoker_Advise_Date"
    Public ReadOnly Property Smoker_Advise_Date() As System.String 
    Get
        Return m_Smoker_Advise_Date
    End Get
    End Property

    Private m_Smoker_Name As String = "Smoker_Name"
    Public ReadOnly Property Smoker_Name() As System.String 
    Get
        Return m_Smoker_Name
    End Get
    End Property

    Private m_Smoker_Relation As String = "Smoker_Relation"
    Public ReadOnly Property Smoker_Relation() As System.String 
    Get
        Return m_Smoker_Relation
    End Get
    End Property

  End Class

End Class
