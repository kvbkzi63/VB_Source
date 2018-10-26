Imports System.Data.SqlClient
Public Class NfcNotifyMsgDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/1/15 下午 05:51:07
    Public Shared ReadOnly tableName as String="NFC_Notify_Msg"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "MID", "SendDate", "Type", "Start_Time", "End_Time",   _
             "Status", "Subject", "MsgBody", "ReplyMsg", "ExternalFuction",   _
             "Recipient", "Create_User", "Create_Time", "Modified_User", "Modified_Time",   _
             "App_System_No", "Sub_System_No", "Tsk_Task_no", "Fun_Function_No", "Level",   _
             "Group_Type", "Group_Id", "Group_tx_Id", "Spec_Flag", "Call_IP"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.DateTime", "System.String", "System.DateTime", "System.DateTime",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, -1, 1, -1, -1,   _
             1, 300, 4000, 200, 200,   _
             50, 10, -1, 10, -1,   _
             10, 10, 20, 50, 1,   _
             1, 10, 17, 1, 20  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = NfcNotifyMsgDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("MID") = New Object
        dataRow("SendDate") = New Object
        dataRow("Type") = New Object
        dataRow("Start_Time") = New Object
        dataRow("End_Time") = New Object
        dataRow("Status") = New Object
        dataRow("Subject") = New Object
        dataRow("MsgBody") = New Object
        dataRow("ReplyMsg") = New Object
        dataRow("ExternalFuction") = New Object
        dataRow("Recipient") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("App_System_No") = New Object
        dataRow("Sub_System_No") = New Object
        dataRow("Tsk_Task_no") = New Object
        dataRow("Fun_Function_No") = New Object
        dataRow("Level") = New Object
        dataRow("Group_Type") = New Object
        dataRow("Group_Id") = New Object
        dataRow("Group_tx_Id") = New Object
        dataRow("Spec_Flag") = New Object
        dataRow("Call_IP") = New Object
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
            dt.Columns.Add("MID")
            dt.Columns.Add("SendDate")
            dt.Columns.Add("Type")
            dt.Columns.Add("Start_Time")
            dt.Columns.Add("End_Time")
            dt.Columns.Add("Status")
            dt.Columns.Add("Subject")
            dt.Columns.Add("MsgBody")
            dt.Columns.Add("ReplyMsg")
            dt.Columns.Add("ExternalFuction")
            dt.Columns.Add("Recipient")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("App_System_No")
            dt.Columns.Add("Sub_System_No")
            dt.Columns.Add("Tsk_Task_no")
            dt.Columns.Add("Fun_Function_No")
            dt.Columns.Add("Level")
            dt.Columns.Add("Group_Type")
            dt.Columns.Add("Group_Id")
            dt.Columns.Add("Group_tx_Id")
            dt.Columns.Add("Spec_Flag")
            dt.Columns.Add("Call_IP")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("MID")
            pkColArray(1) = dt.Columns("SendDate")
            pkColArray(2) = dt.Columns("Recipient")
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
            dt.Columns.Add("MID")
            dt.Columns("MID").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("SendDate")
            dt.Columns("SendDate").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Type")
            dt.Columns("Type").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Start_Time")
            dt.Columns("Start_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("End_Time")
            dt.Columns("End_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Status")
            dt.Columns("Status").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Subject")
            dt.Columns("Subject").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("MsgBody")
            dt.Columns("MsgBody").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ReplyMsg")
            dt.Columns("ReplyMsg").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ExternalFuction")
            dt.Columns("ExternalFuction").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Recipient")
            dt.Columns("Recipient").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("App_System_No")
            dt.Columns("App_System_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sub_System_No")
            dt.Columns("Sub_System_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Tsk_Task_no")
            dt.Columns("Tsk_Task_no").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Fun_Function_No")
            dt.Columns("Fun_Function_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Level")
            dt.Columns("Level").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Group_Type")
            dt.Columns("Group_Type").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Group_Id")
            dt.Columns("Group_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Group_tx_Id")
            dt.Columns("Group_tx_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Spec_Flag")
            dt.Columns("Spec_Flag").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Call_IP")
            dt.Columns("Call_IP").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("MID")
            pkColArray(1) = dt.Columns("SendDate")
            pkColArray(2) = dt.Columns("Recipient")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 

    ''' <summary>
    '''取得資料庫表格的 DataTable - 不指定PK
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTableWithNoPK() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName)
            dt.Columns.Add("MID")
            dt.Columns.Add("SendDate")
            dt.Columns.Add("Type")
            dt.Columns.Add("Start_Time")
            dt.Columns.Add("End_Time")
            dt.Columns.Add("Status")
            dt.Columns.Add("Subject")
            dt.Columns.Add("MsgBody")
            dt.Columns.Add("ReplyMsg")
            dt.Columns.Add("ExternalFuction")
            dt.Columns.Add("Recipient")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("App_System_No")
            dt.Columns.Add("Sub_System_No")
            dt.Columns.Add("Tsk_Task_no")
            dt.Columns.Add("Fun_Function_No")
            dt.Columns.Add("Level")
            dt.Columns.Add("Group_Type")
            dt.Columns.Add("Group_Id")
            dt.Columns.Add("Group_tx_Id")
            dt.Columns.Add("Spec_Flag")
            dt.Columns.Add("Call_IP")
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function 

    ''' <summary>
    '''取得資料庫表格的 DataSet
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataSet() As DataSet
        Try
            Dim ds As DataSet = New DataSet
             
            Dim dt As Datatable = getDataTable() 
             
            ds.Tables.Add(dt) 
             
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function 

    ''' <summary>
    '''取得資料庫表格的 DataSet 加上各欄位的資料型態
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataSetWithSchema() As DataSet
        Try
            Dim ds As DataSet = New DataSet
             
            Dim dt As Datatable = getDataTableWithSchema() 
             
            ds.Tables.Add(dt) 
             
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function 

    ''' <summary>
    '''取得資料庫表格的 DataSet - 不指定PK
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataSetWithNoPK() As DataSet
        Try
            Dim ds As DataSet = New DataSet
             
            Dim dt As Datatable = getDataTableWithNoPK() 
             
            ds.Tables.Add(dt) 
             
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function 

  Class NFCNotifyMsgPt
    Private m_MID As String = "MID"
    Public ReadOnly Property MID() As System.String 
    Get
        Return m_MID
    End Get
    End Property

    Private m_SendDate As String = "SendDate"
    Public ReadOnly Property SendDate() As System.String 
    Get
        Return m_SendDate
    End Get
    End Property

    Private m_Type As String = "Type"
    Public ReadOnly Property Type() As System.String 
    Get
        Return m_Type
    End Get
    End Property

    Private m_Start_Time As String = "Start_Time"
    Public ReadOnly Property Start_Time() As System.String 
    Get
        Return m_Start_Time
    End Get
    End Property

    Private m_End_Time As String = "End_Time"
    Public ReadOnly Property End_Time() As System.String 
    Get
        Return m_End_Time
    End Get
    End Property

    Private m_Status As String = "Status"
    Public ReadOnly Property Status() As System.String 
    Get
        Return m_Status
    End Get
    End Property

    Private m_Subject As String = "Subject"
    Public ReadOnly Property Subject() As System.String 
    Get
        Return m_Subject
    End Get
    End Property

    Private m_MsgBody As String = "MsgBody"
    Public ReadOnly Property MsgBody() As System.String 
    Get
        Return m_MsgBody
    End Get
    End Property

    Private m_ReplyMsg As String = "ReplyMsg"
    Public ReadOnly Property ReplyMsg() As System.String 
    Get
        Return m_ReplyMsg
    End Get
    End Property

    Private m_ExternalFuction As String = "ExternalFuction"
    Public ReadOnly Property ExternalFuction() As System.String 
    Get
        Return m_ExternalFuction
    End Get
    End Property

    Private m_Recipient As String = "Recipient"
    Public ReadOnly Property Recipient() As System.String 
    Get
        Return m_Recipient
    End Get
    End Property

    Private m_Create_User As String = "Create_User"
    Public ReadOnly Property Create_User() As System.String 
    Get
        Return m_Create_User
    End Get
    End Property

    Private m_Create_Time As String = "Create_Time"
    Public ReadOnly Property Create_Time() As System.String 
    Get
        Return m_Create_Time
    End Get
    End Property

    Private m_Modified_User As String = "Modified_User"
    Public ReadOnly Property Modified_User() As System.String 
    Get
        Return m_Modified_User
    End Get
    End Property

    Private m_Modified_Time As String = "Modified_Time"
    Public ReadOnly Property Modified_Time() As System.String 
    Get
        Return m_Modified_Time
    End Get
    End Property

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

    Private m_Level As String = "Level"
    Public ReadOnly Property Level() As System.String 
    Get
        Return m_Level
    End Get
    End Property

    Private m_Group_Type As String = "Group_Type"
    Public ReadOnly Property Group_Type() As System.String 
    Get
        Return m_Group_Type
    End Get
    End Property

    Private m_Group_Id As String = "Group_Id"
    Public ReadOnly Property Group_Id() As System.String 
    Get
        Return m_Group_Id
    End Get
    End Property

    Private m_Group_tx_Id As String = "Group_tx_Id"
    Public ReadOnly Property Group_tx_Id() As System.String 
    Get
        Return m_Group_tx_Id
    End Get
    End Property

    Private m_Spec_Flag As String = "Spec_Flag"
    Public ReadOnly Property Spec_Flag() As System.String 
    Get
        Return m_Spec_Flag
    End Get
    End Property

    Private m_Call_IP As String = "Call_IP"
    Public ReadOnly Property Call_IP() As System.String 
    Get
        Return m_Call_IP
    End Get
    End Property

  End Class

End Class
