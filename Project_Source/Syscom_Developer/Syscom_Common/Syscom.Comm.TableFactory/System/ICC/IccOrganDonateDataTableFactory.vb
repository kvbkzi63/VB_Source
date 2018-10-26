Imports System.Data.SqlClient
Public Class IccOrganDonateDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2010/7/1 上午 10:56:35
    Public Shared ReadOnly tableName as String="ICC_Organ_Donate"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Card_Sn", "Organ_Donate_Id", "Create_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             12, 1, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccOrganDonateDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Card_Sn") = New Object
        dataRow("Organ_Donate_Id") = New Object
        dataRow("Create_Time") = New Object
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
            dt.Columns.Add("Card_Sn")
            dt.Columns.Add("Organ_Donate_Id")
            dt.Columns.Add("Create_Time")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Card_Sn")
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
            dt.Columns.Add("Card_Sn")
            dt.Columns("Card_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Organ_Donate_Id")
            dt.Columns("Organ_Donate_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Card_Sn")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 


End Class
