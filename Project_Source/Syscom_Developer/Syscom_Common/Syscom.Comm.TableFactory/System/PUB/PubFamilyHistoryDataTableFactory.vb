Imports System.Data.SqlClient
Public Class PubFamilyHistoryDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:49
    Public Shared ReadOnly tableName as String="PUB_Family_History"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Chart_No", "Family_No", "Title_Id", "Disease_Id", "Disease_Name",   _
             "Remark", "Body_Side"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Int32", "System.String", "System.String", "System.String",   _
             "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, -1, 5, 5, 20,   _
             50, 20}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubFamilyHistoryDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Chart_No") = New Object
        dataRow("Family_No") = New Object
        dataRow("Title_Id") = New Object
        dataRow("Disease_Id") = New Object
        dataRow("Disease_Name") = New Object
        dataRow("Remark") = New Object
        dataRow("Body_Side") = New Object
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
            dt.Columns.Add("Family_No")
            dt.Columns.Add("Title_Id")
            dt.Columns.Add("Disease_Id")
            dt.Columns.Add("Disease_Name")
            dt.Columns.Add("Remark")
            dt.Columns.Add("Body_Side")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Family_No")
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
            dt.Columns.Add("Family_No")
            dt.Columns("Family_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Title_Id")
            dt.Columns("Title_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Disease_Id")
            dt.Columns("Disease_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Disease_Name")
            dt.Columns("Disease_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Remark")
            dt.Columns("Remark").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Body_Side")
            dt.Columns("Body_Side").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
            pkColArray(1) = dt.Columns("Family_No")
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
            dt.Columns.Add("Family_No")
            dt.Columns.Add("Title_Id")
            dt.Columns.Add("Disease_Id")
            dt.Columns.Add("Disease_Name")
            dt.Columns.Add("Remark")
            dt.Columns.Add("Body_Side")
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

  Class PUBFamilyHistoryPt
    Private m_Chart_No As String = "Chart_No"
    Public ReadOnly Property Chart_No() As System.String 
    Get
        Return m_Chart_No
    End Get
    End Property

    Private m_Family_No As String = "Family_No"
    Public ReadOnly Property Family_No() As System.String 
    Get
        Return m_Family_No
    End Get
    End Property

    Private m_Title_Id As String = "Title_Id"
    Public ReadOnly Property Title_Id() As System.String 
    Get
        Return m_Title_Id
    End Get
    End Property

    Private m_Disease_Id As String = "Disease_Id"
    Public ReadOnly Property Disease_Id() As System.String 
    Get
        Return m_Disease_Id
    End Get
    End Property

    Private m_Disease_Name As String = "Disease_Name"
    Public ReadOnly Property Disease_Name() As System.String 
    Get
        Return m_Disease_Name
    End Get
    End Property

    Private m_Remark As String = "Remark"
    Public ReadOnly Property Remark() As System.String 
    Get
        Return m_Remark
    End Get
    End Property

    Private m_Body_Side As String = "Body_Side"
    Public ReadOnly Property Body_Side() As System.String 
    Get
        Return m_Body_Side
    End Get
    End Property

  End Class

End Class
