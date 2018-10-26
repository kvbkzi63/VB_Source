Imports System.Data.SqlClient
Public Class PubSubIdentityDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:54
    Public Shared ReadOnly tableName as String="PUB_Sub_Identity"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Sub_Identity_Code", "Main_Identity_Id", "Sub_Identity_Name", "Dc", "Create_User", _
             "Create_Time", "Modified_User", "Modified_Time", "Is_Opd", "Is_Emg", _
             "Is_Ipd", "Is_Bill_Close", "Is_Ohm"}   'Elly Add Is_Ohm 2016/05/12
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.DateTime", "System.String", "System.DateTime", "System.String", "System.String", _
             "System.String", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             2, 5, 50, 1, 10, _
             -1, 10, -1, 1, 1, _
             1, 1, 1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubSubIdentityDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Sub_Identity_Code") = New Object
        dataRow("Main_Identity_Id") = New Object
        dataRow("Sub_Identity_Name") = New Object
        dataRow("Dc") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Is_Opd") = New Object
        dataRow("Is_Emg") = New Object
        dataRow("Is_Ipd") = New Object
        dataRow("Is_Bill_Close") = New Object
        dataRow("Is_Ohm") = New Object 'Elly Add Is_Ohm 2016/05/12
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
            dt.Columns.Add("Sub_Identity_Code")
            dt.Columns.Add("Main_Identity_Id")
            dt.Columns.Add("Sub_Identity_Name")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Is_Opd")
            dt.Columns.Add("Is_Emg")
            dt.Columns.Add("Is_Ipd")
            dt.Columns.Add("Is_Bill_Close")
            dt.Columns.Add("Is_Ohm") 'Elly Add Is_Ohm 2016/05/12
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Sub_Identity_Code")
            pkColArray(1) = dt.Columns("Main_Identity_Id")
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
            dt.Columns.Add("Sub_Identity_Code")
            dt.Columns("Sub_Identity_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Main_Identity_Id")
            dt.Columns("Main_Identity_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sub_Identity_Name")
            dt.Columns("Sub_Identity_Name").DataType = System.Type.GetType("System.String")
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
            dt.Columns.Add("Is_Opd")
            dt.Columns("Is_Opd").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Emg")
            dt.Columns("Is_Emg").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Ipd")
            dt.Columns("Is_Ipd").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Bill_Close")
            dt.Columns("Is_Bill_Close").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Ohm")
            dt.Columns("Is_Ohm").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Sub_Identity_Code")
            pkColArray(1) = dt.Columns("Main_Identity_Id")
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
            dt.Columns.Add("Sub_Identity_Code")
            dt.Columns.Add("Main_Identity_Id")
            dt.Columns.Add("Sub_Identity_Name")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Is_Opd")
            dt.Columns.Add("Is_Emg")
            dt.Columns.Add("Is_Ipd")
            dt.Columns.Add("Is_Bill_Close")
            dt.Columns.Add("Is_Ohm")
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

  Class PUBSubIdentityPt
    Private m_Sub_Identity_Code As String = "Sub_Identity_Code"
    Public ReadOnly Property Sub_Identity_Code() As System.String 
    Get
        Return m_Sub_Identity_Code
    End Get
    End Property

    Private m_Main_Identity_Id As String = "Main_Identity_Id"
    Public ReadOnly Property Main_Identity_Id() As System.String 
    Get
        Return m_Main_Identity_Id
    End Get
    End Property

    Private m_Sub_Identity_Name As String = "Sub_Identity_Name"
    Public ReadOnly Property Sub_Identity_Name() As System.String 
    Get
        Return m_Sub_Identity_Name
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

    Private m_Is_Bill_Close As String = "Is_Bill_Close"
    Public ReadOnly Property Is_Bill_Close() As System.String 
    Get
        Return m_Is_Bill_Close
    End Get
    End Property

        Private m_Is_Ohm As String = "Is_Ohm"
        Public ReadOnly Property Is_Ohm() As System.String
            Get
                Return m_Is_Ohm
            End Get
        End Property


  End Class

End Class
