Imports System.Data.SqlClient
Public Class IccMustFieldVerifyDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/10/26 下午 04:52:03
    Public Shared ReadOnly tableName as String="ICC_Must_Field_Verify"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Serial_Sn", "Treatment_Category_Id", "ID", "Is_Normal_Data", "Is_Abnormal_Data",   _
             "Field_Rule", "Create_User", "Create_Time", "Modified_User", "Modified_Time"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 2, 10, 1, 1,   _
             1, 10, -1, 10, -1  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccMustFieldVerifyDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Serial_Sn") = New Object
        dataRow("Treatment_Category_Id") = New Object
        dataRow("ID") = New Object
        dataRow("Is_Normal_Data") = New Object
        dataRow("Is_Abnormal_Data") = New Object
        dataRow("Field_Rule") = New Object
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
            dt.Columns.Add("Serial_Sn")
            dt.Columns.Add("Treatment_Category_Id")
            dt.Columns.Add("ID")
            dt.Columns.Add("Is_Normal_Data")
            dt.Columns.Add("Is_Abnormal_Data")
            dt.Columns.Add("Field_Rule")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Serial_Sn")
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
            dt.Columns.Add("Serial_Sn")
            dt.Columns("Serial_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Treatment_Category_Id")
            dt.Columns("Treatment_Category_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ID")
            dt.Columns("ID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Normal_Data")
            dt.Columns("Is_Normal_Data").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Abnormal_Data")
            dt.Columns("Is_Abnormal_Data").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Field_Rule")
            dt.Columns("Field_Rule").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Serial_Sn")
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
            dt.Columns.Add("Serial_Sn")
            dt.Columns.Add("Treatment_Category_Id")
            dt.Columns.Add("ID")
            dt.Columns.Add("Is_Normal_Data")
            dt.Columns.Add("Is_Abnormal_Data")
            dt.Columns.Add("Field_Rule")
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

  Class ICCMustFieldVerifyPt
    Private m_Serial_Sn As String = "Serial_Sn"
    Public ReadOnly Property Serial_Sn() As System.String 
    Get
        Return m_Serial_Sn
    End Get
    End Property

    Private m_Treatment_Category_Id As String = "Treatment_Category_Id"
    Public ReadOnly Property Treatment_Category_Id() As System.String 
    Get
        Return m_Treatment_Category_Id
    End Get
    End Property

    Private m_ID As String = "ID"
    Public ReadOnly Property ID() As System.String 
    Get
        Return m_ID
    End Get
    End Property

    Private m_Is_Normal_Data As String = "Is_Normal_Data"
    Public ReadOnly Property Is_Normal_Data() As System.String 
    Get
        Return m_Is_Normal_Data
    End Get
    End Property

    Private m_Is_Abnormal_Data As String = "Is_Abnormal_Data"
    Public ReadOnly Property Is_Abnormal_Data() As System.String 
    Get
        Return m_Is_Abnormal_Data
    End Get
    End Property

    Private m_Field_Rule As String = "Field_Rule"
    Public ReadOnly Property Field_Rule() As System.String 
    Get
        Return m_Field_Rule
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
