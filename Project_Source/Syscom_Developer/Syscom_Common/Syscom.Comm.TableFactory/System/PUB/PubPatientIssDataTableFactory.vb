Imports System.Data.SqlClient
Public Class PubPatientIssDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/6/17 下午 06:10:15
    Public Shared ReadOnly tableName as String="PUB_Patient_ISS"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Chart_No", "Evaluate_Date", "Medical_Sn", "HeadNeck_AIS", "HeadNeck_Item",   _
             "Face_AIS", "Face_Item", "Chest_AIS", "Chest_Item", "Abdomen_AIS",   _
             "Abdomen_Item", "Extremity_AIS", "Extremity_Item", "External_AIS", "External_Item",   _
             "ISS_Score", "Create_User", "Create_Time", "Modified_User", "Modified_Time"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.DateTime", "System.String", "System.Int32", "System.String",   _
             "System.Int32", "System.String", "System.Int32", "System.String", "System.Int32",   _
             "System.String", "System.Int32", "System.String", "System.Int32", "System.String",   _
             "System.Int32", "System.String", "System.DateTime", "System.String", "System.DateTime"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, -1, 15, -1, 20,   _
             -1, 20, -1, 20, -1,   _
             20, -1, 20, -1, 20,   _
             -1, 10, -1, 10, -1  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubPatientIssDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Chart_No") = New Object
        dataRow("Evaluate_Date") = New Object
        dataRow("Medical_Sn") = New Object
        dataRow("HeadNeck_AIS") = New Object
        dataRow("HeadNeck_Item") = New Object
        dataRow("Face_AIS") = New Object
        dataRow("Face_Item") = New Object
        dataRow("Chest_AIS") = New Object
        dataRow("Chest_Item") = New Object
        dataRow("Abdomen_AIS") = New Object
        dataRow("Abdomen_Item") = New Object
        dataRow("Extremity_AIS") = New Object
        dataRow("Extremity_Item") = New Object
        dataRow("External_AIS") = New Object
        dataRow("External_Item") = New Object
        dataRow("ISS_Score") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
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
            dt.Columns.Add("Chart_No")
            dt.Columns.Add("Evaluate_Date")
            dt.Columns.Add("Medical_Sn")
            dt.Columns.Add("HeadNeck_AIS")
            dt.Columns.Add("HeadNeck_Item")
            dt.Columns.Add("Face_AIS")
            dt.Columns.Add("Face_Item")
            dt.Columns.Add("Chest_AIS")
            dt.Columns.Add("Chest_Item")
            dt.Columns.Add("Abdomen_AIS")
            dt.Columns.Add("Abdomen_Item")
            dt.Columns.Add("Extremity_AIS")
            dt.Columns.Add("Extremity_Item")
            dt.Columns.Add("External_AIS")
            dt.Columns.Add("External_Item")
            dt.Columns.Add("ISS_Score")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Evaluate_Date")
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
            dt.Columns.Add("Chart_No")
            dt.Columns("Chart_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Evaluate_Date")
            dt.Columns("Evaluate_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Medical_Sn")
            dt.Columns("Medical_Sn").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("HeadNeck_AIS")
            dt.Columns("HeadNeck_AIS").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("HeadNeck_Item")
            dt.Columns("HeadNeck_Item").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Face_AIS")
            dt.Columns("Face_AIS").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Face_Item")
            dt.Columns("Face_Item").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Chest_AIS")
            dt.Columns("Chest_AIS").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Chest_Item")
            dt.Columns("Chest_Item").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Abdomen_AIS")
            dt.Columns("Abdomen_AIS").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Abdomen_Item")
            dt.Columns("Abdomen_Item").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Extremity_AIS")
            dt.Columns("Extremity_AIS").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Extremity_Item")
            dt.Columns("Extremity_Item").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("External_AIS")
            dt.Columns("External_AIS").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("External_Item")
            dt.Columns("External_Item").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ISS_Score")
            dt.Columns("ISS_Score").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Evaluate_Date")
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
            dt.Columns.Add("Chart_No")
            dt.Columns.Add("Evaluate_Date")
            dt.Columns.Add("Medical_Sn")
            dt.Columns.Add("HeadNeck_AIS")
            dt.Columns.Add("HeadNeck_Item")
            dt.Columns.Add("Face_AIS")
            dt.Columns.Add("Face_Item")
            dt.Columns.Add("Chest_AIS")
            dt.Columns.Add("Chest_Item")
            dt.Columns.Add("Abdomen_AIS")
            dt.Columns.Add("Abdomen_Item")
            dt.Columns.Add("Extremity_AIS")
            dt.Columns.Add("Extremity_Item")
            dt.Columns.Add("External_AIS")
            dt.Columns.Add("External_Item")
            dt.Columns.Add("ISS_Score")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
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

  Class PUBPatientISSPt
    Private m_Chart_No As String = "Chart_No"
    Public ReadOnly Property Chart_No() As System.String 
    Get
        Return m_Chart_No
    End Get
    End Property

    Private m_Evaluate_Date As String = "Evaluate_Date"
    Public ReadOnly Property Evaluate_Date() As System.String 
    Get
        Return m_Evaluate_Date
    End Get
    End Property

    Private m_Medical_Sn As String = "Medical_Sn"
    Public ReadOnly Property Medical_Sn() As System.String 
    Get
        Return m_Medical_Sn
    End Get
    End Property

    Private m_HeadNeck_AIS As String = "HeadNeck_AIS"
    Public ReadOnly Property HeadNeck_AIS() As System.String 
    Get
        Return m_HeadNeck_AIS
    End Get
    End Property

    Private m_HeadNeck_Item As String = "HeadNeck_Item"
    Public ReadOnly Property HeadNeck_Item() As System.String 
    Get
        Return m_HeadNeck_Item
    End Get
    End Property

    Private m_Face_AIS As String = "Face_AIS"
    Public ReadOnly Property Face_AIS() As System.String 
    Get
        Return m_Face_AIS
    End Get
    End Property

    Private m_Face_Item As String = "Face_Item"
    Public ReadOnly Property Face_Item() As System.String 
    Get
        Return m_Face_Item
    End Get
    End Property

    Private m_Chest_AIS As String = "Chest_AIS"
    Public ReadOnly Property Chest_AIS() As System.String 
    Get
        Return m_Chest_AIS
    End Get
    End Property

    Private m_Chest_Item As String = "Chest_Item"
    Public ReadOnly Property Chest_Item() As System.String 
    Get
        Return m_Chest_Item
    End Get
    End Property

    Private m_Abdomen_AIS As String = "Abdomen_AIS"
    Public ReadOnly Property Abdomen_AIS() As System.String 
    Get
        Return m_Abdomen_AIS
    End Get
    End Property

    Private m_Abdomen_Item As String = "Abdomen_Item"
    Public ReadOnly Property Abdomen_Item() As System.String 
    Get
        Return m_Abdomen_Item
    End Get
    End Property

    Private m_Extremity_AIS As String = "Extremity_AIS"
    Public ReadOnly Property Extremity_AIS() As System.String 
    Get
        Return m_Extremity_AIS
    End Get
    End Property

    Private m_Extremity_Item As String = "Extremity_Item"
    Public ReadOnly Property Extremity_Item() As System.String 
    Get
        Return m_Extremity_Item
    End Get
    End Property

    Private m_External_AIS As String = "External_AIS"
    Public ReadOnly Property External_AIS() As System.String 
    Get
        Return m_External_AIS
    End Get
    End Property

    Private m_External_Item As String = "External_Item"
    Public ReadOnly Property External_Item() As System.String 
    Get
        Return m_External_Item
    End Get
    End Property

    Private m_ISS_Score As String = "ISS_Score"
    Public ReadOnly Property ISS_Score() As System.String 
    Get
        Return m_ISS_Score
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

  End Class

End Class
