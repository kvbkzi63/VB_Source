Imports System.Data.SqlClient
Public Class PubBatchControlDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:47
    Public Shared ReadOnly tableName as String="PUB_Batch_Control"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "App_System_No", "Sub_System_No", "Tsk_Task_no", "Fun_Function_No", "PreFun_Seq_No",   _
             "PreFun_Function_No", "Fun_Function_Desc", "ReExecute_Flag", "Last_Execute_DateTime", "Last_Execute_Result",   _
             "Last_Success_DateTime", "Total_Count", "Success_Count", "Fail_Count", "Keep_Days",   _
             "Person_In_Charge"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.Int16",   _
             "System.String", "System.String", "System.String", "System.DateTime", "System.String",   _
             "System.DateTime", "System.String", "System.String", "System.String", "System.Int16",   _
             "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 10, 10, 40, -1,   _
             40, 100, 1, -1, 1,   _
             -1, 10, 10, 10, -1,   _
             30}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubBatchControlDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("App_System_No") = New Object
        dataRow("Sub_System_No") = New Object
        dataRow("Tsk_Task_no") = New Object
        dataRow("Fun_Function_No") = New Object
        dataRow("PreFun_Seq_No") = New Object
        dataRow("PreFun_Function_No") = New Object
        dataRow("Fun_Function_Desc") = New Object
        dataRow("ReExecute_Flag") = New Object
        dataRow("Last_Execute_DateTime") = New Object
        dataRow("Last_Execute_Result") = New Object
        dataRow("Last_Success_DateTime") = New Object
        dataRow("Total_Count") = New Object
        dataRow("Success_Count") = New Object
        dataRow("Fail_Count") = New Object
        dataRow("Keep_Days") = New Object
        dataRow("Person_In_Charge") = New Object
        dataTable.Rows.Add(dataRow) 
        dataSet.Tables.Add(dataTable) 
    End sub 

    ''' <summary>
    '''取得資料庫表格(無主鍵)的 DataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTable() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName)
            dt.Columns.Add("App_System_No")
            dt.Columns.Add("Sub_System_No")
            dt.Columns.Add("Tsk_Task_no")
            dt.Columns.Add("Fun_Function_No")
            dt.Columns.Add("PreFun_Seq_No")
            dt.Columns.Add("PreFun_Function_No")
            dt.Columns.Add("Fun_Function_Desc")
            dt.Columns.Add("ReExecute_Flag")
            dt.Columns.Add("Last_Execute_DateTime")
            dt.Columns.Add("Last_Execute_Result")
            dt.Columns.Add("Last_Success_DateTime")
            dt.Columns.Add("Total_Count")
            dt.Columns.Add("Success_Count")
            dt.Columns.Add("Fail_Count")
            dt.Columns.Add("Keep_Days")
            dt.Columns.Add("Person_In_Charge")
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 

    ''' <summary>
    '''取得資料庫表格(無主鍵)的 DataTable 加上各欄位的資料型態
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
            dt.Columns.Add("PreFun_Seq_No")
            dt.Columns("PreFun_Seq_No").DataType = System.Type.GetType("System.Int16")
            dt.Columns.Add("PreFun_Function_No")
            dt.Columns("PreFun_Function_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Fun_Function_Desc")
            dt.Columns("Fun_Function_Desc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ReExecute_Flag")
            dt.Columns("ReExecute_Flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Last_Execute_DateTime")
            dt.Columns("Last_Execute_DateTime").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Last_Execute_Result")
            dt.Columns("Last_Execute_Result").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Last_Success_DateTime")
            dt.Columns("Last_Success_DateTime").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Total_Count")
            dt.Columns("Total_Count").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Success_Count")
            dt.Columns("Success_Count").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Fail_Count")
            dt.Columns("Fail_Count").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Keep_Days")
            dt.Columns("Keep_Days").DataType = System.Type.GetType("System.Int16")
            dt.Columns.Add("Person_In_Charge")
            dt.Columns("Person_In_Charge").DataType = System.Type.GetType("System.String")
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 

  Class PUBBatchControlPt
    Private m_App_System_No As String = "App_System_No"
    Public ReadOnly Property App_System_No() As System.String 
    Get
        Return m_App_System_No
    End Get
    End Property

    Private m_Sub_System_No As String = "Sub_System_No"
    Public ReadOnly Property Sub_System_No() As System.String 
    Get
        Return m_Sub_System_No
    End Get
    End Property

    Private m_Tsk_Task_no As String = "Tsk_Task_no"
    Public ReadOnly Property Tsk_Task_no() As System.String 
    Get
        Return m_Tsk_Task_no
    End Get
    End Property

    Private m_Fun_Function_No As String = "Fun_Function_No"
    Public ReadOnly Property Fun_Function_No() As System.String 
    Get
        Return m_Fun_Function_No
    End Get
    End Property

    Private m_PreFun_Seq_No As String = "PreFun_Seq_No"
    Public ReadOnly Property PreFun_Seq_No() As System.String 
    Get
        Return m_PreFun_Seq_No
    End Get
    End Property

    Private m_PreFun_Function_No As String = "PreFun_Function_No"
    Public ReadOnly Property PreFun_Function_No() As System.String 
    Get
        Return m_PreFun_Function_No
    End Get
    End Property

    Private m_Fun_Function_Desc As String = "Fun_Function_Desc"
    Public ReadOnly Property Fun_Function_Desc() As System.String 
    Get
        Return m_Fun_Function_Desc
    End Get
    End Property

    Private m_ReExecute_Flag As String = "ReExecute_Flag"
    Public ReadOnly Property ReExecute_Flag() As System.String 
    Get
        Return m_ReExecute_Flag
    End Get
    End Property

    Private m_Last_Execute_DateTime As String = "Last_Execute_DateTime"
    Public ReadOnly Property Last_Execute_DateTime() As System.String 
    Get
        Return m_Last_Execute_DateTime
    End Get
    End Property

    Private m_Last_Execute_Result As String = "Last_Execute_Result"
    Public ReadOnly Property Last_Execute_Result() As System.String 
    Get
        Return m_Last_Execute_Result
    End Get
    End Property

    Private m_Last_Success_DateTime As String = "Last_Success_DateTime"
    Public ReadOnly Property Last_Success_DateTime() As System.String 
    Get
        Return m_Last_Success_DateTime
    End Get
    End Property

    Private m_Total_Count As String = "Total_Count"
    Public ReadOnly Property Total_Count() As System.String 
    Get
        Return m_Total_Count
    End Get
    End Property

    Private m_Success_Count As String = "Success_Count"
    Public ReadOnly Property Success_Count() As System.String 
    Get
        Return m_Success_Count
    End Get
    End Property

    Private m_Fail_Count As String = "Fail_Count"
    Public ReadOnly Property Fail_Count() As System.String 
    Get
        Return m_Fail_Count
    End Get
    End Property

    Private m_Keep_Days As String = "Keep_Days"
    Public ReadOnly Property Keep_Days() As System.String 
    Get
        Return m_Keep_Days
    End Get
    End Property

    Private m_Person_In_Charge As String = "Person_In_Charge"
    Public ReadOnly Property Person_In_Charge() As System.String 
    Get
        Return m_Person_In_Charge
    End Get
    End Property

  End Class

End Class
