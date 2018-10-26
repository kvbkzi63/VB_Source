Imports System.Data.SqlClient
Public Class PubFirstVisitRecordDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:49
    Public Shared ReadOnly tableName as String="PUB_First_Visit_Record"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Chart_No", "Dept_Code", "Outpatient_Sn", "Doctor_Code", "Opd_Visit_Date",   _
             "Is_First_Chart", "Fid", "Belong_Dept_Code"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 6, 15, 10, -1,   _
             1, 30, 6}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubFirstVisitRecordDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Chart_No") = New Object
        dataRow("Dept_Code") = New Object
        dataRow("Outpatient_Sn") = New Object
        dataRow("Doctor_Code") = New Object
        dataRow("Opd_Visit_Date") = New Object
        dataRow("Is_First_Chart") = New Object
        dataRow("Fid") = New Object
        dataRow("Belong_Dept_Code") = New Object
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
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Outpatient_Sn")
            dt.Columns.Add("Doctor_Code")
            dt.Columns.Add("Opd_Visit_Date")
            dt.Columns.Add("Is_First_Chart")
            dt.Columns.Add("Fid")
            dt.Columns.Add("Belong_Dept_Code")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Dept_Code")
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
            dt.Columns.Add("Dept_Code")
            dt.Columns("Dept_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Outpatient_Sn")
            dt.Columns("Outpatient_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Doctor_Code")
            dt.Columns("Doctor_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Opd_Visit_Date")
            dt.Columns("Opd_Visit_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Is_First_Chart")
            dt.Columns("Is_First_Chart").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Fid")
            dt.Columns("Fid").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Belong_Dept_Code")
            dt.Columns("Belong_Dept_Code").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Dept_Code")
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
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Outpatient_Sn")
            dt.Columns.Add("Doctor_Code")
            dt.Columns.Add("Opd_Visit_Date")
            dt.Columns.Add("Is_First_Chart")
            dt.Columns.Add("Fid")
            dt.Columns.Add("Belong_Dept_Code")
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

  Class PUBFirstVisitRecordPt
    Private m_Chart_No As String = "Chart_No"
    Public ReadOnly Property Chart_No() As System.String 
    Get
        Return m_Chart_No
    End Get
    End Property

    Private m_Dept_Code As String = "Dept_Code"
    Public ReadOnly Property Dept_Code() As System.String 
    Get
        Return m_Dept_Code
    End Get
    End Property

    Private m_Outpatient_Sn As String = "Outpatient_Sn"
    Public ReadOnly Property Outpatient_Sn() As System.String 
    Get
        Return m_Outpatient_Sn
    End Get
    End Property

    Private m_Doctor_Code As String = "Doctor_Code"
    Public ReadOnly Property Doctor_Code() As System.String 
    Get
        Return m_Doctor_Code
    End Get
    End Property

    Private m_Opd_Visit_Date As String = "Opd_Visit_Date"
    Public ReadOnly Property Opd_Visit_Date() As System.String 
    Get
        Return m_Opd_Visit_Date
    End Get
    End Property

    Private m_Is_First_Chart As String = "Is_First_Chart"
    Public ReadOnly Property Is_First_Chart() As System.String 
    Get
        Return m_Is_First_Chart
    End Get
    End Property

    Private m_Fid As String = "Fid"
    Public ReadOnly Property Fid() As System.String 
    Get
        Return m_Fid
    End Get
    End Property

    Private m_Belong_Dept_Code As String = "Belong_Dept_Code"
    Public ReadOnly Property Belong_Dept_Code() As System.String 
    Get
        Return m_Belong_Dept_Code
    End Get
    End Property

  End Class

End Class
