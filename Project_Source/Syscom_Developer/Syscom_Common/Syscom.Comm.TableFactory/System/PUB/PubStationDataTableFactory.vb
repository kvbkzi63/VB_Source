Imports System.Data.SqlClient
Public Class PubStationDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:54
    Public Shared ReadOnly tableName as String="PUB_Station"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Station_No", "Station_Name", "Expand_Date", "Floor", "Unit_Dosage_Nature_Sign", _
             "Region_Kind", "Consumption_Unit", "Consumption_Name", "Station_Email", "Station_Ext_Tel", _
             "Dc", "Create_User", "Create_Time", "Modified_User", "Modified_Time" _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.DateTime", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             4, 20, -1, 2, 1,   _
             1, 10, 50, 100, 5,   _
             1, 10, -1, 10, -1  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubStationDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Station_No") = New Object
        dataRow("Station_Name") = New Object
        dataRow("Expand_Date") = New Object
        dataRow("Floor") = New Object
        dataRow("Unit_Dosage_Nature_Sign") = New Object
        dataRow("Region_Kind") = New Object
        dataRow("Consumption_Unit") = New Object
        dataRow("Consumption_Name") = New Object
        dataRow("Station_Email") = New Object
        dataRow("Station_Ext_Tel") = New Object
        dataRow("Dc") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataTable.Rows.Add(dataRow)
        dataSet.Tables.Add(dataTable)
    End Sub

    ''' <summary>
    '''取得資料庫表格的 DataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTable() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName)
            dt.Columns.Add("Station_No")
            dt.Columns.Add("Station_Name")
            dt.Columns.Add("Expand_Date")
            dt.Columns.Add("Floor")
            dt.Columns.Add("Unit_Dosage_Nature_Sign")
            dt.Columns.Add("Region_Kind")
            dt.Columns.Add("Consumption_Unit")
            dt.Columns.Add("Consumption_Name")
            dt.Columns.Add("Station_Email")
            dt.Columns.Add("Station_Ext_Tel")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(0) As DataColumn
            pkColArray(0) = dt.Columns("Station_No")
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
            dt.Columns.Add("Station_No")
            dt.Columns("Station_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Station_Name")
            dt.Columns("Station_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Expand_Date")
            dt.Columns("Expand_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Floor")
            dt.Columns("Floor").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Unit_Dosage_Nature_Sign")
            dt.Columns("Unit_Dosage_Nature_Sign").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Region_Kind")
            dt.Columns("Region_Kind").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Consumption_Unit")
            dt.Columns("Consumption_Unit").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Consumption_Name")
            dt.Columns("Consumption_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Station_Email")
            dt.Columns("Station_Email").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Station_Ext_Tel")
            dt.Columns("Station_Ext_Tel").DataType = System.Type.GetType("System.String")
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
            Dim pkColArray(0) As DataColumn
            pkColArray(0) = dt.Columns("Station_No")
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
            dt.Columns.Add("Station_No")
            dt.Columns.Add("Station_Name")
            dt.Columns.Add("Expand_Date")
            dt.Columns.Add("Floor")
            dt.Columns.Add("Unit_Dosage_Nature_Sign")
            dt.Columns.Add("Region_Kind")
            dt.Columns.Add("Consumption_Unit")
            dt.Columns.Add("Consumption_Name")
            dt.Columns.Add("Station_Email")
            dt.Columns.Add("Station_Ext_Tel")
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

    Class PUBStationPt
        Private m_Station_No As String = "Station_No"
        Public ReadOnly Property Station_No() As System.String
            Get
                Return m_Station_No
            End Get
        End Property

        Private m_Station_Name As String = "Station_Name"
        Public ReadOnly Property Station_Name() As System.String
            Get
                Return m_Station_Name
            End Get
        End Property

        Private m_Expand_Date As String = "Expand_Date"
        Public ReadOnly Property Expand_Date() As System.String
            Get
                Return m_Expand_Date
            End Get
        End Property

        Private m_Floor As String = "Floor"
        Public ReadOnly Property Floor() As System.String
            Get
                Return m_Floor
            End Get
        End Property

        Private m_Unit_Dosage_Nature_Sign As String = "Unit_Dosage_Nature_Sign"
        Public ReadOnly Property Unit_Dosage_Nature_Sign() As System.String
            Get
                Return m_Unit_Dosage_Nature_Sign
            End Get
        End Property

        Private m_Region_Kind As String = "Region_Kind"
        Public ReadOnly Property Region_Kind() As System.String
            Get
                Return m_Region_Kind
            End Get
        End Property

        Private m_Consumption_Unit As String = "Consumption_Unit"
        Public ReadOnly Property Consumption_Unit() As System.String
            Get
                Return m_Consumption_Unit
            End Get
        End Property

        Private m_Consumption_Name As String = "Consumption_Name"
        Public ReadOnly Property Consumption_Name() As System.String
            Get
                Return m_Consumption_Name
            End Get
        End Property

        Private m_Station_Email As String = "Station_Email"
        Public ReadOnly Property Station_Email() As System.String
            Get
                Return m_Station_Email
            End Get
        End Property

        Private m_Station_Ext_Tel As String = "Station_Ext_Tel"
        Public ReadOnly Property Station_Ext_Tel() As System.String
            Get
                Return m_Station_Ext_Tel
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
