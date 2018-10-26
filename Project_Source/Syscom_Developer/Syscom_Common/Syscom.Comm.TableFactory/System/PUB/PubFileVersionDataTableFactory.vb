Imports System.Data.SqlClient
Public Class PubFileVersionDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2010/7/1 上午 10:59:04
    Public Shared ReadOnly tableName as String="PUB_File_Version"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "FID", "Version_Sn", "Root_FID", "Pre_Version_FID", "Dc",   _
             "Create_User", "Create_Time", "Modified_User", "Modified_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Int16", "System.String", "System.String", "System.String",   _
             "System.String", "System.DateTime", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             31, -1, 31, 31, 1,   _
             10, -1, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubFileVersionDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("FID") = New Object
        dataRow("Version_Sn") = New Object
        dataRow("Root_FID") = New Object
        dataRow("Pre_Version_FID") = New Object
        dataRow("Dc") = New Object
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
            dt.Columns.Add("FID")
            dt.Columns.Add("Version_Sn")
            dt.Columns.Add("Root_FID")
            dt.Columns.Add("Pre_Version_FID")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("FID")
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
            dt.Columns.Add("FID")
            dt.Columns("FID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Version_Sn")
            dt.Columns("Version_Sn").DataType = System.Type.GetType("System.Int16")
            dt.Columns.Add("Root_FID")
            dt.Columns("Root_FID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Pre_Version_FID")
            dt.Columns("Pre_Version_FID").DataType = System.Type.GetType("System.String")
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
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("FID")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 


End Class
