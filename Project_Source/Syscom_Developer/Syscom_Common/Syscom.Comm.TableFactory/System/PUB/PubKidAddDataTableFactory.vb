Imports System.Data.SqlClient
Public Class PubKidAddDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:50
    Public Shared ReadOnly tableName as String="PUB_Kid_Add"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Effect_Date", "Main_Identity_Id", "Pt_From_Id", "Order_Code", "Age_Type_Id",   _
             "Age_Start", "Age_End", "Kid_Add_Ratio", "Dc", "End_Date",   _
             "Create_User", "Create_Time", "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.DateTime", "System.String", "System.String", "System.String", "System.String",   _
             "System.Int32", "System.Int32", "System.Decimal", "System.String", "System.DateTime",   _
             "System.String", "System.DateTime", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             -1, 5, 5, 20, 5,   _
             -1, -1, -1, 1, -1,   _
             10, -1, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubKidAddDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Effect_Date") = New Object
        dataRow("Main_Identity_Id") = New Object
        dataRow("Pt_From_Id") = New Object
        dataRow("Order_Code") = New Object
        dataRow("Age_Type_Id") = New Object
        dataRow("Age_Start") = New Object
        dataRow("Age_End") = New Object
        dataRow("Kid_Add_Ratio") = New Object
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
            dt.Columns.Add("Main_Identity_Id")
            dt.Columns.Add("Pt_From_Id")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Age_Type_Id")
            dt.Columns.Add("Age_Start")
            dt.Columns.Add("Age_End")
            dt.Columns.Add("Kid_Add_Ratio")
            dt.Columns.Add("Dc")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(5) As DataColumn 
            pkColArray(0) = dt.Columns("Effect_Date")
            pkColArray(1) = dt.Columns("Main_Identity_Id")
            pkColArray(2) = dt.Columns("Pt_From_Id")
            pkColArray(3) = dt.Columns("Order_Code")
            pkColArray(4) = dt.Columns("Age_Type_Id")
            pkColArray(5) = dt.Columns("Age_Start")
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
            dt.Columns.Add("Main_Identity_Id")
            dt.Columns("Main_Identity_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Pt_From_Id")
            dt.Columns("Pt_From_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Age_Type_Id")
            dt.Columns("Age_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Age_Start")
            dt.Columns("Age_Start").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Age_End")
            dt.Columns("Age_End").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Kid_Add_Ratio")
            dt.Columns("Kid_Add_Ratio").DataType = System.Type.GetType("System.Decimal")
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
            Dim pkColArray(5) As DataColumn 
            pkColArray(0) = dt.Columns("Effect_Date")
            pkColArray(1) = dt.Columns("Main_Identity_Id")
            pkColArray(2) = dt.Columns("Pt_From_Id")
            pkColArray(3) = dt.Columns("Order_Code")
            pkColArray(4) = dt.Columns("Age_Type_Id")
            pkColArray(5) = dt.Columns("Age_Start")
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
            dt.Columns.Add("Main_Identity_Id")
            dt.Columns.Add("Pt_From_Id")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Age_Type_Id")
            dt.Columns.Add("Age_Start")
            dt.Columns.Add("Age_End")
            dt.Columns.Add("Kid_Add_Ratio")
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

  Class PUBKidAddPt
    Private m_Effect_Date As String = "Effect_Date"
    Public ReadOnly Property Effect_Date() As System.String 
    Get
        Return m_Effect_Date
    End Get
    End Property

    Private m_Main_Identity_Id As String = "Main_Identity_Id"
    Public ReadOnly Property Main_Identity_Id() As System.String 
    Get
        Return m_Main_Identity_Id
    End Get
    End Property

    Private m_Pt_From_Id As String = "Pt_From_Id"
    Public ReadOnly Property Pt_From_Id() As System.String 
    Get
        Return m_Pt_From_Id
    End Get
    End Property

    Private m_Order_Code As String = "Order_Code"
    Public ReadOnly Property Order_Code() As System.String 
    Get
        Return m_Order_Code
    End Get
    End Property

    Private m_Age_Type_Id As String = "Age_Type_Id"
    Public ReadOnly Property Age_Type_Id() As System.String 
    Get
        Return m_Age_Type_Id
    End Get
    End Property

    Private m_Age_Start As String = "Age_Start"
    Public ReadOnly Property Age_Start() As System.String 
    Get
        Return m_Age_Start
    End Get
    End Property

    Private m_Age_End As String = "Age_End"
    Public ReadOnly Property Age_End() As System.String 
    Get
        Return m_Age_End
    End Get
    End Property

    Private m_Kid_Add_Ratio As String = "Kid_Add_Ratio"
    Public ReadOnly Property Kid_Add_Ratio() As System.String 
    Get
        Return m_Kid_Add_Ratio
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
