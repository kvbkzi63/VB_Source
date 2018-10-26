Imports System.Data.SqlClient
Public Class IccRegisterBasicDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2010/7/1 上午 10:56:37
    Public Shared ReadOnly tableName as String="ICC_Register_Basic"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Card_Sn", "Name", "Idno", "Birthday", "Sex_Id",   _
             "IssueDate", "Cancel_Mard_Id", "Insurer_Code", "Insurer_Mark_Id", "Card_ExpiredDate",   _
             "Count", "Baby_Birthday", "Births_Mark_ID", "Is_Basic_Data", "Is_Register_Basic",   _
             "Is_Register_Basic2", "Create_Time"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.Int16", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             12, 20, 10, 7, 1,   _
             7, 1, 2, 1, 7,   _
             -1, 7, 1, 1, 1,   _
             1, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccRegisterBasicDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Card_Sn") = New Object
        dataRow("Name") = New Object
        dataRow("Idno") = New Object
        dataRow("Birthday") = New Object
        dataRow("Sex_Id") = New Object
        dataRow("IssueDate") = New Object
        dataRow("Cancel_Mard_Id") = New Object
        dataRow("Insurer_Code") = New Object
        dataRow("Insurer_Mark_Id") = New Object
        dataRow("Card_ExpiredDate") = New Object
        dataRow("Count") = New Object
        dataRow("Baby_Birthday") = New Object
        dataRow("Births_Mark_ID") = New Object
        dataRow("Is_Basic_Data") = New Object
        dataRow("Is_Register_Basic") = New Object
        dataRow("Is_Register_Basic2") = New Object
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
            dt.Columns.Add("Name")
            dt.Columns.Add("Idno")
            dt.Columns.Add("Birthday")
            dt.Columns.Add("Sex_Id")
            dt.Columns.Add("IssueDate")
            dt.Columns.Add("Cancel_Mard_Id")
            dt.Columns.Add("Insurer_Code")
            dt.Columns.Add("Insurer_Mark_Id")
            dt.Columns.Add("Card_ExpiredDate")
            dt.Columns.Add("Count")
            dt.Columns.Add("Baby_Birthday")
            dt.Columns.Add("Births_Mark_ID")
            dt.Columns.Add("Is_Basic_Data")
            dt.Columns.Add("Is_Register_Basic")
            dt.Columns.Add("Is_Register_Basic2")
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
            dt.Columns.Add("Name")
            dt.Columns("Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Idno")
            dt.Columns("Idno").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Birthday")
            dt.Columns("Birthday").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sex_Id")
            dt.Columns("Sex_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("IssueDate")
            dt.Columns("IssueDate").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cancel_Mard_Id")
            dt.Columns("Cancel_Mard_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insurer_Code")
            dt.Columns("Insurer_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insurer_Mark_Id")
            dt.Columns("Insurer_Mark_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Card_ExpiredDate")
            dt.Columns("Card_ExpiredDate").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Count")
            dt.Columns("Count").DataType = System.Type.GetType("System.Int16")
            dt.Columns.Add("Baby_Birthday")
            dt.Columns("Baby_Birthday").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Births_Mark_ID")
            dt.Columns("Births_Mark_ID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Basic_Data")
            dt.Columns("Is_Basic_Data").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Register_Basic")
            dt.Columns("Is_Register_Basic").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Register_Basic2")
            dt.Columns("Is_Register_Basic2").DataType = System.Type.GetType("System.String")
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
