Imports System.Data.SqlClient
Public Class IccFeedbackDuporderDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/10/17 下午 02:24:11
    Public Shared ReadOnly tableName as String="ICC_FeedBack_DupOrder"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Import_Sn", "Import_Year", "Import_Season", "Hospital_Id", "Media_Type",   _
             "Nhi_Ym", "Nhi_Type_Id", "Nhi_Date", "Idno", "Birth_Date",   _
             "Nhi_Case_Type", "Nhi_Seqno", "Order_No", "Order_Insu_Code", "Order_Tqty",   _
             "Order_Price", "Order_Amt", "Order_Days", "Order_Left_Days", "Order_Earlier_Id",   _
             "Order_Excute_time", "Order_Execute_End_Time", "Dup_days", "Dup_Amt", "Dup_Flag",   _
             "Create_User", "Create_Time", "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.DateTime", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             13, 3, 1, 10, 2,   _
             5, 1, 7, 10, 7,   _
             2, 6, 5, 12, 7,   _
             9, 8, 2, 10, 2,   _
             7, 7, 4, 10, 1,   _
             10, -1, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccFeedbackDuporderDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Import_Sn") = New Object
        dataRow("Import_Year") = New Object
        dataRow("Import_Season") = New Object
        dataRow("Hospital_Id") = New Object
        dataRow("Media_Type") = New Object
        dataRow("Nhi_Ym") = New Object
        dataRow("Nhi_Type_Id") = New Object
        dataRow("Nhi_Date") = New Object
        dataRow("Idno") = New Object
        dataRow("Birth_Date") = New Object
        dataRow("Nhi_Case_Type") = New Object
        dataRow("Nhi_Seqno") = New Object
        dataRow("Order_No") = New Object
        dataRow("Order_Insu_Code") = New Object
        dataRow("Order_Tqty") = New Object
        dataRow("Order_Price") = New Object
        dataRow("Order_Amt") = New Object
        dataRow("Order_Days") = New Object
        dataRow("Order_Left_Days") = New Object
        dataRow("Order_Earlier_Id") = New Object
        dataRow("Order_Excute_time") = New Object
        dataRow("Order_Execute_End_Time") = New Object
        dataRow("Dup_days") = New Object
        dataRow("Dup_Amt") = New Object
        dataRow("Dup_Flag") = New Object
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
            dt.Columns.Add("Import_Sn")
            dt.Columns.Add("Import_Year")
            dt.Columns.Add("Import_Season")
            dt.Columns.Add("Hospital_Id")
            dt.Columns.Add("Media_Type")
            dt.Columns.Add("Nhi_Ym")
            dt.Columns.Add("Nhi_Type_Id")
            dt.Columns.Add("Nhi_Date")
            dt.Columns.Add("Idno")
            dt.Columns.Add("Birth_Date")
            dt.Columns.Add("Nhi_Case_Type")
            dt.Columns.Add("Nhi_Seqno")
            dt.Columns.Add("Order_No")
            dt.Columns.Add("Order_Insu_Code")
            dt.Columns.Add("Order_Tqty")
            dt.Columns.Add("Order_Price")
            dt.Columns.Add("Order_Amt")
            dt.Columns.Add("Order_Days")
            dt.Columns.Add("Order_Left_Days")
            dt.Columns.Add("Order_Earlier_Id")
            dt.Columns.Add("Order_Excute_time")
            dt.Columns.Add("Order_Execute_End_Time")
            dt.Columns.Add("Dup_days")
            dt.Columns.Add("Dup_Amt")
            dt.Columns.Add("Dup_Flag")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Import_Sn")
            pkColArray(1) = dt.Columns("Import_Year")
            pkColArray(2) = dt.Columns("Import_Season")
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
            dt.Columns.Add("Import_Sn")
            dt.Columns("Import_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Import_Year")
            dt.Columns("Import_Year").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Import_Season")
            dt.Columns("Import_Season").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Hospital_Id")
            dt.Columns("Hospital_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Media_Type")
            dt.Columns("Media_Type").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Nhi_Ym")
            dt.Columns("Nhi_Ym").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Nhi_Type_Id")
            dt.Columns("Nhi_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Nhi_Date")
            dt.Columns("Nhi_Date").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Idno")
            dt.Columns("Idno").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Birth_Date")
            dt.Columns("Birth_Date").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Nhi_Case_Type")
            dt.Columns("Nhi_Case_Type").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Nhi_Seqno")
            dt.Columns("Nhi_Seqno").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_No")
            dt.Columns("Order_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Insu_Code")
            dt.Columns("Order_Insu_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Tqty")
            dt.Columns("Order_Tqty").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Price")
            dt.Columns("Order_Price").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Amt")
            dt.Columns("Order_Amt").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Days")
            dt.Columns("Order_Days").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Left_Days")
            dt.Columns("Order_Left_Days").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Earlier_Id")
            dt.Columns("Order_Earlier_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Excute_time")
            dt.Columns("Order_Excute_time").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Execute_End_Time")
            dt.Columns("Order_Execute_End_Time").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dup_days")
            dt.Columns("Dup_days").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dup_Amt")
            dt.Columns("Dup_Amt").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dup_Flag")
            dt.Columns("Dup_Flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Import_Sn")
            pkColArray(1) = dt.Columns("Import_Year")
            pkColArray(2) = dt.Columns("Import_Season")
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
            dt.Columns.Add("Import_Sn")
            dt.Columns.Add("Import_Year")
            dt.Columns.Add("Import_Season")
            dt.Columns.Add("Hospital_Id")
            dt.Columns.Add("Media_Type")
            dt.Columns.Add("Nhi_Ym")
            dt.Columns.Add("Nhi_Type_Id")
            dt.Columns.Add("Nhi_Date")
            dt.Columns.Add("Idno")
            dt.Columns.Add("Birth_Date")
            dt.Columns.Add("Nhi_Case_Type")
            dt.Columns.Add("Nhi_Seqno")
            dt.Columns.Add("Order_No")
            dt.Columns.Add("Order_Insu_Code")
            dt.Columns.Add("Order_Tqty")
            dt.Columns.Add("Order_Price")
            dt.Columns.Add("Order_Amt")
            dt.Columns.Add("Order_Days")
            dt.Columns.Add("Order_Left_Days")
            dt.Columns.Add("Order_Earlier_Id")
            dt.Columns.Add("Order_Excute_time")
            dt.Columns.Add("Order_Execute_End_Time")
            dt.Columns.Add("Dup_days")
            dt.Columns.Add("Dup_Amt")
            dt.Columns.Add("Dup_Flag")
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

  Class ICCFeedBackDupOrderPt
    Private m_Import_Sn As String = "Import_Sn"
    Public ReadOnly Property Import_Sn() As System.String 
    Get
        Return m_Import_Sn
    End Get
    End Property

    Private m_Import_Year As String = "Import_Year"
    Public ReadOnly Property Import_Year() As System.String 
    Get
        Return m_Import_Year
    End Get
    End Property

    Private m_Import_Season As String = "Import_Season"
    Public ReadOnly Property Import_Season() As System.String 
    Get
        Return m_Import_Season
    End Get
    End Property

    Private m_Hospital_Id As String = "Hospital_Id"
    Public ReadOnly Property Hospital_Id() As System.String 
    Get
        Return m_Hospital_Id
    End Get
    End Property

    Private m_Media_Type As String = "Media_Type"
    Public ReadOnly Property Media_Type() As System.String 
    Get
        Return m_Media_Type
    End Get
    End Property

    Private m_Nhi_Ym As String = "Nhi_Ym"
    Public ReadOnly Property Nhi_Ym() As System.String 
    Get
        Return m_Nhi_Ym
    End Get
    End Property

    Private m_Nhi_Type_Id As String = "Nhi_Type_Id"
    Public ReadOnly Property Nhi_Type_Id() As System.String 
    Get
        Return m_Nhi_Type_Id
    End Get
    End Property

    Private m_Nhi_Date As String = "Nhi_Date"
    Public ReadOnly Property Nhi_Date() As System.String 
    Get
        Return m_Nhi_Date
    End Get
    End Property

    Private m_Idno As String = "Idno"
    Public ReadOnly Property Idno() As System.String 
    Get
        Return m_Idno
    End Get
    End Property

    Private m_Birth_Date As String = "Birth_Date"
    Public ReadOnly Property Birth_Date() As System.String 
    Get
        Return m_Birth_Date
    End Get
    End Property

    Private m_Nhi_Case_Type As String = "Nhi_Case_Type"
    Public ReadOnly Property Nhi_Case_Type() As System.String 
    Get
        Return m_Nhi_Case_Type
    End Get
    End Property

    Private m_Nhi_Seqno As String = "Nhi_Seqno"
    Public ReadOnly Property Nhi_Seqno() As System.String 
    Get
        Return m_Nhi_Seqno
    End Get
    End Property

    Private m_Order_No As String = "Order_No"
    Public ReadOnly Property Order_No() As System.String 
    Get
        Return m_Order_No
    End Get
    End Property

    Private m_Order_Insu_Code As String = "Order_Insu_Code"
    Public ReadOnly Property Order_Insu_Code() As System.String 
    Get
        Return m_Order_Insu_Code
    End Get
    End Property

    Private m_Order_Tqty As String = "Order_Tqty"
    Public ReadOnly Property Order_Tqty() As System.String 
    Get
        Return m_Order_Tqty
    End Get
    End Property

    Private m_Order_Price As String = "Order_Price"
    Public ReadOnly Property Order_Price() As System.String 
    Get
        Return m_Order_Price
    End Get
    End Property

    Private m_Order_Amt As String = "Order_Amt"
    Public ReadOnly Property Order_Amt() As System.String 
    Get
        Return m_Order_Amt
    End Get
    End Property

    Private m_Order_Days As String = "Order_Days"
    Public ReadOnly Property Order_Days() As System.String 
    Get
        Return m_Order_Days
    End Get
    End Property

    Private m_Order_Left_Days As String = "Order_Left_Days"
    Public ReadOnly Property Order_Left_Days() As System.String 
    Get
        Return m_Order_Left_Days
    End Get
    End Property

    Private m_Order_Earlier_Id As String = "Order_Earlier_Id"
    Public ReadOnly Property Order_Earlier_Id() As System.String 
    Get
        Return m_Order_Earlier_Id
    End Get
    End Property

    Private m_Order_Excute_time As String = "Order_Excute_time"
    Public ReadOnly Property Order_Excute_time() As System.String 
    Get
        Return m_Order_Excute_time
    End Get
    End Property

    Private m_Order_Execute_End_Time As String = "Order_Execute_End_Time"
    Public ReadOnly Property Order_Execute_End_Time() As System.String 
    Get
        Return m_Order_Execute_End_Time
    End Get
    End Property

    Private m_Dup_days As String = "Dup_days"
    Public ReadOnly Property Dup_days() As System.String 
    Get
        Return m_Dup_days
    End Get
    End Property

    Private m_Dup_Amt As String = "Dup_Amt"
    Public ReadOnly Property Dup_Amt() As System.String 
    Get
        Return m_Dup_Amt
    End Get
    End Property

    Private m_Dup_Flag As String = "Dup_Flag"
    Public ReadOnly Property Dup_Flag() As System.String 
    Get
        Return m_Dup_Flag
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
