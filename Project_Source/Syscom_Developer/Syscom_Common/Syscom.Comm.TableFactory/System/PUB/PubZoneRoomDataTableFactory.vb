Imports System.Data.SqlClient
Public Class PubZoneRoomDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/11/8 18:59:28
    Public Shared ReadOnly tableName as String="PUB_Zone_Room"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Zone_Id", "Room_Code", "Tel_Ext_No", "Room_Name", "Room_En_Name",   _
             "Dc", "Create_User", "Create_Time", "Modified_User", "Modified_Time",   _
             "Floor"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime",   _
             "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             5, 5, 4, 100, 100,   _
             1, 10, -1, 10, -1,   _
             10}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubZoneRoomDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Zone_Id") = New Object
        dataRow("Room_Code") = New Object
        dataRow("Tel_Ext_No") = New Object
        dataRow("Room_Name") = New Object
        dataRow("Room_En_Name") = New Object
        dataRow("Dc") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Floor") = New Object
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
            dt.Columns.Add("Zone_Id")
            dt.Columns.Add("Room_Code")
            dt.Columns.Add("Tel_Ext_No")
            dt.Columns.Add("Room_Name")
            dt.Columns.Add("Room_En_Name")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Floor")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Zone_Id")
            pkColArray(1) = dt.Columns("Room_Code")
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
            dt.Columns.Add("Zone_Id")
            dt.Columns("Zone_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Room_Code")
            dt.Columns("Room_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Tel_Ext_No")
            dt.Columns("Tel_Ext_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Room_Name")
            dt.Columns("Room_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Room_En_Name")
            dt.Columns("Room_En_Name").DataType = System.Type.GetType("System.String")
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
            dt.Columns.Add("Floor")
            dt.Columns("Floor").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Zone_Id")
            pkColArray(1) = dt.Columns("Room_Code")
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
            dt.Columns.Add("Zone_Id")
            dt.Columns.Add("Room_Code")
            dt.Columns.Add("Tel_Ext_No")
            dt.Columns.Add("Room_Name")
            dt.Columns.Add("Room_En_Name")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Floor")
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

  Class PUBZoneRoomPt
    Private m_Zone_Id As String = "Zone_Id"
    Public ReadOnly Property Zone_Id() As System.String 
    Get
        Return m_Zone_Id
    End Get
    End Property

    Private m_Room_Code As String = "Room_Code"
    Public ReadOnly Property Room_Code() As System.String 
    Get
        Return m_Room_Code
    End Get
    End Property

    Private m_Tel_Ext_No As String = "Tel_Ext_No"
    Public ReadOnly Property Tel_Ext_No() As System.String 
    Get
        Return m_Tel_Ext_No
    End Get
    End Property

    Private m_Room_Name As String = "Room_Name"
    Public ReadOnly Property Room_Name() As System.String 
    Get
        Return m_Room_Name
    End Get
    End Property

    Private m_Room_En_Name As String = "Room_En_Name"
    Public ReadOnly Property Room_En_Name() As System.String 
    Get
        Return m_Room_En_Name
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

    Private m_Floor As String = "Floor"
    Public ReadOnly Property Floor() As System.String 
    Get
        Return m_Floor
    End Get
    End Property

  End Class

End Class
