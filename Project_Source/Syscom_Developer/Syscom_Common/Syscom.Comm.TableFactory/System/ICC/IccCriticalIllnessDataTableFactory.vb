Imports System.Data.SqlClient
Public Class IccCriticalIllnessDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2010/7/1 上午 10:56:30
    Public Shared ReadOnly tableName as String="ICC_Critical_Illness"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Card_Sn", "Row_No", "Illness_Id", "Expired_StartDate", "Expired_EndDate",   _
             "Is_Part", "Is_All", "Create_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Int16", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             12, -1, 5, 7, 7,   _
             1, 1, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccCriticalIllnessDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Card_Sn") = New Object
        dataRow("Row_No") = New Object
        dataRow("Illness_Id") = New Object
        dataRow("Expired_StartDate") = New Object
        dataRow("Expired_EndDate") = New Object
        dataRow("Is_Part") = New Object
        dataRow("Is_All") = New Object
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
            dt.Columns.Add("Row_No")
            dt.Columns.Add("Illness_Id")
            dt.Columns.Add("Expired_StartDate")
            dt.Columns.Add("Expired_EndDate")
            dt.Columns.Add("Is_Part")
            dt.Columns.Add("Is_All")
            dt.Columns.Add("Create_Time")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Card_Sn")
            pkColArray(1) = dt.Columns("Row_No")
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
            dt.Columns.Add("Row_No")
            dt.Columns("Row_No").DataType = System.Type.GetType("System.Int16")
            dt.Columns.Add("Illness_Id")
            dt.Columns("Illness_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Expired_StartDate")
            dt.Columns("Expired_StartDate").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Expired_EndDate")
            dt.Columns("Expired_EndDate").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Part")
            dt.Columns("Is_Part").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_All")
            dt.Columns("Is_All").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Card_Sn")
            pkColArray(1) = dt.Columns("Row_No")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 


End Class
