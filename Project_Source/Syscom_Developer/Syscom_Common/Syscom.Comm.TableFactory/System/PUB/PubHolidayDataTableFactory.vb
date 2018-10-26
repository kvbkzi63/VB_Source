Imports System.Data.SqlClient
Public Class PubHolidayDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/6/24 上午 11:21:02
    Public Shared ReadOnly tableName As String = "PUB_Holiday"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Holiday_Date", "SubSystem_Code", "Description", "Is_Holiday", "Create_User", _
             "Create_Time", "Modified_User", "Modified_Time", "Noon_Code"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.DateTime", "System.String", "System.String", "System.String", "System.String", _
             "System.DateTime", "System.String", "System.DateTime", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             -1, 5, 200, 1, 10, _
             -1, 10, -1, 2}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub example()
        Dim dataSet As DataSet = New DataSet
        Dim dataTable As DataTable = PubHolidayDataTableFactory.getDataTableWithSchema
        Dim dataRow As DataRow = dataTable.NewRow()
        '使用自己的資料來源取代 New Object 
        dataRow("Holiday_Date") = New Object
        dataRow("SubSystem_Code") = New Object
        dataRow("Description") = New Object
        dataRow("Is_Holiday") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Noon_Code") = New Object
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
            dt.Columns.Add("Holiday_Date")
            dt.Columns.Add("SubSystem_Code")
            dt.Columns.Add("Description")
            dt.Columns.Add("Is_Holiday")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Noon_Code")
            Dim pkColArray(1) As DataColumn
            pkColArray(0) = dt.Columns("Holiday_Date")
            pkColArray(1) = dt.Columns("SubSystem_Code")
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
            dt.Columns.Add("Holiday_Date")
            dt.Columns("Holiday_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("SubSystem_Code")
            dt.Columns("SubSystem_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Description")
            dt.Columns("Description").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Holiday")
            dt.Columns("Is_Holiday").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Noon_Code")
            dt.Columns("Noon_Code").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn
            pkColArray(0) = dt.Columns("Holiday_Date")
            pkColArray(1) = dt.Columns("SubSystem_Code")
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
            dt.Columns.Add("Holiday_Date")
            dt.Columns.Add("SubSystem_Code")
            dt.Columns.Add("Description")
            dt.Columns.Add("Is_Holiday")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Noon_Code")
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

    Class PUBHolidayPt
        Private m_Holiday_Date As String = "Holiday_Date"
        Public ReadOnly Property Holiday_Date() As System.String
            Get
                Return m_Holiday_Date
            End Get
        End Property

        Private m_SubSystem_Code As String = "SubSystem_Code"
        Public ReadOnly Property SubSystem_Code() As System.String
            Get
                Return m_SubSystem_Code
            End Get
        End Property

        Private m_Description As String = "Description"
        Public ReadOnly Property Description() As System.String
            Get
                Return m_Description
            End Get
        End Property

        Private m_Is_Holiday As String = "Is_Holiday"
        Public ReadOnly Property Is_Holiday() As System.String
            Get
                Return m_Is_Holiday
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

        Private m_Noon_Code As String = "Noon_Code"
        Public ReadOnly Property Noon_Code() As System.String
            Get
                Return m_Noon_Code
            End Get
        End Property

    End Class

End Class
