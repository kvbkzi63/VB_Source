Imports System.Data.SqlClient
Public Class IccFeedbackMb1DataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/12/16 上午 10:59:44
    Public Shared ReadOnly tableName as String="ICC_Feedback_Mb1"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Import_Date", "Count", "Record_No", "A00", "A01",   _
             "A02", "A11", "A12", "A13", "A14",   _
             "A15", "A16", "A17", "A18", "A19",   _
             "A20", "A21", "A23", "A24", "A25",   _
             "A26", "A27", "A28", "A29", "A30",   _
             "A31", "A32", "A33", "A34", "A35",   _
             "A41", "A42", "A43", "A44", "A51",   _
             "A52", "A53", "Create_User", "Create_Time", "Modified_User",   _
             "Modified_Time", "A54", "Health_Sn", "Source_Sn"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.DateTime", "System.Int32", "System.Int32", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.DateTime", "System.String",   _
             "System.DateTime", "System.String", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             -1, -1, -1, 1, 1,   _
             5, 12, 10, 7, 10,   _
             10, 12, 13, 4, 1,   _
             7, 1, 2, 1, 9,   _
             9, 9, 9, 9, 9,   _
             8, 8, 8, 7, 7,   _
             2, 7, 10, 2, 7,   _
             10, 2, 10, -1, 10,   _
             -1, 7, 10, 15}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccFeedbackMb1DataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Import_Date") = New Object
        dataRow("Count") = New Object
        dataRow("Record_No") = New Object
        dataRow("A00") = New Object
        dataRow("A01") = New Object
        dataRow("A02") = New Object
        dataRow("A11") = New Object
        dataRow("A12") = New Object
        dataRow("A13") = New Object
        dataRow("A14") = New Object
        dataRow("A15") = New Object
        dataRow("A16") = New Object
        dataRow("A17") = New Object
        dataRow("A18") = New Object
        dataRow("A19") = New Object
        dataRow("A20") = New Object
        dataRow("A21") = New Object
        dataRow("A23") = New Object
        dataRow("A24") = New Object
        dataRow("A25") = New Object
        dataRow("A26") = New Object
        dataRow("A27") = New Object
        dataRow("A28") = New Object
        dataRow("A29") = New Object
        dataRow("A30") = New Object
        dataRow("A31") = New Object
        dataRow("A32") = New Object
        dataRow("A33") = New Object
        dataRow("A34") = New Object
        dataRow("A35") = New Object
        dataRow("A41") = New Object
        dataRow("A42") = New Object
        dataRow("A43") = New Object
        dataRow("A44") = New Object
        dataRow("A51") = New Object
        dataRow("A52") = New Object
        dataRow("A53") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("A54") = New Object
        dataRow("Health_Sn") = New Object
        dataRow("Source_Sn") = New Object
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
            dt.Columns.Add("A00")
            dt.Columns.Add("A01")
            dt.Columns.Add("A02")
            dt.Columns.Add("A11")
            dt.Columns.Add("A12")
            dt.Columns.Add("A13")
            dt.Columns.Add("A14")
            dt.Columns.Add("A15")
            dt.Columns.Add("A16")
            dt.Columns.Add("A17")
            dt.Columns.Add("A18")
            dt.Columns.Add("A19")
            dt.Columns.Add("A20")
            dt.Columns.Add("A21")
            dt.Columns.Add("A23")
            dt.Columns.Add("A24")
            dt.Columns.Add("A25")
            dt.Columns.Add("A26")
            dt.Columns.Add("A27")
            dt.Columns.Add("A28")
            dt.Columns.Add("A29")
            dt.Columns.Add("A30")
            dt.Columns.Add("A31")
            dt.Columns.Add("A32")
            dt.Columns.Add("A33")
            dt.Columns.Add("A34")
            dt.Columns.Add("A35")
            dt.Columns.Add("A41")
            dt.Columns.Add("A42")
            dt.Columns.Add("A43")
            dt.Columns.Add("A44")
            dt.Columns.Add("A51")
            dt.Columns.Add("A52")
            dt.Columns.Add("A53")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("A54")
            dt.Columns.Add("Health_Sn")
            dt.Columns.Add("Source_Sn")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Import_Date")
            pkColArray(1) = dt.Columns("Count")
            pkColArray(2) = dt.Columns("Record_No")
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
            dt.Columns.Add("A00")
            dt.Columns("A00").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A01")
            dt.Columns("A01").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A02")
            dt.Columns("A02").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A11")
            dt.Columns("A11").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A12")
            dt.Columns("A12").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A13")
            dt.Columns("A13").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A14")
            dt.Columns("A14").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A15")
            dt.Columns("A15").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A16")
            dt.Columns("A16").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A17")
            dt.Columns("A17").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A18")
            dt.Columns("A18").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A19")
            dt.Columns("A19").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A20")
            dt.Columns("A20").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A21")
            dt.Columns("A21").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A23")
            dt.Columns("A23").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A24")
            dt.Columns("A24").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A25")
            dt.Columns("A25").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A26")
            dt.Columns("A26").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A27")
            dt.Columns("A27").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A28")
            dt.Columns("A28").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A29")
            dt.Columns("A29").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A30")
            dt.Columns("A30").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A31")
            dt.Columns("A31").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A32")
            dt.Columns("A32").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A33")
            dt.Columns("A33").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A34")
            dt.Columns("A34").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A35")
            dt.Columns("A35").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A41")
            dt.Columns("A41").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A42")
            dt.Columns("A42").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A43")
            dt.Columns("A43").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A44")
            dt.Columns("A44").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A51")
            dt.Columns("A51").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A52")
            dt.Columns("A52").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A53")
            dt.Columns("A53").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("A54")
            dt.Columns("A54").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Health_Sn")
            dt.Columns("Health_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Source_Sn")
            dt.Columns("Source_Sn").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Import_Date")
            pkColArray(1) = dt.Columns("Count")
            pkColArray(2) = dt.Columns("Record_No")
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
            dt.Columns.Add("A00")
            dt.Columns.Add("A01")
            dt.Columns.Add("A02")
            dt.Columns.Add("A11")
            dt.Columns.Add("A12")
            dt.Columns.Add("A13")
            dt.Columns.Add("A14")
            dt.Columns.Add("A15")
            dt.Columns.Add("A16")
            dt.Columns.Add("A17")
            dt.Columns.Add("A18")
            dt.Columns.Add("A19")
            dt.Columns.Add("A20")
            dt.Columns.Add("A21")
            dt.Columns.Add("A23")
            dt.Columns.Add("A24")
            dt.Columns.Add("A25")
            dt.Columns.Add("A26")
            dt.Columns.Add("A27")
            dt.Columns.Add("A28")
            dt.Columns.Add("A29")
            dt.Columns.Add("A30")
            dt.Columns.Add("A31")
            dt.Columns.Add("A32")
            dt.Columns.Add("A33")
            dt.Columns.Add("A34")
            dt.Columns.Add("A35")
            dt.Columns.Add("A41")
            dt.Columns.Add("A42")
            dt.Columns.Add("A43")
            dt.Columns.Add("A44")
            dt.Columns.Add("A51")
            dt.Columns.Add("A52")
            dt.Columns.Add("A53")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("A54")
            dt.Columns.Add("Health_Sn")
            dt.Columns.Add("Source_Sn")
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

  Class ICCFeedbackMb1Pt
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

    Private m_A00 As String = "A00"
    Public ReadOnly Property A00() As System.String 
    Get
        Return m_A00
    End Get
    End Property

    Private m_A01 As String = "A01"
    Public ReadOnly Property A01() As System.String 
    Get
        Return m_A01
    End Get
    End Property

    Private m_A02 As String = "A02"
    Public ReadOnly Property A02() As System.String 
    Get
        Return m_A02
    End Get
    End Property

    Private m_A11 As String = "A11"
    Public ReadOnly Property A11() As System.String 
    Get
        Return m_A11
    End Get
    End Property

    Private m_A12 As String = "A12"
    Public ReadOnly Property A12() As System.String 
    Get
        Return m_A12
    End Get
    End Property

    Private m_A13 As String = "A13"
    Public ReadOnly Property A13() As System.String 
    Get
        Return m_A13
    End Get
    End Property

    Private m_A14 As String = "A14"
    Public ReadOnly Property A14() As System.String 
    Get
        Return m_A14
    End Get
    End Property

    Private m_A15 As String = "A15"
    Public ReadOnly Property A15() As System.String 
    Get
        Return m_A15
    End Get
    End Property

    Private m_A16 As String = "A16"
    Public ReadOnly Property A16() As System.String 
    Get
        Return m_A16
    End Get
    End Property

    Private m_A17 As String = "A17"
    Public ReadOnly Property A17() As System.String 
    Get
        Return m_A17
    End Get
    End Property

    Private m_A18 As String = "A18"
    Public ReadOnly Property A18() As System.String 
    Get
        Return m_A18
    End Get
    End Property

    Private m_A19 As String = "A19"
    Public ReadOnly Property A19() As System.String 
    Get
        Return m_A19
    End Get
    End Property

    Private m_A20 As String = "A20"
    Public ReadOnly Property A20() As System.String 
    Get
        Return m_A20
    End Get
    End Property

    Private m_A21 As String = "A21"
    Public ReadOnly Property A21() As System.String 
    Get
        Return m_A21
    End Get
    End Property

    Private m_A23 As String = "A23"
    Public ReadOnly Property A23() As System.String 
    Get
        Return m_A23
    End Get
    End Property

    Private m_A24 As String = "A24"
    Public ReadOnly Property A24() As System.String 
    Get
        Return m_A24
    End Get
    End Property

    Private m_A25 As String = "A25"
    Public ReadOnly Property A25() As System.String 
    Get
        Return m_A25
    End Get
    End Property

    Private m_A26 As String = "A26"
    Public ReadOnly Property A26() As System.String 
    Get
        Return m_A26
    End Get
    End Property

    Private m_A27 As String = "A27"
    Public ReadOnly Property A27() As System.String 
    Get
        Return m_A27
    End Get
    End Property

    Private m_A28 As String = "A28"
    Public ReadOnly Property A28() As System.String 
    Get
        Return m_A28
    End Get
    End Property

    Private m_A29 As String = "A29"
    Public ReadOnly Property A29() As System.String 
    Get
        Return m_A29
    End Get
    End Property

    Private m_A30 As String = "A30"
    Public ReadOnly Property A30() As System.String 
    Get
        Return m_A30
    End Get
    End Property

    Private m_A31 As String = "A31"
    Public ReadOnly Property A31() As System.String 
    Get
        Return m_A31
    End Get
    End Property

    Private m_A32 As String = "A32"
    Public ReadOnly Property A32() As System.String 
    Get
        Return m_A32
    End Get
    End Property

    Private m_A33 As String = "A33"
    Public ReadOnly Property A33() As System.String 
    Get
        Return m_A33
    End Get
    End Property

    Private m_A34 As String = "A34"
    Public ReadOnly Property A34() As System.String 
    Get
        Return m_A34
    End Get
    End Property

    Private m_A35 As String = "A35"
    Public ReadOnly Property A35() As System.String 
    Get
        Return m_A35
    End Get
    End Property

    Private m_A41 As String = "A41"
    Public ReadOnly Property A41() As System.String 
    Get
        Return m_A41
    End Get
    End Property

    Private m_A42 As String = "A42"
    Public ReadOnly Property A42() As System.String 
    Get
        Return m_A42
    End Get
    End Property

    Private m_A43 As String = "A43"
    Public ReadOnly Property A43() As System.String 
    Get
        Return m_A43
    End Get
    End Property

    Private m_A44 As String = "A44"
    Public ReadOnly Property A44() As System.String 
    Get
        Return m_A44
    End Get
    End Property

    Private m_A51 As String = "A51"
    Public ReadOnly Property A51() As System.String 
    Get
        Return m_A51
    End Get
    End Property

    Private m_A52 As String = "A52"
    Public ReadOnly Property A52() As System.String 
    Get
        Return m_A52
    End Get
    End Property

    Private m_A53 As String = "A53"
    Public ReadOnly Property A53() As System.String 
    Get
        Return m_A53
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

    Private m_A54 As String = "A54"
    Public ReadOnly Property A54() As System.String 
    Get
        Return m_A54
    End Get
    End Property

    Private m_Health_Sn As String = "Health_Sn"
    Public ReadOnly Property Health_Sn() As System.String 
    Get
        Return m_Health_Sn
    End Get
    End Property

    Private m_Source_Sn As String = "Source_Sn"
    Public ReadOnly Property Source_Sn() As System.String 
    Get
        Return m_Source_Sn
    End Get
    End Property

  End Class

End Class
