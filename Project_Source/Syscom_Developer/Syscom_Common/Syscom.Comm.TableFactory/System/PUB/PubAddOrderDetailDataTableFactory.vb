Imports System.Data.SqlClient
Public Class PubAddOrderDetailDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/5/10 上午 11:08:54
    Public Shared ReadOnly tableName as String="PUB_Add_Order_Detail"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Add_Order_Code", "Add_Order_Detail_No", "Order_Code", "Is_By_Orig_Order_Code", "Dosage",   _
             "Dosage_Unit", "Days", "Tqty", "Tqty_Unit", "Usage_Code",   _
             "Frequency_Code", "Is_Compute", "Dc", "Self_Charge_Flag", "Insu_Charge_Flag",   _
             "Create_User", "Create_Time", "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Int32", "System.String", "System.String", "System.Decimal",   _
             "System.String", "System.Decimal", "System.Decimal", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.DateTime", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             20, -1, 20, 1, -1,   _
             8, -1, -1, 8, 10,   _
             10, 1, 1, 1, 1,   _
             10, -1, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubAddOrderDetailDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Add_Order_Code") = New Object
        dataRow("Add_Order_Detail_No") = New Object
        dataRow("Order_Code") = New Object
        dataRow("Is_By_Orig_Order_Code") = New Object
        dataRow("Dosage") = New Object
        dataRow("Dosage_Unit") = New Object
        dataRow("Days") = New Object
        dataRow("Tqty") = New Object
        dataRow("Tqty_Unit") = New Object
        dataRow("Usage_Code") = New Object
        dataRow("Frequency_Code") = New Object
        dataRow("Is_Compute") = New Object
        dataRow("Dc") = New Object
        dataRow("Self_Charge_Flag") = New Object
        dataRow("Insu_Charge_Flag") = New Object
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
            dt.Columns.Add("Add_Order_Code")
            dt.Columns.Add("Add_Order_Detail_No")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Is_By_Orig_Order_Code")
            dt.Columns.Add("Dosage")
            dt.Columns.Add("Dosage_Unit")
            dt.Columns.Add("Days")
            dt.Columns.Add("Tqty")
            dt.Columns.Add("Tqty_Unit")
            dt.Columns.Add("Usage_Code")
            dt.Columns.Add("Frequency_Code")
            dt.Columns.Add("Is_Compute")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Self_Charge_Flag")
            dt.Columns.Add("Insu_Charge_Flag")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Add_Order_Code")
            pkColArray(1) = dt.Columns("Add_Order_Detail_No")
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
            dt.Columns.Add("Add_Order_Code")
            dt.Columns("Add_Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Add_Order_Detail_No")
            dt.Columns("Add_Order_Detail_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_By_Orig_Order_Code")
            dt.Columns("Is_By_Orig_Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dosage")
            dt.Columns("Dosage").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Dosage_Unit")
            dt.Columns("Dosage_Unit").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Days")
            dt.Columns("Days").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Tqty")
            dt.Columns("Tqty").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Tqty_Unit")
            dt.Columns("Tqty_Unit").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Usage_Code")
            dt.Columns("Usage_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Frequency_Code")
            dt.Columns("Frequency_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Compute")
            dt.Columns("Is_Compute").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dc")
            dt.Columns("Dc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Self_Charge_Flag")
            dt.Columns("Self_Charge_Flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Charge_Flag")
            dt.Columns("Insu_Charge_Flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Add_Order_Code")
            pkColArray(1) = dt.Columns("Add_Order_Detail_No")
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
            dt.Columns.Add("Add_Order_Code")
            dt.Columns.Add("Add_Order_Detail_No")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Is_By_Orig_Order_Code")
            dt.Columns.Add("Dosage")
            dt.Columns.Add("Dosage_Unit")
            dt.Columns.Add("Days")
            dt.Columns.Add("Tqty")
            dt.Columns.Add("Tqty_Unit")
            dt.Columns.Add("Usage_Code")
            dt.Columns.Add("Frequency_Code")
            dt.Columns.Add("Is_Compute")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Self_Charge_Flag")
            dt.Columns.Add("Insu_Charge_Flag")
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

  Class PUBAddOrderDetailPt
    Private m_Add_Order_Code As String = "Add_Order_Code"
    Public ReadOnly Property Add_Order_Code() As System.String 
    Get
        Return m_Add_Order_Code
    End Get
    End Property

    Private m_Add_Order_Detail_No As String = "Add_Order_Detail_No"
    Public ReadOnly Property Add_Order_Detail_No() As System.String 
    Get
        Return m_Add_Order_Detail_No
    End Get
    End Property

    Private m_Order_Code As String = "Order_Code"
    Public ReadOnly Property Order_Code() As System.String 
    Get
        Return m_Order_Code
    End Get
    End Property

    Private m_Is_By_Orig_Order_Code As String = "Is_By_Orig_Order_Code"
    Public ReadOnly Property Is_By_Orig_Order_Code() As System.String 
    Get
        Return m_Is_By_Orig_Order_Code
    End Get
    End Property

    Private m_Dosage As String = "Dosage"
    Public ReadOnly Property Dosage() As System.String 
    Get
        Return m_Dosage
    End Get
    End Property

    Private m_Dosage_Unit As String = "Dosage_Unit"
    Public ReadOnly Property Dosage_Unit() As System.String 
    Get
        Return m_Dosage_Unit
    End Get
    End Property

    Private m_Days As String = "Days"
    Public ReadOnly Property Days() As System.String 
    Get
        Return m_Days
    End Get
    End Property

    Private m_Tqty As String = "Tqty"
    Public ReadOnly Property Tqty() As System.String 
    Get
        Return m_Tqty
    End Get
    End Property

    Private m_Tqty_Unit As String = "Tqty_Unit"
    Public ReadOnly Property Tqty_Unit() As System.String 
    Get
        Return m_Tqty_Unit
    End Get
    End Property

    Private m_Usage_Code As String = "Usage_Code"
    Public ReadOnly Property Usage_Code() As System.String 
    Get
        Return m_Usage_Code
    End Get
    End Property

    Private m_Frequency_Code As String = "Frequency_Code"
    Public ReadOnly Property Frequency_Code() As System.String 
    Get
        Return m_Frequency_Code
    End Get
    End Property

    Private m_Is_Compute As String = "Is_Compute"
    Public ReadOnly Property Is_Compute() As System.String 
    Get
        Return m_Is_Compute
    End Get
    End Property

    Private m_Dc As String = "Dc"
    Public ReadOnly Property Dc() As System.String 
    Get
        Return m_Dc
    End Get
    End Property

    Private m_Self_Charge_Flag As String = "Self_Charge_Flag"
    Public ReadOnly Property Self_Charge_Flag() As System.String 
    Get
        Return m_Self_Charge_Flag
    End Get
    End Property

    Private m_Insu_Charge_Flag As String = "Insu_Charge_Flag"
    Public ReadOnly Property Insu_Charge_Flag() As System.String 
    Get
        Return m_Insu_Charge_Flag
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
