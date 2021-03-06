Imports System.Data.SqlClient
Public Class PubReportAlarmDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/12/15 上午 09:59:30
    Public Shared ReadOnly tableName As String = "PUB_Report_Alarm"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Report_ID", "Rpt_Alarm_Count", "Rpt_Count", "Rpt_Is_Active", "Create_User", _
             "Create_Time", "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Int32", "System.Int32", "System.String", "System.String", _
             "System.DateTime", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             20, -1, -1, 1, 10, _
             -1, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub example()
        Dim dataSet As DataSet = New DataSet
        Dim dataTable As DataTable = PubReportAlarmDataTableFactory.getDataTableWithSchema
        Dim dataRow As DataRow = dataTable.NewRow()
        '使用自己的資料來源取代 New Object 
        dataRow("Report_ID") = New Object
        dataRow("Rpt_Alarm_Count") = New Object
        dataRow("Rpt_Count") = New Object
        dataRow("Rpt_Is_Active") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataTable.Rows.Add(dataRow)
        dataSet.Tables.Add(dataTable)
    End Sub

    ''' <summary>
    '''取得資料庫表格的 DataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTable() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName)
            dt.Columns.Add("Report_ID")
            dt.Columns.Add("Rpt_Alarm_Count")
            dt.Columns.Add("Rpt_Count")
            dt.Columns.Add("Rpt_Is_Active")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(0) As DataColumn
            pkColArray(0) = dt.Columns("Report_ID")
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
            dt.Columns.Add("Report_ID")
            dt.Columns("Report_ID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Rpt_Alarm_Count")
            dt.Columns("Rpt_Alarm_Count").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Rpt_Count")
            dt.Columns("Rpt_Count").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Rpt_Is_Active")
            dt.Columns("Rpt_Is_Active").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(0) As DataColumn
            pkColArray(0) = dt.Columns("Report_ID")
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
            dt.Columns.Add("Report_ID")
            dt.Columns.Add("Rpt_Alarm_Count")
            dt.Columns.Add("Rpt_Count")
            dt.Columns.Add("Rpt_Is_Active")
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

    Class PUBReportAlarmPt
        Private m_Report_ID As String = "Report_ID"
        Public ReadOnly Property Report_ID() As System.String
            Get
                Return m_Report_ID
            End Get
        End Property

        Private m_Rpt_Alarm_Count As String = "Rpt_Alarm_Count"
        Public ReadOnly Property Rpt_Alarm_Count() As System.String
            Get
                Return m_Rpt_Alarm_Count
            End Get
        End Property

        Private m_Rpt_Count As String = "Rpt_Count"
        Public ReadOnly Property Rpt_Count() As System.String
            Get
                Return m_Rpt_Count
            End Get
        End Property

        Private m_Rpt_Is_Active As String = "Rpt_Is_Active"
        Public ReadOnly Property Rpt_Is_Active() As System.String
            Get
                Return m_Rpt_Is_Active
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
