Imports System.Data.SqlClient
Public Class PubOrderPriceDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/5/13 上午 08:50:28
    Public Shared ReadOnly tableName as String="PUB_Order_Price"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Effect_Date", "Order_Code", "Main_Identity_Id", "Price", "Add_Price",   _
             "Material_Ratio", "Material_Account_Id", "Order_Ratio", "Is_Emg_Add", "Is_Kid_Add",   _
             "Is_Dental_Add", "Is_Holiday_Add", "Is_Dept_Add", "Insu_Code", "Insu_Account_Id",   _
             "Insu_Order_Type_Id", "Opd_Add_Order_Code", "Emg_Add_Order_Code", "Ipd_Add_Order_Code", "Emg_Nursing_Add_Order_Code",   _
             "Ipd_Nursing_Add_Order_Code", "Insu_Group_Code", "Insu_Apply_Price", "Dc", "End_Date",   _
             "Create_User", "Create_Time", "Modified_User", "Modified_Time", "Charge_Flag"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.DateTime", "System.String", "System.String", "System.Decimal", "System.Decimal",   _
             "System.Decimal", "System.String", "System.Decimal", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.Decimal", "System.String", "System.DateTime",   _
             "System.String", "System.DateTime", "System.String", "System.DateTime", "System.String"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             -1, 20, 5, -1, -1,   _
             -1, 5, -1, 1, 1,   _
             1, 1, 1, 20, 5,   _
             5, 20, 20, 20, 20,   _
             20, 8, -1, 1, -1,   _
             10, -1, 10, -1, 1  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubOrderPriceDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Effect_Date") = New Object
        dataRow("Order_Code") = New Object
        dataRow("Main_Identity_Id") = New Object
        dataRow("Price") = New Object
        dataRow("Add_Price") = New Object
        dataRow("Material_Ratio") = New Object
        dataRow("Material_Account_Id") = New Object
        dataRow("Order_Ratio") = New Object
        dataRow("Is_Emg_Add") = New Object
        dataRow("Is_Kid_Add") = New Object
        dataRow("Is_Dental_Add") = New Object
        dataRow("Is_Holiday_Add") = New Object
        dataRow("Is_Dept_Add") = New Object
        dataRow("Insu_Code") = New Object
        dataRow("Insu_Account_Id") = New Object
        dataRow("Insu_Order_Type_Id") = New Object
        dataRow("Opd_Add_Order_Code") = New Object
        dataRow("Emg_Add_Order_Code") = New Object
        dataRow("Ipd_Add_Order_Code") = New Object
        dataRow("Emg_Nursing_Add_Order_Code") = New Object
        dataRow("Ipd_Nursing_Add_Order_Code") = New Object
        dataRow("Insu_Group_Code") = New Object
        dataRow("Insu_Apply_Price") = New Object
        dataRow("Dc") = New Object
        dataRow("End_Date") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Charge_Flag") = New Object
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
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Main_Identity_Id")
            dt.Columns.Add("Price")
            dt.Columns.Add("Add_Price")
            dt.Columns.Add("Material_Ratio")
            dt.Columns.Add("Material_Account_Id")
            dt.Columns.Add("Order_Ratio")
            dt.Columns.Add("Is_Emg_Add")
            dt.Columns.Add("Is_Kid_Add")
            dt.Columns.Add("Is_Dental_Add")
            dt.Columns.Add("Is_Holiday_Add")
            dt.Columns.Add("Is_Dept_Add")
            dt.Columns.Add("Insu_Code")
            dt.Columns.Add("Insu_Account_Id")
            dt.Columns.Add("Insu_Order_Type_Id")
            dt.Columns.Add("Opd_Add_Order_Code")
            dt.Columns.Add("Emg_Add_Order_Code")
            dt.Columns.Add("Ipd_Add_Order_Code")
            dt.Columns.Add("Emg_Nursing_Add_Order_Code")
            dt.Columns.Add("Ipd_Nursing_Add_Order_Code")
            dt.Columns.Add("Insu_Group_Code")
            dt.Columns.Add("Insu_Apply_Price")
            dt.Columns.Add("Dc")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Charge_Flag")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Effect_Date")
            pkColArray(1) = dt.Columns("Order_Code")
            pkColArray(2) = dt.Columns("Main_Identity_Id")
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
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Main_Identity_Id")
            dt.Columns("Main_Identity_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Price")
            dt.Columns("Price").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Add_Price")
            dt.Columns("Add_Price").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Material_Ratio")
            dt.Columns("Material_Ratio").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Material_Account_Id")
            dt.Columns("Material_Account_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Ratio")
            dt.Columns("Order_Ratio").DataType = System.Type.GetType("System.Decimal")
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
            dt.Columns.Add("Insu_Code")
            dt.Columns("Insu_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Account_Id")
            dt.Columns("Insu_Account_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Order_Type_Id")
            dt.Columns("Insu_Order_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Opd_Add_Order_Code")
            dt.Columns("Opd_Add_Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Emg_Add_Order_Code")
            dt.Columns("Emg_Add_Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Ipd_Add_Order_Code")
            dt.Columns("Ipd_Add_Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Emg_Nursing_Add_Order_Code")
            dt.Columns("Emg_Nursing_Add_Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Ipd_Nursing_Add_Order_Code")
            dt.Columns("Ipd_Nursing_Add_Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Group_Code")
            dt.Columns("Insu_Group_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Apply_Price")
            dt.Columns("Insu_Apply_Price").DataType = System.Type.GetType("System.Decimal")
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
            dt.Columns.Add("Charge_Flag")
            dt.Columns("Charge_Flag").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Effect_Date")
            pkColArray(1) = dt.Columns("Order_Code")
            pkColArray(2) = dt.Columns("Main_Identity_Id")
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
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Main_Identity_Id")
            dt.Columns.Add("Price")
            dt.Columns.Add("Add_Price")
            dt.Columns.Add("Material_Ratio")
            dt.Columns.Add("Material_Account_Id")
            dt.Columns.Add("Order_Ratio")
            dt.Columns.Add("Is_Emg_Add")
            dt.Columns.Add("Is_Kid_Add")
            dt.Columns.Add("Is_Dental_Add")
            dt.Columns.Add("Is_Holiday_Add")
            dt.Columns.Add("Is_Dept_Add")
            dt.Columns.Add("Insu_Code")
            dt.Columns.Add("Insu_Account_Id")
            dt.Columns.Add("Insu_Order_Type_Id")
            dt.Columns.Add("Opd_Add_Order_Code")
            dt.Columns.Add("Emg_Add_Order_Code")
            dt.Columns.Add("Ipd_Add_Order_Code")
            dt.Columns.Add("Emg_Nursing_Add_Order_Code")
            dt.Columns.Add("Ipd_Nursing_Add_Order_Code")
            dt.Columns.Add("Insu_Group_Code")
            dt.Columns.Add("Insu_Apply_Price")
            dt.Columns.Add("Dc")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Charge_Flag")
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

  Class PUBOrderPricePt
    Private m_Effect_Date As String = "Effect_Date"
    Public ReadOnly Property Effect_Date() As System.String 
    Get
        Return m_Effect_Date
    End Get
    End Property

    Private m_Order_Code As String = "Order_Code"
    Public ReadOnly Property Order_Code() As System.String 
    Get
        Return m_Order_Code
    End Get
    End Property

    Private m_Main_Identity_Id As String = "Main_Identity_Id"
    Public ReadOnly Property Main_Identity_Id() As System.String 
    Get
        Return m_Main_Identity_Id
    End Get
    End Property

    Private m_Price As String = "Price"
    Public ReadOnly Property Price() As System.String 
    Get
        Return m_Price
    End Get
    End Property

    Private m_Add_Price As String = "Add_Price"
    Public ReadOnly Property Add_Price() As System.String 
    Get
        Return m_Add_Price
    End Get
    End Property

    Private m_Material_Ratio As String = "Material_Ratio"
    Public ReadOnly Property Material_Ratio() As System.String 
    Get
        Return m_Material_Ratio
    End Get
    End Property

    Private m_Material_Account_Id As String = "Material_Account_Id"
    Public ReadOnly Property Material_Account_Id() As System.String 
    Get
        Return m_Material_Account_Id
    End Get
    End Property

    Private m_Order_Ratio As String = "Order_Ratio"
    Public ReadOnly Property Order_Ratio() As System.String 
    Get
        Return m_Order_Ratio
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

    Private m_Insu_Code As String = "Insu_Code"
    Public ReadOnly Property Insu_Code() As System.String 
    Get
        Return m_Insu_Code
    End Get
    End Property

    Private m_Insu_Account_Id As String = "Insu_Account_Id"
    Public ReadOnly Property Insu_Account_Id() As System.String 
    Get
        Return m_Insu_Account_Id
    End Get
    End Property

    Private m_Insu_Order_Type_Id As String = "Insu_Order_Type_Id"
    Public ReadOnly Property Insu_Order_Type_Id() As System.String 
    Get
        Return m_Insu_Order_Type_Id
    End Get
    End Property

    Private m_Opd_Add_Order_Code As String = "Opd_Add_Order_Code"
    Public ReadOnly Property Opd_Add_Order_Code() As System.String 
    Get
        Return m_Opd_Add_Order_Code
    End Get
    End Property

    Private m_Emg_Add_Order_Code As String = "Emg_Add_Order_Code"
    Public ReadOnly Property Emg_Add_Order_Code() As System.String 
    Get
        Return m_Emg_Add_Order_Code
    End Get
    End Property

    Private m_Ipd_Add_Order_Code As String = "Ipd_Add_Order_Code"
    Public ReadOnly Property Ipd_Add_Order_Code() As System.String 
    Get
        Return m_Ipd_Add_Order_Code
    End Get
    End Property

    Private m_Emg_Nursing_Add_Order_Code As String = "Emg_Nursing_Add_Order_Code"
    Public ReadOnly Property Emg_Nursing_Add_Order_Code() As System.String 
    Get
        Return m_Emg_Nursing_Add_Order_Code
    End Get
    End Property

    Private m_Ipd_Nursing_Add_Order_Code As String = "Ipd_Nursing_Add_Order_Code"
    Public ReadOnly Property Ipd_Nursing_Add_Order_Code() As System.String 
    Get
        Return m_Ipd_Nursing_Add_Order_Code
    End Get
    End Property

    Private m_Insu_Group_Code As String = "Insu_Group_Code"
    Public ReadOnly Property Insu_Group_Code() As System.String 
    Get
        Return m_Insu_Group_Code
    End Get
    End Property

    Private m_Insu_Apply_Price As String = "Insu_Apply_Price"
    Public ReadOnly Property Insu_Apply_Price() As System.String 
    Get
        Return m_Insu_Apply_Price
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

    Private m_Charge_Flag As String = "Charge_Flag"
    Public ReadOnly Property Charge_Flag() As System.String 
    Get
        Return m_Charge_Flag
    End Get
    End Property

  End Class

End Class
