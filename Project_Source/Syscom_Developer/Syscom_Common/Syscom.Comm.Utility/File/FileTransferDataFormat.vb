Imports Syscom.Comm.TableFactory

Public Class FileTransferDataFormat

    ''' <summary>
    ''' 阻止外部直接宣告
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()

    End Sub

    Public Shared ReadOnly tableName As String = PubFileMapDataTableFactory.tableName

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub example()
        'Dim dataSet As DataSet = New DataSet
        'Dim dataTable As DataTable = PubFileMapDataTableFactory.getDataTableWithSchema
        'Dim dataRow As DataRow = dataTable.NewRow()
        ''使用自己的資料來源取代 New Object 

        'dataRow("File_Name") = New Object
        'dataRow("Order_Seq") = New Object
        'dataRow("Image_Thumb") = New Object
        'dataRow("File_Note") = New Object
        'dataRow("Create_User") = New Object
        'dataRow("Create_Time") = New Object
        'dataRow("Modified_User") = New Object
        'dataRow("Modified_Time") = New Object

        'dataRow("FileByteArray") = New Object
        'dataRow("FileType") = New Object
        'dataRow("FileSub") = New Object
        'dataRow("FileTime") = New Object
        'dataTable.Rows.Add(dataRow)
        'dataSet.Tables.Add(dataTable)
    End Sub

    ''' <summary>
    '''取得資料庫表格的 DataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTable() As DataTable
        Dim rtnDt As DataTable = PubFileMapDataTableFactory.getDataTable
        rtnDt.Columns.Add("FileByteArray")
        rtnDt.Columns.Add("FileType")
        rtnDt.Columns.Add("FileSub")
        rtnDt.Columns.Add("FileTime")
        Return rtnDt
    End Function

    ''' <summary>
    '''取得資料庫表格的 DataTable 加上各欄位的資料型態
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTableWithSchema() As DataTable
        Dim rtnDt As DataTable = PubFileMapDataTableFactory.getDataTableWithSchema
        rtnDt.Columns.Add("FileByteArray")
        rtnDt.Columns("FileByteArray").DataType = System.Type.GetType("System.Byte[]")
        rtnDt.Columns.Add("FileType")
        rtnDt.Columns("FileType").DataType = System.Type.GetType("System.String")
        rtnDt.Columns.Add("FileSub")
        rtnDt.Columns("FileSub").DataType = System.Type.GetType("System.String")
        rtnDt.Columns.Add("FileTime")
        rtnDt.Columns("FileTime").DataType = System.Type.GetType("System.DateTime")
        Return rtnDt
    End Function

End Class
