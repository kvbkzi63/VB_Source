Imports System.Data.SqlClient
Public Class PubRuleDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2011/11/14 上午 11:54:00
    Public Shared ReadOnly tableName as String="PUB_Rule"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Rule_Code", "Rule_Name", "Check_Type", "Expression_Str", "Check_Identity",   _
             "Limit_Alert_Level", "Is_Sending_Alert_Mail", "Is_Rule_Reason", "Is_Enabled_Client", "Is_Enabled_Server",   _
             "Is_Only_SO", "Is_Only_SE", "Is_Only_SI", "Is_Only_CO", "Is_Only_CE",   _
             "Is_Only_CI", "True_Message", "False_Message", "Valid_Date_S", "Valid_Date_E",   _
             "Original_Rule_Code", "Create_User", "Create_Time", "Modified_User", "Modified_Time",   _
             "Info_Message", "Parent_Rule_Code", "Is_Bypass_Check", "Input_Notice_Label", "OPH_Rule_Reason",   _
             "Is_Prior_Review", "Ext_No", "Is_Sorted_ByName"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.DateTime", "System.DateTime",   _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             40, 100, 1, 500, 1,   _
             1, 1, 1, 1, 1,   _
             1, 1, 1, 1, 1,   _
             1, 500, 500, -1, -1,   _
             40, 10, -1, 10, -1,   _
             1073741823, 40, 1, 40, 10,   _
             1, 100, 1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubRuleDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Rule_Code") = New Object
        dataRow("Rule_Name") = New Object
        dataRow("Check_Type") = New Object
        dataRow("Expression_Str") = New Object
        dataRow("Check_Identity") = New Object
        dataRow("Limit_Alert_Level") = New Object
        dataRow("Is_Sending_Alert_Mail") = New Object
        dataRow("Is_Rule_Reason") = New Object
        dataRow("Is_Enabled_Client") = New Object
        dataRow("Is_Enabled_Server") = New Object
        dataRow("Is_Only_SO") = New Object
        dataRow("Is_Only_SE") = New Object
        dataRow("Is_Only_SI") = New Object
        dataRow("Is_Only_CO") = New Object
        dataRow("Is_Only_CE") = New Object
        dataRow("Is_Only_CI") = New Object
        dataRow("True_Message") = New Object
        dataRow("False_Message") = New Object
        dataRow("Valid_Date_S") = New Object
        dataRow("Valid_Date_E") = New Object
        dataRow("Original_Rule_Code") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Info_Message") = New Object
        dataRow("Parent_Rule_Code") = New Object
        dataRow("Is_Bypass_Check") = New Object
        dataRow("Input_Notice_Label") = New Object
        dataRow("OPH_Rule_Reason") = New Object
        dataRow("Is_Prior_Review") = New Object
        dataRow("Ext_No") = New Object
        dataRow("Is_Sorted_ByName") = New Object
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
            dt.Columns.Add("Rule_Code")
            dt.Columns.Add("Rule_Name")
            dt.Columns.Add("Check_Type")
            dt.Columns.Add("Expression_Str")
            dt.Columns.Add("Check_Identity")
            dt.Columns.Add("Limit_Alert_Level")
            dt.Columns.Add("Is_Sending_Alert_Mail")
            dt.Columns.Add("Is_Rule_Reason")
            dt.Columns.Add("Is_Enabled_Client")
            dt.Columns.Add("Is_Enabled_Server")
            dt.Columns.Add("Is_Only_SO")
            dt.Columns.Add("Is_Only_SE")
            dt.Columns.Add("Is_Only_SI")
            dt.Columns.Add("Is_Only_CO")
            dt.Columns.Add("Is_Only_CE")
            dt.Columns.Add("Is_Only_CI")
            dt.Columns.Add("True_Message")
            dt.Columns.Add("False_Message")
            dt.Columns.Add("Valid_Date_S")
            dt.Columns.Add("Valid_Date_E")
            dt.Columns.Add("Original_Rule_Code")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Info_Message")
            dt.Columns.Add("Parent_Rule_Code")
            dt.Columns.Add("Is_Bypass_Check")
            dt.Columns.Add("Input_Notice_Label")
            dt.Columns.Add("OPH_Rule_Reason")
            dt.Columns.Add("Is_Prior_Review")
            dt.Columns.Add("Ext_No")
            dt.Columns.Add("Is_Sorted_ByName")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Rule_Code")
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
            dt.Columns.Add("Rule_Code")
            dt.Columns("Rule_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Rule_Name")
            dt.Columns("Rule_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Check_Type")
            dt.Columns("Check_Type").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Expression_Str")
            dt.Columns("Expression_Str").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Check_Identity")
            dt.Columns("Check_Identity").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Limit_Alert_Level")
            dt.Columns("Limit_Alert_Level").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Sending_Alert_Mail")
            dt.Columns("Is_Sending_Alert_Mail").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Rule_Reason")
            dt.Columns("Is_Rule_Reason").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Enabled_Client")
            dt.Columns("Is_Enabled_Client").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Enabled_Server")
            dt.Columns("Is_Enabled_Server").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Only_SO")
            dt.Columns("Is_Only_SO").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Only_SE")
            dt.Columns("Is_Only_SE").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Only_SI")
            dt.Columns("Is_Only_SI").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Only_CO")
            dt.Columns("Is_Only_CO").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Only_CE")
            dt.Columns("Is_Only_CE").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Only_CI")
            dt.Columns("Is_Only_CI").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("True_Message")
            dt.Columns("True_Message").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("False_Message")
            dt.Columns("False_Message").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Valid_Date_S")
            dt.Columns("Valid_Date_S").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Valid_Date_E")
            dt.Columns("Valid_Date_E").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Original_Rule_Code")
            dt.Columns("Original_Rule_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Info_Message")
            dt.Columns("Info_Message").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Parent_Rule_Code")
            dt.Columns("Parent_Rule_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Bypass_Check")
            dt.Columns("Is_Bypass_Check").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Input_Notice_Label")
            dt.Columns("Input_Notice_Label").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("OPH_Rule_Reason")
            dt.Columns("OPH_Rule_Reason").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Prior_Review")
            dt.Columns("Is_Prior_Review").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Ext_No")
            dt.Columns("Ext_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Sorted_ByName")
            dt.Columns("Is_Sorted_ByName").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Rule_Code")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 


End Class
