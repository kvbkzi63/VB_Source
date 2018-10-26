Imports System.Data.SqlClient
Public Class PubPatientTransfusionDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:53
    Public Shared ReadOnly tableName as String="PUB_Patient_Transfusion"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Chart_No", "Transfusion_Time", "Transfusion_No", "Anti_Body_Mark", "Anti_Body_Time",   _
             "Blood_Product", "Transfusion_Reaction", "Spec_No", "Create_User", "Create_Time",   _
             "Blood_Product1", "Blood_Qty1", "Blood_Product2", "Blood_Qty2", "Blood_Product3",   _
             "Blood_Qty3"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.DateTime", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.String", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.Decimal", "System.String", "System.Decimal", "System.String",   _
             "System.Decimal"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, -1, 12, 1, -1,   _
             50, 200, 15, 10, -1,   _
             10, -1, 10, -1, 10,   _
             -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubPatientTransfusionDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Chart_No") = New Object
        dataRow("Transfusion_Time") = New Object
        dataRow("Transfusion_No") = New Object
        dataRow("Anti_Body_Mark") = New Object
        dataRow("Anti_Body_Time") = New Object
        dataRow("Blood_Product") = New Object
        dataRow("Transfusion_Reaction") = New Object
        dataRow("Spec_No") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Blood_Product1") = New Object
        dataRow("Blood_Qty1") = New Object
        dataRow("Blood_Product2") = New Object
        dataRow("Blood_Qty2") = New Object
        dataRow("Blood_Product3") = New Object
        dataRow("Blood_Qty3") = New Object
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
            dt.Columns.Add("Transfusion_Time")
            dt.Columns.Add("Transfusion_No")
            dt.Columns.Add("Anti_Body_Mark")
            dt.Columns.Add("Anti_Body_Time")
            dt.Columns.Add("Blood_Product")
            dt.Columns.Add("Transfusion_Reaction")
            dt.Columns.Add("Spec_No")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Blood_Product1")
            dt.Columns.Add("Blood_Qty1")
            dt.Columns.Add("Blood_Product2")
            dt.Columns.Add("Blood_Qty2")
            dt.Columns.Add("Blood_Product3")
            dt.Columns.Add("Blood_Qty3")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Transfusion_Time")
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
            dt.Columns.Add("Transfusion_Time")
            dt.Columns("Transfusion_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Transfusion_No")
            dt.Columns("Transfusion_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Anti_Body_Mark")
            dt.Columns("Anti_Body_Mark").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Anti_Body_Time")
            dt.Columns("Anti_Body_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Blood_Product")
            dt.Columns("Blood_Product").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Transfusion_Reaction")
            dt.Columns("Transfusion_Reaction").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Spec_No")
            dt.Columns("Spec_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Blood_Product1")
            dt.Columns("Blood_Product1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Blood_Qty1")
            dt.Columns("Blood_Qty1").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Blood_Product2")
            dt.Columns("Blood_Product2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Blood_Qty2")
            dt.Columns("Blood_Qty2").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Blood_Product3")
            dt.Columns("Blood_Product3").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Blood_Qty3")
            dt.Columns("Blood_Qty3").DataType = System.Type.GetType("System.Decimal")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Transfusion_Time")
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
            dt.Columns.Add("Transfusion_Time")
            dt.Columns.Add("Transfusion_No")
            dt.Columns.Add("Anti_Body_Mark")
            dt.Columns.Add("Anti_Body_Time")
            dt.Columns.Add("Blood_Product")
            dt.Columns.Add("Transfusion_Reaction")
            dt.Columns.Add("Spec_No")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Blood_Product1")
            dt.Columns.Add("Blood_Qty1")
            dt.Columns.Add("Blood_Product2")
            dt.Columns.Add("Blood_Qty2")
            dt.Columns.Add("Blood_Product3")
            dt.Columns.Add("Blood_Qty3")
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

  Class PUBPatientTransfusionPt
    Private m_Chart_No As String = "Chart_No"
    Public ReadOnly Property Chart_No() As System.String 
    Get
        Return m_Chart_No
    End Get
    End Property

    Private m_Transfusion_Time As String = "Transfusion_Time"
    Public ReadOnly Property Transfusion_Time() As System.String 
    Get
        Return m_Transfusion_Time
    End Get
    End Property

    Private m_Transfusion_No As String = "Transfusion_No"
    Public ReadOnly Property Transfusion_No() As System.String 
    Get
        Return m_Transfusion_No
    End Get
    End Property

    Private m_Anti_Body_Mark As String = "Anti_Body_Mark"
    Public ReadOnly Property Anti_Body_Mark() As System.String 
    Get
        Return m_Anti_Body_Mark
    End Get
    End Property

    Private m_Anti_Body_Time As String = "Anti_Body_Time"
    Public ReadOnly Property Anti_Body_Time() As System.String 
    Get
        Return m_Anti_Body_Time
    End Get
    End Property

    Private m_Blood_Product As String = "Blood_Product"
    Public ReadOnly Property Blood_Product() As System.String 
    Get
        Return m_Blood_Product
    End Get
    End Property

    Private m_Transfusion_Reaction As String = "Transfusion_Reaction"
    Public ReadOnly Property Transfusion_Reaction() As System.String 
    Get
        Return m_Transfusion_Reaction
    End Get
    End Property

    Private m_Spec_No As String = "Spec_No"
    Public ReadOnly Property Spec_No() As System.String 
    Get
        Return m_Spec_No
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

    Private m_Blood_Product1 As String = "Blood_Product1"
    Public ReadOnly Property Blood_Product1() As System.String 
    Get
        Return m_Blood_Product1
    End Get
    End Property

    Private m_Blood_Qty1 As String = "Blood_Qty1"
    Public ReadOnly Property Blood_Qty1() As System.String 
    Get
        Return m_Blood_Qty1
    End Get
    End Property

    Private m_Blood_Product2 As String = "Blood_Product2"
    Public ReadOnly Property Blood_Product2() As System.String 
    Get
        Return m_Blood_Product2
    End Get
    End Property

    Private m_Blood_Qty2 As String = "Blood_Qty2"
    Public ReadOnly Property Blood_Qty2() As System.String 
    Get
        Return m_Blood_Qty2
    End Get
    End Property

    Private m_Blood_Product3 As String = "Blood_Product3"
    Public ReadOnly Property Blood_Product3() As System.String 
    Get
        Return m_Blood_Product3
    End Get
    End Property

    Private m_Blood_Qty3 As String = "Blood_Qty3"
    Public ReadOnly Property Blood_Qty3() As System.String 
    Get
        Return m_Blood_Qty3
    End Get
    End Property

  End Class

End Class
