Imports System.Data.SqlClient
Public Class PubIssItemDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/6/17 下午 06:09:59
    Public Shared ReadOnly tableName as String="PUB_ISS_Item"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Region_Id", "Small_Region", "Score", "Item_No", "Item_Name",   _
             "Add_Score", "Add_Score_Note", "Dc", "Create_User", "Create_Time",   _
             "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.Int32", "System.Int32", "System.String",   _
             "System.Int32", "System.String", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             5, 10, -1, -1, 100,   _
             -1, 100, 1, 10, -1,   _
             10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubIssItemDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Region_Id") = New Object
        dataRow("Small_Region") = New Object
        dataRow("Score") = New Object
        dataRow("Item_No") = New Object
        dataRow("Item_Name") = New Object
        dataRow("Add_Score") = New Object
        dataRow("Add_Score_Note") = New Object
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
            dt.Columns.Add("Region_Id")
            dt.Columns.Add("Small_Region")
            dt.Columns.Add("Score")
            dt.Columns.Add("Item_No")
            dt.Columns.Add("Item_Name")
            dt.Columns.Add("Add_Score")
            dt.Columns.Add("Add_Score_Note")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(3) As DataColumn 
            pkColArray(0) = dt.Columns("Region_Id")
            pkColArray(1) = dt.Columns("Small_Region")
            pkColArray(2) = dt.Columns("Score")
            pkColArray(3) = dt.Columns("Item_No")
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
            dt.Columns.Add("Region_Id")
            dt.Columns("Region_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Small_Region")
            dt.Columns("Small_Region").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Score")
            dt.Columns("Score").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Item_No")
            dt.Columns("Item_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Item_Name")
            dt.Columns("Item_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Add_Score")
            dt.Columns("Add_Score").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Add_Score_Note")
            dt.Columns("Add_Score_Note").DataType = System.Type.GetType("System.String")
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
            Dim pkColArray(3) As DataColumn 
            pkColArray(0) = dt.Columns("Region_Id")
            pkColArray(1) = dt.Columns("Small_Region")
            pkColArray(2) = dt.Columns("Score")
            pkColArray(3) = dt.Columns("Item_No")
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
            dt.Columns.Add("Region_Id")
            dt.Columns.Add("Small_Region")
            dt.Columns.Add("Score")
            dt.Columns.Add("Item_No")
            dt.Columns.Add("Item_Name")
            dt.Columns.Add("Add_Score")
            dt.Columns.Add("Add_Score_Note")
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

  Class PUBISSItemPt
    Private m_Region_Id As String = "Region_Id"
    Public ReadOnly Property Region_Id() As System.String 
    Get
        Return m_Region_Id
    End Get
    End Property

    Private m_Small_Region As String = "Small_Region"
    Public ReadOnly Property Small_Region() As System.String 
    Get
        Return m_Small_Region
    End Get
    End Property

    Private m_Score As String = "Score"
    Public ReadOnly Property Score() As System.String 
    Get
        Return m_Score
    End Get
    End Property

    Private m_Item_No As String = "Item_No"
    Public ReadOnly Property Item_No() As System.String 
    Get
        Return m_Item_No
    End Get
    End Property

    Private m_Item_Name As String = "Item_Name"
    Public ReadOnly Property Item_Name() As System.String 
    Get
        Return m_Item_Name
    End Get
    End Property

    Private m_Add_Score As String = "Add_Score"
    Public ReadOnly Property Add_Score() As System.String 
    Get
        Return m_Add_Score
    End Get
    End Property

    Private m_Add_Score_Note As String = "Add_Score_Note"
    Public ReadOnly Property Add_Score_Note() As System.String 
    Get
        Return m_Add_Score_Note
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
