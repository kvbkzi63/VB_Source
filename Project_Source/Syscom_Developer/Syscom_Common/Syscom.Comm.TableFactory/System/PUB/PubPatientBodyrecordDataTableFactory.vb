Imports System.Data.SqlClient
Public Class PubPatientBodyrecordDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:52
    Public Shared ReadOnly tableName as String="PUB_Patient_BodyRecord"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Chart_No", "Measure_Time", "Height", "Weight", "Pulse",   _
             "Breath", "Temperature", "Blood_Pressure", "Blood_Diastolic", "Create_User",   _
             "Create_Time", "Source_Type_Id", "Keyin_Unit"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.DateTime", "System.Decimal", "System.Decimal", "System.Int32",   _
             "System.Int32", "System.Decimal", "System.Decimal", "System.Decimal", "System.String",   _
             "System.DateTime", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, -1, -1, -1, -1,   _
             -1, -1, -1, -1, 10,   _
             -1, 5, 5}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubPatientBodyrecordDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Chart_No") = New Object
        dataRow("Measure_Time") = New Object
        dataRow("Height") = New Object
        dataRow("Weight") = New Object
        dataRow("Pulse") = New Object
        dataRow("Breath") = New Object
        dataRow("Temperature") = New Object
        dataRow("Blood_Pressure") = New Object
        dataRow("Blood_Diastolic") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Source_Type_Id") = New Object
        dataRow("Keyin_Unit") = New Object
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
            dt.Columns.Add("Measure_Time")
            dt.Columns.Add("Height")
            dt.Columns.Add("Weight")
            dt.Columns.Add("Pulse")
            dt.Columns.Add("Breath")
            dt.Columns.Add("Temperature")
            dt.Columns.Add("Blood_Pressure")
            dt.Columns.Add("Blood_Diastolic")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Source_Type_Id")
            dt.Columns.Add("Keyin_Unit")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Measure_Time")
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
            dt.Columns.Add("Measure_Time")
            dt.Columns("Measure_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Height")
            dt.Columns("Height").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Weight")
            dt.Columns("Weight").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Pulse")
            dt.Columns("Pulse").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Breath")
            dt.Columns("Breath").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Temperature")
            dt.Columns("Temperature").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Blood_Pressure")
            dt.Columns("Blood_Pressure").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Blood_Diastolic")
            dt.Columns("Blood_Diastolic").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Source_Type_Id")
            dt.Columns("Source_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Keyin_Unit")
            dt.Columns("Keyin_Unit").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Measure_Time")
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
            dt.Columns.Add("Measure_Time")
            dt.Columns.Add("Height")
            dt.Columns.Add("Weight")
            dt.Columns.Add("Pulse")
            dt.Columns.Add("Breath")
            dt.Columns.Add("Temperature")
            dt.Columns.Add("Blood_Pressure")
            dt.Columns.Add("Blood_Diastolic")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Source_Type_Id")
            dt.Columns.Add("Keyin_Unit")
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

  Class PUBPatientBodyRecordPt
    Private m_Chart_No As String = "Chart_No"
    Public ReadOnly Property Chart_No() As System.String 
    Get
        Return m_Chart_No
    End Get
    End Property

    Private m_Measure_Time As String = "Measure_Time"
    Public ReadOnly Property Measure_Time() As System.String 
    Get
        Return m_Measure_Time
    End Get
    End Property

    Private m_Height As String = "Height"
    Public ReadOnly Property Height() As System.String 
    Get
        Return m_Height
    End Get
    End Property

    Private m_Weight As String = "Weight"
    Public ReadOnly Property Weight() As System.String 
    Get
        Return m_Weight
    End Get
    End Property

    Private m_Pulse As String = "Pulse"
    Public ReadOnly Property Pulse() As System.String 
    Get
        Return m_Pulse
    End Get
    End Property

    Private m_Breath As String = "Breath"
    Public ReadOnly Property Breath() As System.String 
    Get
        Return m_Breath
    End Get
    End Property

    Private m_Temperature As String = "Temperature"
    Public ReadOnly Property Temperature() As System.String 
    Get
        Return m_Temperature
    End Get
    End Property

    Private m_Blood_Pressure As String = "Blood_Pressure"
    Public ReadOnly Property Blood_Pressure() As System.String 
    Get
        Return m_Blood_Pressure
    End Get
    End Property

    Private m_Blood_Diastolic As String = "Blood_Diastolic"
    Public ReadOnly Property Blood_Diastolic() As System.String 
    Get
        Return m_Blood_Diastolic
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

    Private m_Source_Type_Id As String = "Source_Type_Id"
    Public ReadOnly Property Source_Type_Id() As System.String 
    Get
        Return m_Source_Type_Id
    End Get
    End Property

    Private m_Keyin_Unit As String = "Keyin_Unit"
    Public ReadOnly Property Keyin_Unit() As System.String 
    Get
        Return m_Keyin_Unit
    End Get
    End Property

  End Class

End Class