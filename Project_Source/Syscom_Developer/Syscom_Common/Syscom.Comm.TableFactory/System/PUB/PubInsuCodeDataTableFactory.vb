Imports System.Data.SqlClient
Public Class PubInsuCodeDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:50
    Public Shared ReadOnly tableName as String="PUB_Insu_Code"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Effect_Date", "Order_Type_Id", "Order_Code", "Insu_Code_Seq", "Is_Multi_Map_Flag",   _
             "Insu_Code", "Insu_Name", "Price", "Tqty", "Insu_Account_Id",   _
             "Is_Emg_Add", "Is_Kid_Add", "Is_Dental_Add", "Is_Holiday_Add", "Is_Dept_Add",   _
             "Dc", "End_Date", "Create_User", "Create_Time", "Modified_User",   _
             "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.DateTime", "System.String", "System.String", "System.Int32", "System.String",   _
             "System.String", "System.String", "System.Decimal", "System.Decimal", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.DateTime", "System.String", "System.DateTime", "System.String",   _
             "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             -1, 5, 20, -1, 1,   _
             20, 200, -1, -1, 5,   _
             1, 1, 1, 1, 1,   _
             1, -1, 10, -1, 10,   _
             -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubInsuCodeDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Effect_Date") = New Object
        dataRow("Order_Type_Id") = New Object
        dataRow("Order_Code") = New Object
        dataRow("Insu_Code_Seq") = New Object
        dataRow("Is_Multi_Map_Flag") = New Object
        dataRow("Insu_Code") = New Object
        dataRow("Insu_Name") = New Object
        dataRow("Price") = New Object
        dataRow("Tqty") = New Object
        dataRow("Insu_Account_Id") = New Object
        dataRow("Is_Emg_Add") = New Object
        dataRow("Is_Kid_Add") = New Object
        dataRow("Is_Dental_Add") = New Object
        dataRow("Is_Holiday_Add") = New Object
        dataRow("Is_Dept_Add") = New Object
        dataRow("Dc") = New Object
        dataRow("End_Date") = New Object
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
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("Order_Type_Id")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Insu_Code_Seq")
            dt.Columns.Add("Is_Multi_Map_Flag")
            dt.Columns.Add("Insu_Code")
            dt.Columns.Add("Insu_Name")
            dt.Columns.Add("Price")
            dt.Columns.Add("Tqty")
            dt.Columns.Add("Insu_Account_Id")
            dt.Columns.Add("Is_Emg_Add")
            dt.Columns.Add("Is_Kid_Add")
            dt.Columns.Add("Is_Dental_Add")
            dt.Columns.Add("Is_Holiday_Add")
            dt.Columns.Add("Is_Dept_Add")
            dt.Columns.Add("Dc")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(3) As DataColumn 
            pkColArray(0) = dt.Columns("Effect_Date")
            pkColArray(1) = dt.Columns("Order_Type_Id")
            pkColArray(2) = dt.Columns("Order_Code")
            pkColArray(3) = dt.Columns("Insu_Code_Seq")
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
            dt.Columns.Add("Effect_Date")
            dt.Columns("Effect_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Order_Type_Id")
            dt.Columns("Order_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Code_Seq")
            dt.Columns("Insu_Code_Seq").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Is_Multi_Map_Flag")
            dt.Columns("Is_Multi_Map_Flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Code")
            dt.Columns("Insu_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Name")
            dt.Columns("Insu_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Price")
            dt.Columns("Price").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Tqty")
            dt.Columns("Tqty").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Insu_Account_Id")
            dt.Columns("Insu_Account_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Emg_Add")
            dt.Columns("Is_Emg_Add").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Kid_Add")
            dt.Columns("Is_Kid_Add").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Dental_Add")
            dt.Columns("Is_Dental_Add").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Holiday_Add")
            dt.Columns("Is_Holiday_Add").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Dept_Add")
            dt.Columns("Is_Dept_Add").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dc")
            dt.Columns("Dc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("End_Date")
            dt.Columns("End_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(3) As DataColumn 
            pkColArray(0) = dt.Columns("Effect_Date")
            pkColArray(1) = dt.Columns("Order_Type_Id")
            pkColArray(2) = dt.Columns("Order_Code")
            pkColArray(3) = dt.Columns("Insu_Code_Seq")
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
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("Order_Type_Id")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Insu_Code_Seq")
            dt.Columns.Add("Is_Multi_Map_Flag")
            dt.Columns.Add("Insu_Code")
            dt.Columns.Add("Insu_Name")
            dt.Columns.Add("Price")
            dt.Columns.Add("Tqty")
            dt.Columns.Add("Insu_Account_Id")
            dt.Columns.Add("Is_Emg_Add")
            dt.Columns.Add("Is_Kid_Add")
            dt.Columns.Add("Is_Dental_Add")
            dt.Columns.Add("Is_Holiday_Add")
            dt.Columns.Add("Is_Dept_Add")
            dt.Columns.Add("Dc")
            dt.Columns.Add("End_Date")
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

  Class PUBInsuCodePt
    Private m_Effect_Date As String = "Effect_Date"
    Public ReadOnly Property Effect_Date() As System.String 
    Get
        Return m_Effect_Date
    End Get
    End Property

    Private m_Order_Type_Id As String = "Order_Type_Id"
    Public ReadOnly Property Order_Type_Id() As System.String 
    Get
        Return m_Order_Type_Id
    End Get
    End Property

    Private m_Order_Code As String = "Order_Code"
    Public ReadOnly Property Order_Code() As System.String 
    Get
        Return m_Order_Code
    End Get
    End Property

    Private m_Insu_Code_Seq As String = "Insu_Code_Seq"
    Public ReadOnly Property Insu_Code_Seq() As System.String 
    Get
        Return m_Insu_Code_Seq
    End Get
    End Property

    Private m_Is_Multi_Map_Flag As String = "Is_Multi_Map_Flag"
    Public ReadOnly Property Is_Multi_Map_Flag() As System.String 
    Get
        Return m_Is_Multi_Map_Flag
    End Get
    End Property

    Private m_Insu_Code As String = "Insu_Code"
    Public ReadOnly Property Insu_Code() As System.String 
    Get
        Return m_Insu_Code
    End Get
    End Property

    Private m_Insu_Name As String = "Insu_Name"
    Public ReadOnly Property Insu_Name() As System.String 
    Get
        Return m_Insu_Name
    End Get
    End Property

    Private m_Price As String = "Price"
    Public ReadOnly Property Price() As System.String 
    Get
        Return m_Price
    End Get
    End Property

    Private m_Tqty As String = "Tqty"
    Public ReadOnly Property Tqty() As System.String 
    Get
        Return m_Tqty
    End Get
    End Property

    Private m_Insu_Account_Id As String = "Insu_Account_Id"
    Public ReadOnly Property Insu_Account_Id() As System.String 
    Get
        Return m_Insu_Account_Id
    End Get
    End Property

    Private m_Is_Emg_Add As String = "Is_Emg_Add"
    Public ReadOnly Property Is_Emg_Add() As System.String 
    Get
        Return m_Is_Emg_Add
    End Get
    End Property

    Private m_Is_Kid_Add As String = "Is_Kid_Add"
    Public ReadOnly Property Is_Kid_Add() As System.String 
    Get
        Return m_Is_Kid_Add
    End Get
    End Property

    Private m_Is_Dental_Add As String = "Is_Dental_Add"
    Public ReadOnly Property Is_Dental_Add() As System.String 
    Get
        Return m_Is_Dental_Add
    End Get
    End Property

    Private m_Is_Holiday_Add As String = "Is_Holiday_Add"
    Public ReadOnly Property Is_Holiday_Add() As System.String 
    Get
        Return m_Is_Holiday_Add
    End Get
    End Property

    Private m_Is_Dept_Add As String = "Is_Dept_Add"
    Public ReadOnly Property Is_Dept_Add() As System.String 
    Get
        Return m_Is_Dept_Add
    End Get
    End Property

    Private m_Dc As String = "Dc"
    Public ReadOnly Property Dc() As System.String 
    Get
        Return m_Dc
    End Get
    End Property

    Private m_End_Date As String = "End_Date"
    Public ReadOnly Property End_Date() As System.String 
    Get
        Return m_End_Date
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
