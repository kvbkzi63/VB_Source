Imports System.Data.SqlClient
Public Class IccFeedbackCauseDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/11/13 下午 04:15:04
    Public Shared ReadOnly tableName as String="ICC_Feedback_Cause"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Import_Date", "Count", "Record_No", "Cause_No", "Item_Code",   _
             "Item_Code_Idx", "Cause_Id", "Create_User", "Create_Time", "Modified_User",   _
             "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.DateTime", "System.Int32", "System.Int32", "System.Int32", "System.String",   _
             "System.Int32", "System.String", "System.String", "System.DateTime", "System.String",   _
             "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             -1, -1, -1, -1, 10,   _
             -1, 10, 10, -1, 10,   _
             -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccFeedbackCauseDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Import_Date") = New Object
        dataRow("Count") = New Object
        dataRow("Record_No") = New Object
        dataRow("Cause_No") = New Object
        dataRow("Item_Code") = New Object
        dataRow("Item_Code_Idx") = New Object
        dataRow("Cause_Id") = New Object
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
            dt.Columns.Add("Import_Date")
            dt.Columns.Add("Count")
            dt.Columns.Add("Record_No")
            dt.Columns.Add("Cause_No")
            dt.Columns.Add("Item_Code")
            dt.Columns.Add("Item_Code_Idx")
            dt.Columns.Add("Cause_Id")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(3) As DataColumn 
            pkColArray(0) = dt.Columns("Import_Date")
            pkColArray(1) = dt.Columns("Count")
            pkColArray(2) = dt.Columns("Record_No")
            pkColArray(3) = dt.Columns("Cause_No")
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
            dt.Columns.Add("Import_Date")
            dt.Columns("Import_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Count")
            dt.Columns("Count").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Record_No")
            dt.Columns("Record_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Cause_No")
            dt.Columns("Cause_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Item_Code")
            dt.Columns("Item_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Item_Code_Idx")
            dt.Columns("Item_Code_Idx").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Cause_Id")
            dt.Columns("Cause_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(3) As DataColumn 
            pkColArray(0) = dt.Columns("Import_Date")
            pkColArray(1) = dt.Columns("Count")
            pkColArray(2) = dt.Columns("Record_No")
            pkColArray(3) = dt.Columns("Cause_No")
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
            dt.Columns.Add("Import_Date")
            dt.Columns.Add("Count")
            dt.Columns.Add("Record_No")
            dt.Columns.Add("Cause_No")
            dt.Columns.Add("Item_Code")
            dt.Columns.Add("Item_Code_Idx")
            dt.Columns.Add("Cause_Id")
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

  Class ICCFeedbackCausePt
    Private m_Import_Date As String = "Import_Date"
    Public ReadOnly Property Import_Date() As System.String 
    Get
        Return m_Import_Date
    End Get
    End Property

    Private m_Count As String = "Count"
    Public ReadOnly Property Count() As System.String 
    Get
        Return m_Count
    End Get
    End Property

    Private m_Record_No As String = "Record_No"
    Public ReadOnly Property Record_No() As System.String 
    Get
        Return m_Record_No
    End Get
    End Property

    Private m_Cause_No As String = "Cause_No"
    Public ReadOnly Property Cause_No() As System.String 
    Get
        Return m_Cause_No
    End Get
    End Property

    Private m_Item_Code As String = "Item_Code"
    Public ReadOnly Property Item_Code() As System.String 
    Get
        Return m_Item_Code
    End Get
    End Property

    Private m_Item_Code_Idx As String = "Item_Code_Idx"
    Public ReadOnly Property Item_Code_Idx() As System.String 
    Get
        Return m_Item_Code_Idx
    End Get
    End Property

    Private m_Cause_Id As String = "Cause_Id"
    Public ReadOnly Property Cause_Id() As System.String 
    Get
        Return m_Cause_Id
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
