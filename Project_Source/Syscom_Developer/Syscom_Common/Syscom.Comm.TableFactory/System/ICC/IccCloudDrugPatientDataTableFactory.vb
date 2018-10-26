Imports System.Data.SqlClient
Public Class IccCloudDrugPatientDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/11/19 上午 09:46:21
    Public Shared ReadOnly tableName As String = "ICC_Cloud_Drug_Patient"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Id_No", "Medical_Date", "Chart_No", "Agree_Effect_Date", "Agree_End_Date", _
             "FID", "Is_Agree", "Is_Old_Agree", "Cancel", "Cancel_User", "Cancel_Time", _
             "Create_User", "Create_Time", "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.DateTime", "System.String", "System.DateTime", "System.DateTime", _
             "System.String", "System.String", "System.String", "System.String", "System.String", "System.DateTime", _
             "System.String", "System.DateTime", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, -1, 10, -1, -1, _
             100, 1, 1, 1, 10, -1, _
             10, -1, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub example()
        Dim dataSet As DataSet = New DataSet
        Dim dataTable As DataTable = IccCloudDrugPatientDataTableFactory.getDataTableWithSchema
        Dim dataRow As DataRow = dataTable.NewRow()
        '使用自己的資料來源取代 New Object 
        dataRow("Id_No") = New Object
        dataRow("Medical_Date") = New Object
        dataRow("Chart_No") = New Object
        dataRow("Agree_Effect_Date") = New Object
        dataRow("Agree_End_Date") = New Object
        dataRow("FID") = New Object
        dataRow("Is_Agree") = New Object
        dataRow("Is_Old_Agree") = New Object
        dataRow("Cancel") = New Object
        dataRow("Cancel_User") = New Object
        dataRow("Cancel_Time") = New Object
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
            dt.Columns.Add("Id_No")
            dt.Columns.Add("Medical_Date")
            dt.Columns.Add("Chart_No")
            dt.Columns.Add("Agree_Effect_Date")
            dt.Columns.Add("Agree_End_Date")
            dt.Columns.Add("FID")
            dt.Columns.Add("Is_Agree")
            dt.Columns.Add("Is_Old_Agree")
            dt.Columns.Add("Cancel")
            dt.Columns.Add("Cancel_User")
            dt.Columns.Add("Cancel_Time")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(1) As DataColumn
            pkColArray(0) = dt.Columns("Id_No")
            pkColArray(1) = dt.Columns("Medical_Date")
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
            dt.Columns.Add("Id_No")
            dt.Columns("Id_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Medical_Date")
            dt.Columns("Medical_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Chart_No")
            dt.Columns("Chart_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Agree_Effect_Date")
            dt.Columns("Agree_Effect_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Agree_End_Date")
            dt.Columns("Agree_End_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("FID")
            dt.Columns("FID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Agree")
            dt.Columns("Is_Agree").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Old_Agree")
            dt.Columns("Is_Old_Agree").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cancel")
            dt.Columns("Cancel").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cancel_User")
            dt.Columns("Cancel_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cancel_Time")
            dt.Columns("Cancel_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(1) As DataColumn
            pkColArray(0) = dt.Columns("Id_No")
            pkColArray(1) = dt.Columns("Medical_Date")
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
            dt.Columns.Add("Id_No")
            dt.Columns.Add("Medical_Date")
            dt.Columns.Add("Chart_No")
            dt.Columns.Add("Agree_Effect_Date")
            dt.Columns.Add("Agree_End_Date")
            dt.Columns.Add("FID")
            dt.Columns.Add("Is_Agree")
            dt.Columns.Add("Is_Old_Agree")
            dt.Columns.Add("Cancel")
            dt.Columns.Add("Cancel_User")
            dt.Columns.Add("Cancel_Time")
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

    Class ICCCloudDrugPatientPt
        Private m_Id_No As String = "Id_No"
        Public ReadOnly Property Id_No() As System.String
            Get
                Return m_Id_No
            End Get
        End Property

        Private m_Medical_Date As String = "Medical_Date"
        Public ReadOnly Property Medical_Date() As System.String
            Get
                Return m_Medical_Date
            End Get
        End Property

        Private m_Chart_No As String = "Chart_No"
        Public ReadOnly Property Chart_No() As System.String
            Get
                Return m_Chart_No
            End Get
        End Property

        Private m_Agree_Effect_Date As String = "Agree_Effect_Date"
        Public ReadOnly Property Agree_Effect_Date() As System.String
            Get
                Return m_Agree_Effect_Date
            End Get
        End Property

        Private m_Agree_End_Date As String = "Agree_End_Date"
        Public ReadOnly Property Agree_End_Date() As System.String
            Get
                Return m_Agree_End_Date
            End Get
        End Property

        Private m_FID As String = "FID"
        Public ReadOnly Property FID() As System.String
            Get
                Return m_FID
            End Get
        End Property

        Private m_Is_Agree As String = "Is_Agree"
        Public ReadOnly Property Is_Agree() As System.String
            Get
                Return m_Is_Agree
            End Get
        End Property

        Private m_Is_Old_Agree As String = "Is_Old_Agree"
        Public ReadOnly Property Is_Old_Agree() As System.String
            Get
                Return m_Is_Old_Agree
            End Get
        End Property

        Private m_Cancel As String = "Cancel"
        Public ReadOnly Property Cancel() As System.String
            Get
                Return m_Cancel
            End Get
        End Property

        Private m_Cancel_User As String = "Cancel_User"
        Public ReadOnly Property Cancel_User() As System.String
            Get
                Return m_Cancel_User
            End Get
        End Property

        Private m_Cancel_Time As String = "Cancel_Time"
        Public ReadOnly Property Cancel_Time() As System.String
            Get
                Return m_Cancel_Time
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