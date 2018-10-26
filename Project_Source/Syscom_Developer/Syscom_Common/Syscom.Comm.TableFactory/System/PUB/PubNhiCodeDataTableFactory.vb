Imports System.Data.SqlClient
Public Class PubNhiCodeDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:50
    Public Shared ReadOnly tableName as String="PUB_Nhi_Code"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Effect_Date", "Insu_Code", "Insu_En_Name", "Insu_Name", "Price",   _
             "Insu_Account_Id", "Is_Emg_Add", "Is_Kid_Add", "Is_Dental_Add", "Is_Holiday_Add",   _
             "Is_Dept_Add", "Insu_Order_Type_Id", "Majorcare_Code", "Dc", "End_Date",   _
             "Create_User", "Create_Time", "Modified_User", "Modified_Time", "Is_Labdiscount",   _
             "Emg_Add_Ratio", "Dental_Add_Ratio", "Dept_Add_Ratio", "Kid_Add_Ratio1", "Kid_Add_Ratio2",   _
             "Kid_Add_Ratio3", "Kid_Add_Ratio4", "Kid_Add_Ratio5", "Kid_Add_Ratio6", "Dept_Code_Set"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.DateTime", "System.String", "System.String", "System.String", "System.Decimal",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.DateTime", "System.String", "System.DateTime", "System.String",   _
             "System.Decimal", "System.Decimal", "System.Decimal", "System.Decimal", "System.Decimal",   _
             "System.Decimal", "System.Decimal", "System.Decimal", "System.Decimal", "System.String"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             -1, 20, 100, 100, -1,   _
             5, 1, 1, 1, 1,   _
             1, 5, 2, 1, -1,   _
             10, -1, 10, -1, 1,   _
             -1, -1, -1, -1, -1,   _
             -1, -1, -1, -1, 100  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubNhiCodeDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Effect_Date") = New Object
        dataRow("Insu_Code") = New Object
        dataRow("Insu_En_Name") = New Object
        dataRow("Insu_Name") = New Object
        dataRow("Price") = New Object
        dataRow("Insu_Account_Id") = New Object
        dataRow("Is_Emg_Add") = New Object
        dataRow("Is_Kid_Add") = New Object
        dataRow("Is_Dental_Add") = New Object
        dataRow("Is_Holiday_Add") = New Object
        dataRow("Is_Dept_Add") = New Object
        dataRow("Insu_Order_Type_Id") = New Object
        dataRow("Majorcare_Code") = New Object
        dataRow("Dc") = New Object
        dataRow("End_Date") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Is_Labdiscount") = New Object
        dataRow("Emg_Add_Ratio") = New Object
        dataRow("Dental_Add_Ratio") = New Object
        dataRow("Dept_Add_Ratio") = New Object
        dataRow("Kid_Add_Ratio1") = New Object
        dataRow("Kid_Add_Ratio2") = New Object
        dataRow("Kid_Add_Ratio3") = New Object
        dataRow("Kid_Add_Ratio4") = New Object
        dataRow("Kid_Add_Ratio5") = New Object
        dataRow("Kid_Add_Ratio6") = New Object
        dataRow("Dept_Code_Set") = New Object
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
            dt.Columns.Add("Insu_Code")
            dt.Columns.Add("Insu_En_Name")
            dt.Columns.Add("Insu_Name")
            dt.Columns.Add("Price")
            dt.Columns.Add("Insu_Account_Id")
            dt.Columns.Add("Is_Emg_Add")
            dt.Columns.Add("Is_Kid_Add")
            dt.Columns.Add("Is_Dental_Add")
            dt.Columns.Add("Is_Holiday_Add")
            dt.Columns.Add("Is_Dept_Add")
            dt.Columns.Add("Insu_Order_Type_Id")
            dt.Columns.Add("Majorcare_Code")
            dt.Columns.Add("Dc")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Is_Labdiscount")
            dt.Columns.Add("Emg_Add_Ratio")
            dt.Columns.Add("Dental_Add_Ratio")
            dt.Columns.Add("Dept_Add_Ratio")
            dt.Columns.Add("Kid_Add_Ratio1")
            dt.Columns.Add("Kid_Add_Ratio2")
            dt.Columns.Add("Kid_Add_Ratio3")
            dt.Columns.Add("Kid_Add_Ratio4")
            dt.Columns.Add("Kid_Add_Ratio5")
            dt.Columns.Add("Kid_Add_Ratio6")
            dt.Columns.Add("Dept_Code_Set")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Effect_Date")
            pkColArray(1) = dt.Columns("Insu_Code")
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
            dt.Columns.Add("Insu_Code")
            dt.Columns("Insu_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_En_Name")
            dt.Columns("Insu_En_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Name")
            dt.Columns("Insu_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Price")
            dt.Columns("Price").DataType = System.Type.GetType("System.Decimal")
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
            dt.Columns.Add("Insu_Order_Type_Id")
            dt.Columns("Insu_Order_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Majorcare_Code")
            dt.Columns("Majorcare_Code").DataType = System.Type.GetType("System.String")
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
            dt.Columns.Add("Is_Labdiscount")
            dt.Columns("Is_Labdiscount").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Emg_Add_Ratio")
            dt.Columns("Emg_Add_Ratio").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Dental_Add_Ratio")
            dt.Columns("Dental_Add_Ratio").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Dept_Add_Ratio")
            dt.Columns("Dept_Add_Ratio").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Kid_Add_Ratio1")
            dt.Columns("Kid_Add_Ratio1").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Kid_Add_Ratio2")
            dt.Columns("Kid_Add_Ratio2").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Kid_Add_Ratio3")
            dt.Columns("Kid_Add_Ratio3").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Kid_Add_Ratio4")
            dt.Columns("Kid_Add_Ratio4").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Kid_Add_Ratio5")
            dt.Columns("Kid_Add_Ratio5").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Kid_Add_Ratio6")
            dt.Columns("Kid_Add_Ratio6").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Dept_Code_Set")
            dt.Columns("Dept_Code_Set").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Effect_Date")
            pkColArray(1) = dt.Columns("Insu_Code")
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
            dt.Columns.Add("Insu_Code")
            dt.Columns.Add("Insu_En_Name")
            dt.Columns.Add("Insu_Name")
            dt.Columns.Add("Price")
            dt.Columns.Add("Insu_Account_Id")
            dt.Columns.Add("Is_Emg_Add")
            dt.Columns.Add("Is_Kid_Add")
            dt.Columns.Add("Is_Dental_Add")
            dt.Columns.Add("Is_Holiday_Add")
            dt.Columns.Add("Is_Dept_Add")
            dt.Columns.Add("Insu_Order_Type_Id")
            dt.Columns.Add("Majorcare_Code")
            dt.Columns.Add("Dc")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Is_Labdiscount")
            dt.Columns.Add("Emg_Add_Ratio")
            dt.Columns.Add("Dental_Add_Ratio")
            dt.Columns.Add("Dept_Add_Ratio")
            dt.Columns.Add("Kid_Add_Ratio1")
            dt.Columns.Add("Kid_Add_Ratio2")
            dt.Columns.Add("Kid_Add_Ratio3")
            dt.Columns.Add("Kid_Add_Ratio4")
            dt.Columns.Add("Kid_Add_Ratio5")
            dt.Columns.Add("Kid_Add_Ratio6")
            dt.Columns.Add("Dept_Code_Set")
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

  Class PUBNhiCodePt
    Private m_Effect_Date As String = "Effect_Date"
    Public ReadOnly Property Effect_Date() As System.String 
    Get
        Return m_Effect_Date
    End Get
    End Property

    Private m_Insu_Code As String = "Insu_Code"
    Public ReadOnly Property Insu_Code() As System.String 
    Get
        Return m_Insu_Code
    End Get
    End Property

    Private m_Insu_En_Name As String = "Insu_En_Name"
    Public ReadOnly Property Insu_En_Name() As System.String 
    Get
        Return m_Insu_En_Name
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

    Private m_Insu_Order_Type_Id As String = "Insu_Order_Type_Id"
    Public ReadOnly Property Insu_Order_Type_Id() As System.String 
    Get
        Return m_Insu_Order_Type_Id
    End Get
    End Property

    Private m_Majorcare_Code As String = "Majorcare_Code"
    Public ReadOnly Property Majorcare_Code() As System.String 
    Get
        Return m_Majorcare_Code
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

    Private m_Is_Labdiscount As String = "Is_Labdiscount"
    Public ReadOnly Property Is_Labdiscount() As System.String 
    Get
        Return m_Is_Labdiscount
    End Get
    End Property

    Private m_Emg_Add_Ratio As String = "Emg_Add_Ratio"
    Public ReadOnly Property Emg_Add_Ratio() As System.String 
    Get
        Return m_Emg_Add_Ratio
    End Get
    End Property

    Private m_Dental_Add_Ratio As String = "Dental_Add_Ratio"
    Public ReadOnly Property Dental_Add_Ratio() As System.String 
    Get
        Return m_Dental_Add_Ratio
    End Get
    End Property

    Private m_Dept_Add_Ratio As String = "Dept_Add_Ratio"
    Public ReadOnly Property Dept_Add_Ratio() As System.String 
    Get
        Return m_Dept_Add_Ratio
    End Get
    End Property

    Private m_Kid_Add_Ratio1 As String = "Kid_Add_Ratio1"
    Public ReadOnly Property Kid_Add_Ratio1() As System.String 
    Get
        Return m_Kid_Add_Ratio1
    End Get
    End Property

    Private m_Kid_Add_Ratio2 As String = "Kid_Add_Ratio2"
    Public ReadOnly Property Kid_Add_Ratio2() As System.String 
    Get
        Return m_Kid_Add_Ratio2
    End Get
    End Property

    Private m_Kid_Add_Ratio3 As String = "Kid_Add_Ratio3"
    Public ReadOnly Property Kid_Add_Ratio3() As System.String 
    Get
        Return m_Kid_Add_Ratio3
    End Get
    End Property

    Private m_Kid_Add_Ratio4 As String = "Kid_Add_Ratio4"
    Public ReadOnly Property Kid_Add_Ratio4() As System.String 
    Get
        Return m_Kid_Add_Ratio4
    End Get
    End Property

    Private m_Kid_Add_Ratio5 As String = "Kid_Add_Ratio5"
    Public ReadOnly Property Kid_Add_Ratio5() As System.String 
    Get
        Return m_Kid_Add_Ratio5
    End Get
    End Property

    Private m_Kid_Add_Ratio6 As String = "Kid_Add_Ratio6"
    Public ReadOnly Property Kid_Add_Ratio6() As System.String 
    Get
        Return m_Kid_Add_Ratio6
    End Get
    End Property

    Private m_Dept_Code_Set As String = "Dept_Code_Set"
    Public ReadOnly Property Dept_Code_Set() As System.String 
    Get
        Return m_Dept_Code_Set
    End Get
    End Property

  End Class

End Class
