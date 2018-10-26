Imports System.Data.SqlClient
Public Class PubPatientSevereDiseaseDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:53
    Public Shared ReadOnly tableName as String="PUB_Patient_Severe_Disease"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Chart_No", "Icd_Code", "Effect_Date", "Certificate_Sn", "End_Date",   _
             "Is_From_Iccard", "Create_User", "Create_Time", "Modified_User", "Modified_Time"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime",   _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 10, -1, 50, -1,   _
             1, 10, -1, 10, -1  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubPatientSevereDiseaseDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Chart_No") = New Object
        dataRow("Icd_Code") = New Object
        dataRow("Effect_Date") = New Object
        dataRow("Certificate_Sn") = New Object
        dataRow("End_Date") = New Object
        dataRow("Is_From_Iccard") = New Object
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
            dt.Columns.Add("Chart_No")
            dt.Columns.Add("Icd_Code")
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("Certificate_Sn")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Is_From_Iccard")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Icd_Code")
            pkColArray(2) = dt.Columns("Effect_Date")
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
            dt.Columns.Add("Chart_No")
            dt.Columns("Chart_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Icd_Code")
            dt.Columns("Icd_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Effect_Date")
            dt.Columns("Effect_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Certificate_Sn")
            dt.Columns("Certificate_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("End_Date")
            dt.Columns("End_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Is_From_Iccard")
            dt.Columns("Is_From_Iccard").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Icd_Code")
            pkColArray(2) = dt.Columns("Effect_Date")
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
            dt.Columns.Add("Chart_No")
            dt.Columns.Add("Icd_Code")
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("Certificate_Sn")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Is_From_Iccard")
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

  Class PUBPatientSevereDiseasePt
    Private m_Chart_No As String = "Chart_No"
    Public ReadOnly Property Chart_No() As System.String 
    Get
        Return m_Chart_No
    End Get
    End Property

    Private m_Icd_Code As String = "Icd_Code"
    Public ReadOnly Property Icd_Code() As System.String 
    Get
        Return m_Icd_Code
    End Get
    End Property

    Private m_Effect_Date As String = "Effect_Date"
    Public ReadOnly Property Effect_Date() As System.String 
    Get
        Return m_Effect_Date
    End Get
    End Property

    Private m_Certificate_Sn As String = "Certificate_Sn"
    Public ReadOnly Property Certificate_Sn() As System.String 
    Get
        Return m_Certificate_Sn
    End Get
    End Property

    Private m_End_Date As String = "End_Date"
    Public ReadOnly Property End_Date() As System.String 
    Get
        Return m_End_Date
    End Get
    End Property

    Private m_Is_From_Iccard As String = "Is_From_Iccard"
    Public ReadOnly Property Is_From_Iccard() As System.String 
    Get
        Return m_Is_From_Iccard
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
