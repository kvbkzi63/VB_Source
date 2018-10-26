Imports System.Data.SqlClient
Public Class IccPrescriptMainDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2010/7/1 上午 10:56:37
    Public Shared ReadOnly tableName as String="ICC_Prescript_Main"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Card_Sn", "Row_No", "TreatmentTime", "Order_Type_Id", "Treatment_Item_Code",   _
             "Part_Id", "Usage_Code", "Days", "Tqty", "Prescript_Mark_Id",   _
             "Create_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Int16", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             12, -1, 13, 1, 12,   _
             6, 18, 2, 7, 2,   _
             -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccPrescriptMainDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Card_Sn") = New Object
        dataRow("Row_No") = New Object
        dataRow("TreatmentTime") = New Object
        dataRow("Order_Type_Id") = New Object
        dataRow("Treatment_Item_Code") = New Object
        dataRow("Part_Id") = New Object
        dataRow("Usage_Code") = New Object
        dataRow("Days") = New Object
        dataRow("Tqty") = New Object
        dataRow("Prescript_Mark_Id") = New Object
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
            dt.Columns.Add("TreatmentTime")
            dt.Columns.Add("Order_Type_Id")
            dt.Columns.Add("Treatment_Item_Code")
            dt.Columns.Add("Part_Id")
            dt.Columns.Add("Usage_Code")
            dt.Columns.Add("Days")
            dt.Columns.Add("Tqty")
            dt.Columns.Add("Prescript_Mark_Id")
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
            dt.Columns.Add("TreatmentTime")
            dt.Columns("TreatmentTime").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Type_Id")
            dt.Columns("Order_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Treatment_Item_Code")
            dt.Columns("Treatment_Item_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Part_Id")
            dt.Columns("Part_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Usage_Code")
            dt.Columns("Usage_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Days")
            dt.Columns("Days").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Tqty")
            dt.Columns("Tqty").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Prescript_Mark_Id")
            dt.Columns("Prescript_Mark_Id").DataType = System.Type.GetType("System.String")
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
