Imports System.Data.SqlClient
Public Class PubPreventiveCareDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:53
    Public Shared ReadOnly tableName as String="PUB_Preventive_Care"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Care_Item_Code", "Care_Order_Code", "Care_Cardseq", "Care_Cardseq_Name", "Age_Control_Id",   _
             "Age_Start", "Age_End", "Preventive_Care_Memo", "Package_Code", "Limit_Sex_Id",   _
             "Filter_Desc", "Advisory_Unit", "Opd_Memo", "Preventive_Care_Note"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.Int32", "System.Int32", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             2, 2, 4, 100, 5,   _
             -1, -1, 1073741823, 10, 5,   _
             50, 50, 100, 1073741823}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubPreventiveCareDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Care_Item_Code") = New Object
        dataRow("Care_Order_Code") = New Object
        dataRow("Care_Cardseq") = New Object
        dataRow("Care_Cardseq_Name") = New Object
        dataRow("Age_Control_Id") = New Object
        dataRow("Age_Start") = New Object
        dataRow("Age_End") = New Object
        dataRow("Preventive_Care_Memo") = New Object
        dataRow("Package_Code") = New Object
        dataRow("Limit_Sex_Id") = New Object
        dataRow("Filter_Desc") = New Object
        dataRow("Advisory_Unit") = New Object
        dataRow("Opd_Memo") = New Object
        dataRow("Preventive_Care_Note") = New Object
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
            dt.Columns.Add("Care_Item_Code")
            dt.Columns.Add("Care_Order_Code")
            dt.Columns.Add("Care_Cardseq")
            dt.Columns.Add("Care_Cardseq_Name")
            dt.Columns.Add("Age_Control_Id")
            dt.Columns.Add("Age_Start")
            dt.Columns.Add("Age_End")
            dt.Columns.Add("Preventive_Care_Memo")
            dt.Columns.Add("Package_Code")
            dt.Columns.Add("Limit_Sex_Id")
            dt.Columns.Add("Filter_Desc")
            dt.Columns.Add("Advisory_Unit")
            dt.Columns.Add("Opd_Memo")
            dt.Columns.Add("Preventive_Care_Note")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Care_Item_Code")
            pkColArray(1) = dt.Columns("Care_Order_Code")
            pkColArray(2) = dt.Columns("Care_Cardseq")
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
            dt.Columns.Add("Care_Item_Code")
            dt.Columns("Care_Item_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Care_Order_Code")
            dt.Columns("Care_Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Care_Cardseq")
            dt.Columns("Care_Cardseq").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Care_Cardseq_Name")
            dt.Columns("Care_Cardseq_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Age_Control_Id")
            dt.Columns("Age_Control_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Age_Start")
            dt.Columns("Age_Start").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Age_End")
            dt.Columns("Age_End").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Preventive_Care_Memo")
            dt.Columns("Preventive_Care_Memo").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Package_Code")
            dt.Columns("Package_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Limit_Sex_Id")
            dt.Columns("Limit_Sex_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Filter_Desc")
            dt.Columns("Filter_Desc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Advisory_Unit")
            dt.Columns("Advisory_Unit").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Opd_Memo")
            dt.Columns("Opd_Memo").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Preventive_Care_Note")
            dt.Columns("Preventive_Care_Note").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Care_Item_Code")
            pkColArray(1) = dt.Columns("Care_Order_Code")
            pkColArray(2) = dt.Columns("Care_Cardseq")
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
            dt.Columns.Add("Care_Item_Code")
            dt.Columns.Add("Care_Order_Code")
            dt.Columns.Add("Care_Cardseq")
            dt.Columns.Add("Care_Cardseq_Name")
            dt.Columns.Add("Age_Control_Id")
            dt.Columns.Add("Age_Start")
            dt.Columns.Add("Age_End")
            dt.Columns.Add("Preventive_Care_Memo")
            dt.Columns.Add("Package_Code")
            dt.Columns.Add("Limit_Sex_Id")
            dt.Columns.Add("Filter_Desc")
            dt.Columns.Add("Advisory_Unit")
            dt.Columns.Add("Opd_Memo")
            dt.Columns.Add("Preventive_Care_Note")
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

  Class PUBPreventiveCarePt
    Private m_Care_Item_Code As String = "Care_Item_Code"
    Public ReadOnly Property Care_Item_Code() As System.String 
    Get
        Return m_Care_Item_Code
    End Get
    End Property

    Private m_Care_Order_Code As String = "Care_Order_Code"
    Public ReadOnly Property Care_Order_Code() As System.String 
    Get
        Return m_Care_Order_Code
    End Get
    End Property

    Private m_Care_Cardseq As String = "Care_Cardseq"
    Public ReadOnly Property Care_Cardseq() As System.String 
    Get
        Return m_Care_Cardseq
    End Get
    End Property

    Private m_Care_Cardseq_Name As String = "Care_Cardseq_Name"
    Public ReadOnly Property Care_Cardseq_Name() As System.String 
    Get
        Return m_Care_Cardseq_Name
    End Get
    End Property

    Private m_Age_Control_Id As String = "Age_Control_Id"
    Public ReadOnly Property Age_Control_Id() As System.String 
    Get
        Return m_Age_Control_Id
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

    Private m_Preventive_Care_Memo As String = "Preventive_Care_Memo"
    Public ReadOnly Property Preventive_Care_Memo() As System.String 
    Get
        Return m_Preventive_Care_Memo
    End Get
    End Property

    Private m_Package_Code As String = "Package_Code"
    Public ReadOnly Property Package_Code() As System.String 
    Get
        Return m_Package_Code
    End Get
    End Property

    Private m_Limit_Sex_Id As String = "Limit_Sex_Id"
    Public ReadOnly Property Limit_Sex_Id() As System.String 
    Get
        Return m_Limit_Sex_Id
    End Get
    End Property

    Private m_Filter_Desc As String = "Filter_Desc"
    Public ReadOnly Property Filter_Desc() As System.String 
    Get
        Return m_Filter_Desc
    End Get
    End Property

    Private m_Advisory_Unit As String = "Advisory_Unit"
    Public ReadOnly Property Advisory_Unit() As System.String 
    Get
        Return m_Advisory_Unit
    End Get
    End Property

    Private m_Opd_Memo As String = "Opd_Memo"
    Public ReadOnly Property Opd_Memo() As System.String 
    Get
        Return m_Opd_Memo
    End Get
    End Property

    Private m_Preventive_Care_Note As String = "Preventive_Care_Note"
    Public ReadOnly Property Preventive_Care_Note() As System.String 
    Get
        Return m_Preventive_Care_Note
    End Get
    End Property

  End Class

End Class
