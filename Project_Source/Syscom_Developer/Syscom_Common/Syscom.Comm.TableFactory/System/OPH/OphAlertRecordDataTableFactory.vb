Imports System.Data.SqlClient
Public Class OphAlertRecordDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/11/23 下午 08:08:04
    Public Shared ReadOnly tableName as String="OPH_Alert_Record"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Medical_Sn", "Item_Code", "Order_Code1", "Order_Sn", "Opd_Visit_Date",   _
             "Order_Record_No", "Counter_Code", "Pharmacy_Sn", "Pharmacy_Sn_No", "Chart_No",   _
             "Pharmacy_12_Code1", "Order_Record_No2", "Order_Code2", "Pharmacy_12_Code2", "Dept_Code",   _
             "Order_Doctor_Code", "Doubt_Content", "Rule_Reason_Code", "Rule_Reason_Else", "Limit_Alert_Level",   _
             "Create_User", "Create_Time", "False_Message"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.Int32", "System.DateTime",   _
             "System.Int32", "System.String", "System.Int32", "System.Int32", "System.String",   _
             "System.String", "System.Int32", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.DateTime", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             15, 6, 20, -1, -1,   _
             -1, 1, -1, -1, 10,   _
             12, -1, 20, 12, 5,   _
             10, 100, 6, 100, 1,   _
             10, -1, 2147483647}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = OphAlertRecordDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Medical_Sn") = New Object
        dataRow("Item_Code") = New Object
        dataRow("Order_Code1") = New Object
        dataRow("Order_Sn") = New Object
        dataRow("Opd_Visit_Date") = New Object
        dataRow("Order_Record_No") = New Object
        dataRow("Counter_Code") = New Object
        dataRow("Pharmacy_Sn") = New Object
        dataRow("Pharmacy_Sn_No") = New Object
        dataRow("Chart_No") = New Object
        dataRow("Pharmacy_12_Code1") = New Object
        dataRow("Order_Record_No2") = New Object
        dataRow("Order_Code2") = New Object
        dataRow("Pharmacy_12_Code2") = New Object
        dataRow("Dept_Code") = New Object
        dataRow("Order_Doctor_Code") = New Object
        dataRow("Doubt_Content") = New Object
        dataRow("Rule_Reason_Code") = New Object
        dataRow("Rule_Reason_Else") = New Object
        dataRow("Limit_Alert_Level") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("False_Message") = New Object
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
            dt.Columns.Add("Medical_Sn")
            dt.Columns.Add("Item_Code")
            dt.Columns.Add("Order_Code1")
            dt.Columns.Add("Order_Sn")
            dt.Columns.Add("Opd_Visit_Date")
            dt.Columns.Add("Order_Record_No")
            dt.Columns.Add("Counter_Code")
            dt.Columns.Add("Pharmacy_Sn")
            dt.Columns.Add("Pharmacy_Sn_No")
            dt.Columns.Add("Chart_No")
            dt.Columns.Add("Pharmacy_12_Code1")
            dt.Columns.Add("Order_Record_No2")
            dt.Columns.Add("Order_Code2")
            dt.Columns.Add("Pharmacy_12_Code2")
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Order_Doctor_Code")
            dt.Columns.Add("Doubt_Content")
            dt.Columns.Add("Rule_Reason_Code")
            dt.Columns.Add("Rule_Reason_Else")
            dt.Columns.Add("Limit_Alert_Level")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("False_Message")
            Dim pkColArray(3) As DataColumn 
            pkColArray(0) = dt.Columns("Medical_Sn")
            pkColArray(1) = dt.Columns("Item_Code")
            pkColArray(2) = dt.Columns("Order_Code1")
            pkColArray(3) = dt.Columns("Order_Sn")
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
            dt.Columns.Add("Medical_Sn")
            dt.Columns("Medical_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Item_Code")
            dt.Columns("Item_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Code1")
            dt.Columns("Order_Code1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Sn")
            dt.Columns("Order_Sn").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Opd_Visit_Date")
            dt.Columns("Opd_Visit_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Order_Record_No")
            dt.Columns("Order_Record_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Counter_Code")
            dt.Columns("Counter_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Pharmacy_Sn")
            dt.Columns("Pharmacy_Sn").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Pharmacy_Sn_No")
            dt.Columns("Pharmacy_Sn_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Chart_No")
            dt.Columns("Chart_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Pharmacy_12_Code1")
            dt.Columns("Pharmacy_12_Code1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Record_No2")
            dt.Columns("Order_Record_No2").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Order_Code2")
            dt.Columns("Order_Code2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Pharmacy_12_Code2")
            dt.Columns("Pharmacy_12_Code2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dept_Code")
            dt.Columns("Dept_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Doctor_Code")
            dt.Columns("Order_Doctor_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Doubt_Content")
            dt.Columns("Doubt_Content").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Rule_Reason_Code")
            dt.Columns("Rule_Reason_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Rule_Reason_Else")
            dt.Columns("Rule_Reason_Else").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Limit_Alert_Level")
            dt.Columns("Limit_Alert_Level").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("False_Message")
            dt.Columns("False_Message").DataType = System.Type.GetType("System.String")
            Dim pkColArray(3) As DataColumn 
            pkColArray(0) = dt.Columns("Medical_Sn")
            pkColArray(1) = dt.Columns("Item_Code")
            pkColArray(2) = dt.Columns("Order_Code1")
            pkColArray(3) = dt.Columns("Order_Sn")
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
            dt.Columns.Add("Medical_Sn")
            dt.Columns.Add("Item_Code")
            dt.Columns.Add("Order_Code1")
            dt.Columns.Add("Order_Sn")
            dt.Columns.Add("Opd_Visit_Date")
            dt.Columns.Add("Order_Record_No")
            dt.Columns.Add("Counter_Code")
            dt.Columns.Add("Pharmacy_Sn")
            dt.Columns.Add("Pharmacy_Sn_No")
            dt.Columns.Add("Chart_No")
            dt.Columns.Add("Pharmacy_12_Code1")
            dt.Columns.Add("Order_Record_No2")
            dt.Columns.Add("Order_Code2")
            dt.Columns.Add("Pharmacy_12_Code2")
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Order_Doctor_Code")
            dt.Columns.Add("Doubt_Content")
            dt.Columns.Add("Rule_Reason_Code")
            dt.Columns.Add("Rule_Reason_Else")
            dt.Columns.Add("Limit_Alert_Level")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("False_Message")
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

  Class OPHAlertRecordPt
    Private m_Medical_Sn As String = "Medical_Sn"
    Public ReadOnly Property Medical_Sn() As System.String 
    Get
        Return m_Medical_Sn
    End Get
    End Property

    Private m_Item_Code As String = "Item_Code"
    Public ReadOnly Property Item_Code() As System.String 
    Get
        Return m_Item_Code
    End Get
    End Property

    Private m_Order_Code1 As String = "Order_Code1"
    Public ReadOnly Property Order_Code1() As System.String 
    Get
        Return m_Order_Code1
    End Get
    End Property

    Private m_Order_Sn As String = "Order_Sn"
    Public ReadOnly Property Order_Sn() As System.String 
    Get
        Return m_Order_Sn
    End Get
    End Property

    Private m_Opd_Visit_Date As String = "Opd_Visit_Date"
    Public ReadOnly Property Opd_Visit_Date() As System.String 
    Get
        Return m_Opd_Visit_Date
    End Get
    End Property

    Private m_Order_Record_No As String = "Order_Record_No"
    Public ReadOnly Property Order_Record_No() As System.String 
    Get
        Return m_Order_Record_No
    End Get
    End Property

    Private m_Counter_Code As String = "Counter_Code"
    Public ReadOnly Property Counter_Code() As System.String 
    Get
        Return m_Counter_Code
    End Get
    End Property

    Private m_Pharmacy_Sn As String = "Pharmacy_Sn"
    Public ReadOnly Property Pharmacy_Sn() As System.String 
    Get
        Return m_Pharmacy_Sn
    End Get
    End Property

    Private m_Pharmacy_Sn_No As String = "Pharmacy_Sn_No"
    Public ReadOnly Property Pharmacy_Sn_No() As System.String 
    Get
        Return m_Pharmacy_Sn_No
    End Get
    End Property

    Private m_Chart_No As String = "Chart_No"
    Public ReadOnly Property Chart_No() As System.String 
    Get
        Return m_Chart_No
    End Get
    End Property

    Private m_Pharmacy_12_Code1 As String = "Pharmacy_12_Code1"
    Public ReadOnly Property Pharmacy_12_Code1() As System.String 
    Get
        Return m_Pharmacy_12_Code1
    End Get
    End Property

    Private m_Order_Record_No2 As String = "Order_Record_No2"
    Public ReadOnly Property Order_Record_No2() As System.String 
    Get
        Return m_Order_Record_No2
    End Get
    End Property

    Private m_Order_Code2 As String = "Order_Code2"
    Public ReadOnly Property Order_Code2() As System.String 
    Get
        Return m_Order_Code2
    End Get
    End Property

    Private m_Pharmacy_12_Code2 As String = "Pharmacy_12_Code2"
    Public ReadOnly Property Pharmacy_12_Code2() As System.String 
    Get
        Return m_Pharmacy_12_Code2
    End Get
    End Property

    Private m_Dept_Code As String = "Dept_Code"
    Public ReadOnly Property Dept_Code() As System.String 
    Get
        Return m_Dept_Code
    End Get
    End Property

    Private m_Order_Doctor_Code As String = "Order_Doctor_Code"
    Public ReadOnly Property Order_Doctor_Code() As System.String 
    Get
        Return m_Order_Doctor_Code
    End Get
    End Property

    Private m_Doubt_Content As String = "Doubt_Content"
    Public ReadOnly Property Doubt_Content() As System.String 
    Get
        Return m_Doubt_Content
    End Get
    End Property

    Private m_Rule_Reason_Code As String = "Rule_Reason_Code"
    Public ReadOnly Property Rule_Reason_Code() As System.String 
    Get
        Return m_Rule_Reason_Code
    End Get
    End Property

    Private m_Rule_Reason_Else As String = "Rule_Reason_Else"
    Public ReadOnly Property Rule_Reason_Else() As System.String 
    Get
        Return m_Rule_Reason_Else
    End Get
    End Property

    Private m_Limit_Alert_Level As String = "Limit_Alert_Level"
    Public ReadOnly Property Limit_Alert_Level() As System.String 
    Get
        Return m_Limit_Alert_Level
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

    Private m_False_Message As String = "False_Message"
    Public ReadOnly Property False_Message() As System.String 
    Get
        Return m_False_Message
    End Get
    End Property

  End Class

End Class
