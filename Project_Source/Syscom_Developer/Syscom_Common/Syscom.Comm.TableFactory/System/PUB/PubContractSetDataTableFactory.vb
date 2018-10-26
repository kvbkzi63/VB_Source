Imports System.Data.SqlClient
Public Class PubContractSetDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:47
    Public Shared ReadOnly tableName as String="PUB_Contract_Set"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Effect_Date", "Contract_Code", "Sub_Identity_Code", "Order_Type_Id", "Account_Id",   _
             "Order_Code", "Discount_Ratio", "Payself_Amt", "Keep_Account_Ratio", "Keep_Account_Amt",   _
             "Dc", "End_Date", "Create_User", "Create_Time", "Modified_User",   _
             "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.DateTime", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.Decimal", "System.Decimal", "System.Decimal", "System.Decimal",   _
             "System.String", "System.DateTime", "System.String", "System.DateTime", "System.String",   _
             "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             -1, 6, 2, 5, 5,   _
             20, -1, -1, -1, -1,   _
             1, -1, 10, -1, 10,   _
             -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubContractSetDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Effect_Date") = New Object
        dataRow("Contract_Code") = New Object
        dataRow("Sub_Identity_Code") = New Object
        dataRow("Order_Type_Id") = New Object
        dataRow("Account_Id") = New Object
        dataRow("Order_Code") = New Object
        dataRow("Discount_Ratio") = New Object
        dataRow("Payself_Amt") = New Object
        dataRow("Keep_Account_Ratio") = New Object
        dataRow("Keep_Account_Amt") = New Object
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
            dt.Columns.Add("Contract_Code")
            dt.Columns.Add("Sub_Identity_Code")
            dt.Columns.Add("Order_Type_Id")
            dt.Columns.Add("Account_Id")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Discount_Ratio")
            dt.Columns.Add("Payself_Amt")
            dt.Columns.Add("Keep_Account_Ratio")
            dt.Columns.Add("Keep_Account_Amt")
            dt.Columns.Add("Dc")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(5) As DataColumn 
            pkColArray(0) = dt.Columns("Effect_Date")
            pkColArray(1) = dt.Columns("Contract_Code")
            pkColArray(2) = dt.Columns("Sub_Identity_Code")
            pkColArray(3) = dt.Columns("Order_Type_Id")
            pkColArray(4) = dt.Columns("Account_Id")
            pkColArray(5) = dt.Columns("Order_Code")
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
            dt.Columns.Add("Contract_Code")
            dt.Columns("Contract_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sub_Identity_Code")
            dt.Columns("Sub_Identity_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Type_Id")
            dt.Columns("Order_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Account_Id")
            dt.Columns("Account_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Discount_Ratio")
            dt.Columns("Discount_Ratio").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Payself_Amt")
            dt.Columns("Payself_Amt").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Keep_Account_Ratio")
            dt.Columns("Keep_Account_Ratio").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Keep_Account_Amt")
            dt.Columns("Keep_Account_Amt").DataType = System.Type.GetType("System.Decimal")
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
            pkColArray(1) = dt.Columns("Contract_Code")
            pkColArray(2) = dt.Columns("Sub_Identity_Code")
            pkColArray(3) = dt.Columns("Order_Type_Id")
            pkColArray(4) = dt.Columns("Account_Id")
            pkColArray(5) = dt.Columns("Order_Code")
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
            dt.Columns.Add("Contract_Code")
            dt.Columns.Add("Sub_Identity_Code")
            dt.Columns.Add("Order_Type_Id")
            dt.Columns.Add("Account_Id")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Discount_Ratio")
            dt.Columns.Add("Payself_Amt")
            dt.Columns.Add("Keep_Account_Ratio")
            dt.Columns.Add("Keep_Account_Amt")
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

  Class PUBContractSetPt
    Private m_Effect_Date As String = "Effect_Date"
    Public ReadOnly Property Effect_Date() As System.String 
    Get
        Return m_Effect_Date
    End Get
    End Property

    Private m_Contract_Code As String = "Contract_Code"
    Public ReadOnly Property Contract_Code() As System.String 
    Get
        Return m_Contract_Code
    End Get
    End Property

    Private m_Sub_Identity_Code As String = "Sub_Identity_Code"
    Public ReadOnly Property Sub_Identity_Code() As System.String 
    Get
        Return m_Sub_Identity_Code
    End Get
    End Property

    Private m_Order_Type_Id As String = "Order_Type_Id"
    Public ReadOnly Property Order_Type_Id() As System.String 
    Get
        Return m_Order_Type_Id
    End Get
    End Property

    Private m_Account_Id As String = "Account_Id"
    Public ReadOnly Property Account_Id() As System.String 
    Get
        Return m_Account_Id
    End Get
    End Property

    Private m_Order_Code As String = "Order_Code"
    Public ReadOnly Property Order_Code() As System.String 
    Get
        Return m_Order_Code
    End Get
    End Property

    Private m_Discount_Ratio As String = "Discount_Ratio"
    Public ReadOnly Property Discount_Ratio() As System.String 
    Get
        Return m_Discount_Ratio
    End Get
    End Property

    Private m_Payself_Amt As String = "Payself_Amt"
    Public ReadOnly Property Payself_Amt() As System.String 
    Get
        Return m_Payself_Amt
    End Get
    End Property

    Private m_Keep_Account_Ratio As String = "Keep_Account_Ratio"
    Public ReadOnly Property Keep_Account_Ratio() As System.String 
    Get
        Return m_Keep_Account_Ratio
    End Get
    End Property

    Private m_Keep_Account_Amt As String = "Keep_Account_Amt"
    Public ReadOnly Property Keep_Account_Amt() As System.String 
    Get
        Return m_Keep_Account_Amt
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
