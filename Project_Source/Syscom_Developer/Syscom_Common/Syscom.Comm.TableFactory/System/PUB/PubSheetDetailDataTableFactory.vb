Imports System.Data.SqlClient
Public Class PubSheetDetailDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/5/20 9:57:14
    Public Shared ReadOnly tableName As String = "PUB_Sheet_Detail"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Sheet_Code", "Order_Code", "Is_Indication", "Is_Print_Indication", "Order_Entry_Note", _
             "Order_Note", "Is_Print_Order_Note", "Separate_Mark", "Exclusive_Order_Code", "Sheet_Detail_Sort_Value", _
             "Dc", "Create_User", "Create_Time", "Modified_User", "Modified_Time", _
             "Is_InstantlyRpt", "Is_Limit_Health"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.Int32", "System.String", "System.Int32", _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime", _
             "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 20, 1, 1, 1073741823, _
             1073741823, 1, -1, 200, -1, _
             1, 10, -1, 10, -1, _
             1, 1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub example()
        Dim dataSet As DataSet = New DataSet
        Dim dataTable As DataTable = PubSheetDetailDataTableFactory.getDataTableWithSchema
        Dim dataRow As DataRow = dataTable.NewRow()
        '使用自己的資料來源取代 New Object 
        dataRow("Sheet_Code") = New Object
        dataRow("Order_Code") = New Object
        dataRow("Is_Indication") = New Object
        dataRow("Is_Print_Indication") = New Object
        dataRow("Order_Entry_Note") = New Object
        dataRow("Order_Note") = New Object
        dataRow("Is_Print_Order_Note") = New Object
        dataRow("Separate_Mark") = New Object
        dataRow("Exclusive_Order_Code") = New Object
        dataRow("Sheet_Detail_Sort_Value") = New Object
        dataRow("Dc") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Is_InstantlyRpt") = New Object
        dataRow("Is_Limit_Health") = New Object
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
            dt.Columns.Add("Sheet_Code")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Is_Indication")
            dt.Columns.Add("Is_Print_Indication")
            dt.Columns.Add("Order_Entry_Note")
            dt.Columns.Add("Order_Note")
            dt.Columns.Add("Is_Print_Order_Note")
            dt.Columns.Add("Separate_Mark")
            dt.Columns.Add("Exclusive_Order_Code")
            dt.Columns.Add("Sheet_Detail_Sort_Value")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Is_InstantlyRpt")
            dt.Columns.Add("Is_Limit_Health")
            Dim pkColArray(1) As DataColumn
            pkColArray(0) = dt.Columns("Sheet_Code")
            pkColArray(1) = dt.Columns("Order_Code")
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
            dt.Columns.Add("Sheet_Code")
            dt.Columns("Sheet_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Indication")
            dt.Columns("Is_Indication").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Print_Indication")
            dt.Columns("Is_Print_Indication").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Entry_Note")
            dt.Columns("Order_Entry_Note").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Note")
            dt.Columns("Order_Note").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Print_Order_Note")
            dt.Columns("Is_Print_Order_Note").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Separate_Mark")
            dt.Columns("Separate_Mark").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Exclusive_Order_Code")
            dt.Columns("Exclusive_Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sheet_Detail_Sort_Value")
            dt.Columns("Sheet_Detail_Sort_Value").DataType = System.Type.GetType("System.Int32")
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
            dt.Columns.Add("Is_InstantlyRpt")
            dt.Columns("Is_InstantlyRpt").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Limit_Health")
            dt.Columns("Is_Limit_Health").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn
            pkColArray(0) = dt.Columns("Sheet_Code")
            pkColArray(1) = dt.Columns("Order_Code")
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
            dt.Columns.Add("Sheet_Code")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Is_Indication")
            dt.Columns.Add("Is_Print_Indication")
            dt.Columns.Add("Order_Entry_Note")
            dt.Columns.Add("Order_Note")
            dt.Columns.Add("Is_Print_Order_Note")
            dt.Columns.Add("Separate_Mark")
            dt.Columns.Add("Exclusive_Order_Code")
            dt.Columns.Add("Sheet_Detail_Sort_Value")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Is_InstantlyRpt")
            dt.Columns.Add("Is_Limit_Health")
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

    Class PUBSheetDetailPt
        Private m_Sheet_Code As String = "Sheet_Code"
        Public ReadOnly Property Sheet_Code() As System.String
            Get
                Return m_Sheet_Code
            End Get
        End Property

        Private m_Order_Code As String = "Order_Code"
        Public ReadOnly Property Order_Code() As System.String
            Get
                Return m_Order_Code
            End Get
        End Property

        Private m_Is_Indication As String = "Is_Indication"
        Public ReadOnly Property Is_Indication() As System.String
            Get
                Return m_Is_Indication
            End Get
        End Property

        Private m_Is_Print_Indication As String = "Is_Print_Indication"
        Public ReadOnly Property Is_Print_Indication() As System.String
            Get
                Return m_Is_Print_Indication
            End Get
        End Property

        Private m_Order_Entry_Note As String = "Order_Entry_Note"
        Public ReadOnly Property Order_Entry_Note() As System.String
            Get
                Return m_Order_Entry_Note
            End Get
        End Property

        Private m_Order_Note As String = "Order_Note"
        Public ReadOnly Property Order_Note() As System.String
            Get
                Return m_Order_Note
            End Get
        End Property

        Private m_Is_Print_Order_Note As String = "Is_Print_Order_Note"
        Public ReadOnly Property Is_Print_Order_Note() As System.String
            Get
                Return m_Is_Print_Order_Note
            End Get
        End Property

        Private m_Separate_Mark As String = "Separate_Mark"
        Public ReadOnly Property Separate_Mark() As System.String
            Get
                Return m_Separate_Mark
            End Get
        End Property

        Private m_Exclusive_Order_Code As String = "Exclusive_Order_Code"
        Public ReadOnly Property Exclusive_Order_Code() As System.String
            Get
                Return m_Exclusive_Order_Code
            End Get
        End Property

        Private m_Sheet_Detail_Sort_Value As String = "Sheet_Detail_Sort_Value"
        Public ReadOnly Property Sheet_Detail_Sort_Value() As System.String
            Get
                Return m_Sheet_Detail_Sort_Value
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

        Private m_Is_InstantlyRpt As String = "Is_InstantlyRpt"
        Public ReadOnly Property Is_InstantlyRpt() As System.String
            Get
                Return m_Is_InstantlyRpt
            End Get
        End Property

        Private m_Is_Limit_Health As String = "Is_Limit_Health"
        Public ReadOnly Property Is_Limit_Health() As System.String
            Get
                Return m_Is_Limit_Health
            End Get
        End Property

    End Class

End Class

