Imports System.Data.SqlClient
Public Class PubIndicationDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:49
    Public Shared ReadOnly tableName as String="PUB_Indication"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Indication_No", "Indication_Name", "Sheet_Code", "Order_Code", "Indication_Item_Code",   _
             "Indication_Item_Detail_Code", "Is_Required", "Indication_Order_Value", "Is_Fold", "Edit_Type_Id",   _
             "Text_Length", "Is_Work", "Dc", "Create_User", "Create_Time",   _
             "Modified_User", "Modified_Time", "Group_Indication", "Is_Specimen_Desc", "Is_Default_Detail_Code",   _
             "Attach_Indication_No"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.Int32", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.Int32", "System.String", "System.String",   _
             "System.Int32", "System.String", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.DateTime", "System.Int32", "System.String", "System.String",   _
             "System.Int32"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             -1, 50, 10, 20, 5,   _
             2, 1, -1, 1, 5,   _
             -1, 1, 1, 10, -1,   _
             10, -1, -1, 1, 1,   _
             -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubIndicationDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Indication_No") = New Object
        dataRow("Indication_Name") = New Object
        dataRow("Sheet_Code") = New Object
        dataRow("Order_Code") = New Object
        dataRow("Indication_Item_Code") = New Object
        dataRow("Indication_Item_Detail_Code") = New Object
        dataRow("Is_Required") = New Object
        dataRow("Indication_Order_Value") = New Object
        dataRow("Is_Fold") = New Object
        dataRow("Edit_Type_Id") = New Object
        dataRow("Text_Length") = New Object
        dataRow("Is_Work") = New Object
        dataRow("Dc") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Group_Indication") = New Object
        dataRow("Is_Specimen_Desc") = New Object
        dataRow("Is_Default_Detail_Code") = New Object
        dataRow("Attach_Indication_No") = New Object
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
            dt.Columns.Add("Indication_No")
            dt.Columns.Add("Indication_Name")
            dt.Columns.Add("Sheet_Code")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Indication_Item_Code")
            dt.Columns.Add("Indication_Item_Detail_Code")
            dt.Columns.Add("Is_Required")
            dt.Columns.Add("Indication_Order_Value")
            dt.Columns.Add("Is_Fold")
            dt.Columns.Add("Edit_Type_Id")
            dt.Columns.Add("Text_Length")
            dt.Columns.Add("Is_Work")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Group_Indication")
            dt.Columns.Add("Is_Specimen_Desc")
            dt.Columns.Add("Is_Default_Detail_Code")
            dt.Columns.Add("Attach_Indication_No")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Indication_No")
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
            dt.Columns.Add("Indication_No")
            dt.Columns("Indication_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Indication_Name")
            dt.Columns("Indication_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sheet_Code")
            dt.Columns("Sheet_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Indication_Item_Code")
            dt.Columns("Indication_Item_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Indication_Item_Detail_Code")
            dt.Columns("Indication_Item_Detail_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Required")
            dt.Columns("Is_Required").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Indication_Order_Value")
            dt.Columns("Indication_Order_Value").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Is_Fold")
            dt.Columns("Is_Fold").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Edit_Type_Id")
            dt.Columns("Edit_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Text_Length")
            dt.Columns("Text_Length").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Is_Work")
            dt.Columns("Is_Work").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dc")
            dt.Columns("Dc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Group_Indication")
            dt.Columns("Group_Indication").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Is_Specimen_Desc")
            dt.Columns("Is_Specimen_Desc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Default_Detail_Code")
            dt.Columns("Is_Default_Detail_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Attach_Indication_No")
            dt.Columns("Attach_Indication_No").DataType = System.Type.GetType("System.Int32")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Indication_No")
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
            dt.Columns.Add("Indication_No")
            dt.Columns.Add("Indication_Name")
            dt.Columns.Add("Sheet_Code")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Indication_Item_Code")
            dt.Columns.Add("Indication_Item_Detail_Code")
            dt.Columns.Add("Is_Required")
            dt.Columns.Add("Indication_Order_Value")
            dt.Columns.Add("Is_Fold")
            dt.Columns.Add("Edit_Type_Id")
            dt.Columns.Add("Text_Length")
            dt.Columns.Add("Is_Work")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Group_Indication")
            dt.Columns.Add("Is_Specimen_Desc")
            dt.Columns.Add("Is_Default_Detail_Code")
            dt.Columns.Add("Attach_Indication_No")
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

  Class PUBIndicationPt
    Private m_Indication_No As String = "Indication_No"
    Public ReadOnly Property Indication_No() As System.String 
    Get
        Return m_Indication_No
    End Get
    End Property

    Private m_Indication_Name As String = "Indication_Name"
    Public ReadOnly Property Indication_Name() As System.String 
    Get
        Return m_Indication_Name
    End Get
    End Property

    Private m_Sheet_Code As String = "Sheet_Code"
    Public ReadOnly Property Sheet_Code() As System.String 
    Get
        Return m_Sheet_Code
    End Get
    End Property

    Private m_Order_Code As String = "Order_Code"
    Public ReadOnly Property Order_Code() As System.String 
    Get
        Return m_Order_Code
    End Get
    End Property

    Private m_Indication_Item_Code As String = "Indication_Item_Code"
    Public ReadOnly Property Indication_Item_Code() As System.String 
    Get
        Return m_Indication_Item_Code
    End Get
    End Property

    Private m_Indication_Item_Detail_Code As String = "Indication_Item_Detail_Code"
    Public ReadOnly Property Indication_Item_Detail_Code() As System.String 
    Get
        Return m_Indication_Item_Detail_Code
    End Get
    End Property

    Private m_Is_Required As String = "Is_Required"
    Public ReadOnly Property Is_Required() As System.String 
    Get
        Return m_Is_Required
    End Get
    End Property

    Private m_Indication_Order_Value As String = "Indication_Order_Value"
    Public ReadOnly Property Indication_Order_Value() As System.String 
    Get
        Return m_Indication_Order_Value
    End Get
    End Property

    Private m_Is_Fold As String = "Is_Fold"
    Public ReadOnly Property Is_Fold() As System.String 
    Get
        Return m_Is_Fold
    End Get
    End Property

    Private m_Edit_Type_Id As String = "Edit_Type_Id"
    Public ReadOnly Property Edit_Type_Id() As System.String 
    Get
        Return m_Edit_Type_Id
    End Get
    End Property

    Private m_Text_Length As String = "Text_Length"
    Public ReadOnly Property Text_Length() As System.String 
    Get
        Return m_Text_Length
    End Get
    End Property

    Private m_Is_Work As String = "Is_Work"
    Public ReadOnly Property Is_Work() As System.String 
    Get
        Return m_Is_Work
    End Get
    End Property

    Private m_Dc As String = "Dc"
    Public ReadOnly Property Dc() As System.String 
    Get
        Return m_Dc
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

    Private m_Group_Indication As String = "Group_Indication"
    Public ReadOnly Property Group_Indication() As System.String 
    Get
        Return m_Group_Indication
    End Get
    End Property

    Private m_Is_Specimen_Desc As String = "Is_Specimen_Desc"
    Public ReadOnly Property Is_Specimen_Desc() As System.String 
    Get
        Return m_Is_Specimen_Desc
    End Get
    End Property

    Private m_Is_Default_Detail_Code As String = "Is_Default_Detail_Code"
    Public ReadOnly Property Is_Default_Detail_Code() As System.String 
    Get
        Return m_Is_Default_Detail_Code
    End Get
    End Property

    Private m_Attach_Indication_No As String = "Attach_Indication_No"
    Public ReadOnly Property Attach_Indication_No() As System.String 
    Get
        Return m_Attach_Indication_No
    End Get
    End Property

  End Class

End Class
