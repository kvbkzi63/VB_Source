Imports System.Data.SqlClient
Public Class IccCumulativeDataDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2010/7/1 上午 10:56:31
    Public Shared ReadOnly tableName as String="ICC_Cumulative_Data"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Card_Sn", "Row_No", "Year", "Outpatient_Hospital_Count", "Outpatient_Fee_Total",   _
             "Hospital_Fee_Total", "Outpatient_Part_Fee_Total", "Hospital_Emergency_Part_Fee_Total", "Hospital_Emergency_Part_Long_Fee_Total", "Outpatient_Hospital_Part_Fee_Total",   _
             "Outpatient_Hospital_Part_Fee_Limit_Total", "Create_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Int16", "System.String", "System.Int32", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             12, -1, 3, -1, 10,   _
             10, 8, 8, 8, 8,   _
             8, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccCumulativeDataDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Card_Sn") = New Object
        dataRow("Row_No") = New Object
        dataRow("Year") = New Object
        dataRow("Outpatient_Hospital_Count") = New Object
        dataRow("Outpatient_Fee_Total") = New Object
        dataRow("Hospital_Fee_Total") = New Object
        dataRow("Outpatient_Part_Fee_Total") = New Object
        dataRow("Hospital_Emergency_Part_Fee_Total") = New Object
        dataRow("Hospital_Emergency_Part_Long_Fee_Total") = New Object
        dataRow("Outpatient_Hospital_Part_Fee_Total") = New Object
        dataRow("Outpatient_Hospital_Part_Fee_Limit_Total") = New Object
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
            dt.Columns.Add("Year")
            dt.Columns.Add("Outpatient_Hospital_Count")
            dt.Columns.Add("Outpatient_Fee_Total")
            dt.Columns.Add("Hospital_Fee_Total")
            dt.Columns.Add("Outpatient_Part_Fee_Total")
            dt.Columns.Add("Hospital_Emergency_Part_Fee_Total")
            dt.Columns.Add("Hospital_Emergency_Part_Long_Fee_Total")
            dt.Columns.Add("Outpatient_Hospital_Part_Fee_Total")
            dt.Columns.Add("Outpatient_Hospital_Part_Fee_Limit_Total")
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
            dt.Columns.Add("Year")
            dt.Columns("Year").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Outpatient_Hospital_Count")
            dt.Columns("Outpatient_Hospital_Count").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Outpatient_Fee_Total")
            dt.Columns("Outpatient_Fee_Total").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Hospital_Fee_Total")
            dt.Columns("Hospital_Fee_Total").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Outpatient_Part_Fee_Total")
            dt.Columns("Outpatient_Part_Fee_Total").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Hospital_Emergency_Part_Fee_Total")
            dt.Columns("Hospital_Emergency_Part_Fee_Total").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Hospital_Emergency_Part_Long_Fee_Total")
            dt.Columns("Hospital_Emergency_Part_Long_Fee_Total").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Outpatient_Hospital_Part_Fee_Total")
            dt.Columns("Outpatient_Hospital_Part_Fee_Total").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Outpatient_Hospital_Part_Fee_Limit_Total")
            dt.Columns("Outpatient_Hospital_Part_Fee_Limit_Total").DataType = System.Type.GetType("System.String")
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
