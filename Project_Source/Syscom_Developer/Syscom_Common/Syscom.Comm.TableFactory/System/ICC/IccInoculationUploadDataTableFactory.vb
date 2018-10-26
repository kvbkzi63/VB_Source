Imports System.Data.SqlClient
Public Class IccInoculationUploadDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2010/7/1 上午 10:56:33
    Public Shared ReadOnly tableName as String="ICC_Inoculation_Upload"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Inoculation_Sn", "A00", "A01", "A02", "A11",   _
             "A12", "A13", "A16", "A20", "A21",   _
             "A24", "Source_Type_Id1", "Source_Type_Id2", "Upload_Type_Id", "Upload_Time",   _
             "Is_Verify_Succeed", "Verify_Fail_Message", "Chart_No", "Source_Sn", "Is_Baby_Stool",   _
             "Cancel", "Cancel_User", "Cancel_Time", "Create_User", "Create_Time",   _
             "Create_SearchTime", "Modified_User", "Modified_Time", "Is_History", "TreatmentTime",   _
             "Is_Fix", "Fix_Inoculation_Sn"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime",   _
             "System.String", "System.String", "System.DateTime", "System.String", "System.String",   _
             "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 1, 1, 3, 12,   _
             10, 7, 12, 7, 1,   _
             1, 1, 1, 1, 13,   _
             1, 128, 10, 15, 1,   _
             1, 10, -1, 10, -1,   _
             16, 10, -1, 1, 13,   _
             1, 10}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = IccInoculationUploadDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Inoculation_Sn") = New Object
        dataRow("A00") = New Object
        dataRow("A01") = New Object
        dataRow("A02") = New Object
        dataRow("A11") = New Object
        dataRow("A12") = New Object
        dataRow("A13") = New Object
        dataRow("A16") = New Object
        dataRow("A20") = New Object
        dataRow("A21") = New Object
        dataRow("A24") = New Object
        dataRow("Source_Type_Id1") = New Object
        dataRow("Source_Type_Id2") = New Object
        dataRow("Upload_Type_Id") = New Object
        dataRow("Upload_Time") = New Object
        dataRow("Is_Verify_Succeed") = New Object
        dataRow("Verify_Fail_Message") = New Object
        dataRow("Chart_No") = New Object
        dataRow("Source_Sn") = New Object
        dataRow("Is_Baby_Stool") = New Object
        dataRow("Cancel") = New Object
        dataRow("Cancel_User") = New Object
        dataRow("Cancel_Time") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Create_SearchTime") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Is_History") = New Object
        dataRow("TreatmentTime") = New Object
        dataRow("Is_Fix") = New Object
        dataRow("Fix_Inoculation_Sn") = New Object
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
            dt.Columns.Add("Inoculation_Sn")
            dt.Columns.Add("A00")
            dt.Columns.Add("A01")
            dt.Columns.Add("A02")
            dt.Columns.Add("A11")
            dt.Columns.Add("A12")
            dt.Columns.Add("A13")
            dt.Columns.Add("A16")
            dt.Columns.Add("A20")
            dt.Columns.Add("A21")
            dt.Columns.Add("A24")
            dt.Columns.Add("Source_Type_Id1")
            dt.Columns.Add("Source_Type_Id2")
            dt.Columns.Add("Upload_Type_Id")
            dt.Columns.Add("Upload_Time")
            dt.Columns.Add("Is_Verify_Succeed")
            dt.Columns.Add("Verify_Fail_Message")
            dt.Columns.Add("Chart_No")
            dt.Columns.Add("Source_Sn")
            dt.Columns.Add("Is_Baby_Stool")
            dt.Columns.Add("Cancel")
            dt.Columns.Add("Cancel_User")
            dt.Columns.Add("Cancel_Time")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Create_SearchTime")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Is_History")
            dt.Columns.Add("TreatmentTime")
            dt.Columns.Add("Is_Fix")
            dt.Columns.Add("Fix_Inoculation_Sn")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Inoculation_Sn")
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
            dt.Columns.Add("Inoculation_Sn")
            dt.Columns("Inoculation_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A00")
            dt.Columns("A00").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A01")
            dt.Columns("A01").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A02")
            dt.Columns("A02").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A11")
            dt.Columns("A11").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A12")
            dt.Columns("A12").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A13")
            dt.Columns("A13").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A16")
            dt.Columns("A16").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A20")
            dt.Columns("A20").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A21")
            dt.Columns("A21").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("A24")
            dt.Columns("A24").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Source_Type_Id1")
            dt.Columns("Source_Type_Id1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Source_Type_Id2")
            dt.Columns("Source_Type_Id2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Upload_Type_Id")
            dt.Columns("Upload_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Upload_Time")
            dt.Columns("Upload_Time").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Verify_Succeed")
            dt.Columns("Is_Verify_Succeed").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Verify_Fail_Message")
            dt.Columns("Verify_Fail_Message").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Chart_No")
            dt.Columns("Chart_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Source_Sn")
            dt.Columns("Source_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Baby_Stool")
            dt.Columns("Is_Baby_Stool").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cancel")
            dt.Columns("Cancel").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cancel_User")
            dt.Columns("Cancel_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cancel_Time")
            dt.Columns("Cancel_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Create_SearchTime")
            dt.Columns("Create_SearchTime").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Is_History")
            dt.Columns("Is_History").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("TreatmentTime")
            dt.Columns("TreatmentTime").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Fix")
            dt.Columns("Is_Fix").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Fix_Inoculation_Sn")
            dt.Columns("Fix_Inoculation_Sn").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Inoculation_Sn")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 


End Class
