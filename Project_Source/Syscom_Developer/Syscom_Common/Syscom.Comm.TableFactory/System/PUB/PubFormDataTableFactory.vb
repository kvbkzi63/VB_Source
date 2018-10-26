Imports System.Data.SqlClient
Public Class PubFormDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:49
    Public Shared ReadOnly tableName as String="PUB_Form"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Form_Type_Id", "Form_Code", "Form_Name", "FID", "File_Name",   _
             "Form_Sort_Value", "Dc", "Is_Opd", "Is_Emg", "Is_Ipd",   _
             "Create_User", "Create_Time", "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.Int32", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.DateTime", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             5, 10, 100, 50, 100,   _
             -1, 1, 1, 1, 1,   _
             10, -1, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubFormDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Form_Type_Id") = New Object
        dataRow("Form_Code") = New Object
        dataRow("Form_Name") = New Object
        dataRow("FID") = New Object
        dataRow("File_Name") = New Object
        dataRow("Form_Sort_Value") = New Object
        dataRow("Dc") = New Object
        dataRow("Is_Opd") = New Object
        dataRow("Is_Emg") = New Object
        dataRow("Is_Ipd") = New Object
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
            dt.Columns.Add("Form_Type_Id")
            dt.Columns.Add("Form_Code")
            dt.Columns.Add("Form_Name")
            dt.Columns.Add("FID")
            dt.Columns.Add("File_Name")
            dt.Columns.Add("Form_Sort_Value")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Is_Opd")
            dt.Columns.Add("Is_Emg")
            dt.Columns.Add("Is_Ipd")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Form_Type_Id")
            pkColArray(1) = dt.Columns("Form_Code")
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
            dt.Columns.Add("Form_Type_Id")
            dt.Columns("Form_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Form_Code")
            dt.Columns("Form_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Form_Name")
            dt.Columns("Form_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("FID")
            dt.Columns("FID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("File_Name")
            dt.Columns("File_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Form_Sort_Value")
            dt.Columns("Form_Sort_Value").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Dc")
            dt.Columns("Dc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Opd")
            dt.Columns("Is_Opd").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Emg")
            dt.Columns("Is_Emg").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Ipd")
            dt.Columns("Is_Ipd").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Form_Type_Id")
            pkColArray(1) = dt.Columns("Form_Code")
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
            dt.Columns.Add("Form_Type_Id")
            dt.Columns.Add("Form_Code")
            dt.Columns.Add("Form_Name")
            dt.Columns.Add("FID")
            dt.Columns.Add("File_Name")
            dt.Columns.Add("Form_Sort_Value")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Is_Opd")
            dt.Columns.Add("Is_Emg")
            dt.Columns.Add("Is_Ipd")
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

  Class PUBFormPt
    Private m_Form_Type_Id As String = "Form_Type_Id"
    Public ReadOnly Property Form_Type_Id() As System.String 
    Get
        Return m_Form_Type_Id
    End Get
    End Property

    Private m_Form_Code As String = "Form_Code"
    Public ReadOnly Property Form_Code() As System.String 
    Get
        Return m_Form_Code
    End Get
    End Property

    Private m_Form_Name As String = "Form_Name"
    Public ReadOnly Property Form_Name() As System.String 
    Get
        Return m_Form_Name
    End Get
    End Property

    Private m_FID As String = "FID"
    Public ReadOnly Property FID() As System.String 
    Get
        Return m_FID
    End Get
    End Property

    Private m_File_Name As String = "File_Name"
    Public ReadOnly Property File_Name() As System.String 
    Get
        Return m_File_Name
    End Get
    End Property

    Private m_Form_Sort_Value As String = "Form_Sort_Value"
    Public ReadOnly Property Form_Sort_Value() As System.String 
    Get
        Return m_Form_Sort_Value
    End Get
    End Property

    Private m_Dc As String = "Dc"
    Public ReadOnly Property Dc() As System.String 
    Get
        Return m_Dc
    End Get
    End Property

    Private m_Is_Opd As String = "Is_Opd"
    Public ReadOnly Property Is_Opd() As System.String 
    Get
        Return m_Is_Opd
    End Get
    End Property

    Private m_Is_Emg As String = "Is_Emg"
    Public ReadOnly Property Is_Emg() As System.String 
    Get
        Return m_Is_Emg
    End Get
    End Property

    Private m_Is_Ipd As String = "Is_Ipd"
    Public ReadOnly Property Is_Ipd() As System.String 
    Get
        Return m_Is_Ipd
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
