Imports System.Data.SqlClient
Public Class NfcNotifierByfunctionDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2010/8/24 下午 04:33:51
    Public Shared ReadOnly tableName as String="NFC_Notifier_ByFunction"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "App_System_No", "Sub_System_No", "Tsk_Task_no", "Fun_Function_No", "Notifier_ID",   _
             "Notifier_Name", "EMail", "Employee_Flag", "BBCall_Flag", "MSN_Flag",   _
             "OP_Flag", "Mail_Flag", "Error_Flag", "Warn_Flag", "Info_Flag"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 10, 10, 40, 10,   _
             20, 50, 1, 1, 1,   _
             1, 1, 1, 1, 1  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = NfcNotifierByfunctionDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("App_System_No") = New Object
        dataRow("Sub_System_No") = New Object
        dataRow("Tsk_Task_no") = New Object
        dataRow("Fun_Function_No") = New Object
        dataRow("Notifier_ID") = New Object
        dataRow("Notifier_Name") = New Object
        dataRow("EMail") = New Object
        dataRow("Employee_Flag") = New Object
        dataRow("BBCall_Flag") = New Object
        dataRow("MSN_Flag") = New Object
        dataRow("OP_Flag") = New Object
        dataRow("Mail_Flag") = New Object
        dataRow("Error_Flag") = New Object
        dataRow("Warn_Flag") = New Object
        dataRow("Info_Flag") = New Object
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
            dt.Columns.Add("App_System_No")
            dt.Columns.Add("Sub_System_No")
            dt.Columns.Add("Tsk_Task_no")
            dt.Columns.Add("Fun_Function_No")
            dt.Columns.Add("Notifier_ID")
            dt.Columns.Add("Notifier_Name")
            dt.Columns.Add("EMail")
            dt.Columns.Add("Employee_Flag")
            dt.Columns.Add("BBCall_Flag")
            dt.Columns.Add("MSN_Flag")
            dt.Columns.Add("OP_Flag")
            dt.Columns.Add("Mail_Flag")
            dt.Columns.Add("Error_Flag")
            dt.Columns.Add("Warn_Flag")
            dt.Columns.Add("Info_Flag")
            Dim pkColArray(4) As DataColumn 
            pkColArray(0) = dt.Columns("App_System_No")
            pkColArray(1) = dt.Columns("Sub_System_No")
            pkColArray(2) = dt.Columns("Tsk_Task_no")
            pkColArray(3) = dt.Columns("Fun_Function_No")
            pkColArray(4) = dt.Columns("Notifier_ID")
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
            dt.Columns.Add("App_System_No")
            dt.Columns("App_System_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sub_System_No")
            dt.Columns("Sub_System_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Tsk_Task_no")
            dt.Columns("Tsk_Task_no").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Fun_Function_No")
            dt.Columns("Fun_Function_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Notifier_ID")
            dt.Columns("Notifier_ID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Notifier_Name")
            dt.Columns("Notifier_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("EMail")
            dt.Columns("EMail").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Employee_Flag")
            dt.Columns("Employee_Flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("BBCall_Flag")
            dt.Columns("BBCall_Flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("MSN_Flag")
            dt.Columns("MSN_Flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("OP_Flag")
            dt.Columns("OP_Flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Mail_Flag")
            dt.Columns("Mail_Flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Error_Flag")
            dt.Columns("Error_Flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Warn_Flag")
            dt.Columns("Warn_Flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Info_Flag")
            dt.Columns("Info_Flag").DataType = System.Type.GetType("System.String")
            Dim pkColArray(4) As DataColumn 
            pkColArray(0) = dt.Columns("App_System_No")
            pkColArray(1) = dt.Columns("Sub_System_No")
            pkColArray(2) = dt.Columns("Tsk_Task_no")
            pkColArray(3) = dt.Columns("Fun_Function_No")
            pkColArray(4) = dt.Columns("Notifier_ID")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 


End Class
