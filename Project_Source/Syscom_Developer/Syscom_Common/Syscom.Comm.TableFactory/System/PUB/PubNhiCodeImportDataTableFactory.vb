Imports System.Data.SqlClient
Public Class PubNhiCodeImportDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/9/17 下午 03:45:19
    Public Shared ReadOnly tableName as String="PUB_Nhi_Code_Import"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Nhi_Import_Sn", "Item_No", "Insu_Code", "Insu_Name", "Brand",   _
             "Content_Desc", "Form_Desc", "Spec_Desc", "Orig_Price", "New_Price",   _
             "Effect_Date", "Trans_User", "Trans_Time", "Create_User", "Create_Time",   _
             "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Int32", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.Decimal", "System.Decimal",   _
             "System.DateTime", "System.String", "System.DateTime", "System.String", "System.DateTime",   _
             "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             20, -1, 20, 200, 200,   _
             200, 200, 200, -1, -1,   _
             -1, 10, -1, 10, -1,   _
             10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubNhiCodeImportDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Nhi_Import_Sn") = New Object
        dataRow("Item_No") = New Object
        dataRow("Insu_Code") = New Object
        dataRow("Insu_Name") = New Object
        dataRow("Brand") = New Object
        dataRow("Content_Desc") = New Object
        dataRow("Form_Desc") = New Object
        dataRow("Spec_Desc") = New Object
        dataRow("Orig_Price") = New Object
        dataRow("New_Price") = New Object
        dataRow("Effect_Date") = New Object
        dataRow("Trans_User") = New Object
        dataRow("Trans_Time") = New Object
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
            dt.Columns.Add("Nhi_Import_Sn")
            dt.Columns.Add("Item_No")
            dt.Columns.Add("Insu_Code")
            dt.Columns.Add("Insu_Name")
            dt.Columns.Add("Brand")
            dt.Columns.Add("Content_Desc")
            dt.Columns.Add("Form_Desc")
            dt.Columns.Add("Spec_Desc")
            dt.Columns.Add("Orig_Price")
            dt.Columns.Add("New_Price")
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("Trans_User")
            dt.Columns.Add("Trans_Time")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Nhi_Import_Sn")
            pkColArray(1) = dt.Columns("Item_No")
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
            dt.Columns.Add("Nhi_Import_Sn")
            dt.Columns("Nhi_Import_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Item_No")
            dt.Columns("Item_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Insu_Code")
            dt.Columns("Insu_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Name")
            dt.Columns("Insu_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Brand")
            dt.Columns("Brand").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Content_Desc")
            dt.Columns("Content_Desc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Form_Desc")
            dt.Columns("Form_Desc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Spec_Desc")
            dt.Columns("Spec_Desc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Orig_Price")
            dt.Columns("Orig_Price").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("New_Price")
            dt.Columns("New_Price").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Effect_Date")
            dt.Columns("Effect_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Trans_User")
            dt.Columns("Trans_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Trans_Time")
            dt.Columns("Trans_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Nhi_Import_Sn")
            pkColArray(1) = dt.Columns("Item_No")
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
            dt.Columns.Add("Nhi_Import_Sn")
            dt.Columns.Add("Item_No")
            dt.Columns.Add("Insu_Code")
            dt.Columns.Add("Insu_Name")
            dt.Columns.Add("Brand")
            dt.Columns.Add("Content_Desc")
            dt.Columns.Add("Form_Desc")
            dt.Columns.Add("Spec_Desc")
            dt.Columns.Add("Orig_Price")
            dt.Columns.Add("New_Price")
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("Trans_User")
            dt.Columns.Add("Trans_Time")
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

  Class PUBNhiCodeImportPt
    Private m_Nhi_Import_Sn As String = "Nhi_Import_Sn"
    Public ReadOnly Property Nhi_Import_Sn() As System.String 
    Get
        Return m_Nhi_Import_Sn
    End Get
    End Property

    Private m_Item_No As String = "Item_No"
    Public ReadOnly Property Item_No() As System.String 
    Get
        Return m_Item_No
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

    Private m_Brand As String = "Brand"
    Public ReadOnly Property Brand() As System.String 
    Get
        Return m_Brand
    End Get
    End Property

    Private m_Content_Desc As String = "Content_Desc"
    Public ReadOnly Property Content_Desc() As System.String 
    Get
        Return m_Content_Desc
    End Get
    End Property

    Private m_Form_Desc As String = "Form_Desc"
    Public ReadOnly Property Form_Desc() As System.String 
    Get
        Return m_Form_Desc
    End Get
    End Property

    Private m_Spec_Desc As String = "Spec_Desc"
    Public ReadOnly Property Spec_Desc() As System.String 
    Get
        Return m_Spec_Desc
    End Get
    End Property

    Private m_Orig_Price As String = "Orig_Price"
    Public ReadOnly Property Orig_Price() As System.String 
    Get
        Return m_Orig_Price
    End Get
    End Property

    Private m_New_Price As String = "New_Price"
    Public ReadOnly Property New_Price() As System.String 
    Get
        Return m_New_Price
    End Get
    End Property

    Private m_Effect_Date As String = "Effect_Date"
    Public ReadOnly Property Effect_Date() As System.String 
    Get
        Return m_Effect_Date
    End Get
    End Property

    Private m_Trans_User As String = "Trans_User"
    Public ReadOnly Property Trans_User() As System.String 
    Get
        Return m_Trans_User
    End Get
    End Property

    Private m_Trans_Time As String = "Trans_Time"
    Public ReadOnly Property Trans_Time() As System.String 
    Get
        Return m_Trans_Time
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
