Imports System.Data.SqlClient
Public Class IccTreatmentNeedHpcDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2010/7/1 上午 10:56:38
    Public Shared ReadOnly tableName as String="ICC_Treatment_Need_HPC"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Card_Sn", "Row_No", "TreatmentTime", "Diagnosis_Code", "Second_Diagnosis_Code1",   _
             "Second_Diagnosis_Code2", "Second_Diagnosis_Code3", "Second_Diagnosis_Code4", "Second_Diagnosis_Code5", "Create_Time"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Int16", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.DateTime"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             12, -1, 13, 5, 5,   _
             5, 5, 5, 5, -1  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccTreatmentNeedHpcDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Card_Sn") = New Object
        dataRow("Row_No") = New Object
        dataRow("TreatmentTime") = New Object
        dataRow("Diagnosis_Code") = New Object
        dataRow("Second_Diagnosis_Code1") = New Object
        dataRow("Second_Diagnosis_Code2") = New Object
        dataRow("Second_Diagnosis_Code3") = New Object
        dataRow("Second_Diagnosis_Code4") = New Object
        dataRow("Second_Diagnosis_Code5") = New Object
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
            dt.Columns.Add("Diagnosis_Code")
            dt.Columns.Add("Second_Diagnosis_Code1")
            dt.Columns.Add("Second_Diagnosis_Code2")
            dt.Columns.Add("Second_Diagnosis_Code3")
            dt.Columns.Add("Second_Diagnosis_Code4")
            dt.Columns.Add("Second_Diagnosis_Code5")
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
            dt.Columns.Add("Diagnosis_Code")
            dt.Columns("Diagnosis_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Second_Diagnosis_Code1")
            dt.Columns("Second_Diagnosis_Code1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Second_Diagnosis_Code2")
            dt.Columns("Second_Diagnosis_Code2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Second_Diagnosis_Code3")
            dt.Columns("Second_Diagnosis_Code3").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Second_Diagnosis_Code4")
            dt.Columns("Second_Diagnosis_Code4").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Second_Diagnosis_Code5")
            dt.Columns("Second_Diagnosis_Code5").DataType = System.Type.GetType("System.String")
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
