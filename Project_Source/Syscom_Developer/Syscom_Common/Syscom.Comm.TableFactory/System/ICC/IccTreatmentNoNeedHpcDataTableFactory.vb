Imports System.Data.SqlClient
Public Class IccTreatmentNoNeedHpcDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2010/7/1 上午 10:56:38
    Public Shared ReadOnly tableName as String="ICC_Treatment_No_Need_HPC"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Card_Sn", "Row_No", "Treatment_Category_Id", "Births_Seq_Id", "TreatmentTime",   _
             "Card_Mark_Id", "Treatment_Sn", "Hospital_Code", "Outpatient_Fee", "Outpatient_Part_Fee",   _
             "Hospital_Fee", "Hospital_Part_Fee", "Hospital_Part_Long_Fee", "Create_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Int16", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             12, -1, 2, 1, 13,   _
             1, 4, 10, 8, 8,   _
             8, 7, 7, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccTreatmentNoNeedHpcDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Card_Sn") = New Object
        dataRow("Row_No") = New Object
        dataRow("Treatment_Category_Id") = New Object
        dataRow("Births_Seq_Id") = New Object
        dataRow("TreatmentTime") = New Object
        dataRow("Card_Mark_Id") = New Object
        dataRow("Treatment_Sn") = New Object
        dataRow("Hospital_Code") = New Object
        dataRow("Outpatient_Fee") = New Object
        dataRow("Outpatient_Part_Fee") = New Object
        dataRow("Hospital_Fee") = New Object
        dataRow("Hospital_Part_Fee") = New Object
        dataRow("Hospital_Part_Long_Fee") = New Object
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
            dt.Columns.Add("Treatment_Category_Id")
            dt.Columns.Add("Births_Seq_Id")
            dt.Columns.Add("TreatmentTime")
            dt.Columns.Add("Card_Mark_Id")
            dt.Columns.Add("Treatment_Sn")
            dt.Columns.Add("Hospital_Code")
            dt.Columns.Add("Outpatient_Fee")
            dt.Columns.Add("Outpatient_Part_Fee")
            dt.Columns.Add("Hospital_Fee")
            dt.Columns.Add("Hospital_Part_Fee")
            dt.Columns.Add("Hospital_Part_Long_Fee")
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
            dt.Columns.Add("Treatment_Category_Id")
            dt.Columns("Treatment_Category_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Births_Seq_Id")
            dt.Columns("Births_Seq_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("TreatmentTime")
            dt.Columns("TreatmentTime").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Card_Mark_Id")
            dt.Columns("Card_Mark_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Treatment_Sn")
            dt.Columns("Treatment_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Hospital_Code")
            dt.Columns("Hospital_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Outpatient_Fee")
            dt.Columns("Outpatient_Fee").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Outpatient_Part_Fee")
            dt.Columns("Outpatient_Part_Fee").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Hospital_Fee")
            dt.Columns("Hospital_Fee").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Hospital_Part_Fee")
            dt.Columns("Hospital_Part_Fee").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Hospital_Part_Long_Fee")
            dt.Columns("Hospital_Part_Long_Fee").DataType = System.Type.GetType("System.String")
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
