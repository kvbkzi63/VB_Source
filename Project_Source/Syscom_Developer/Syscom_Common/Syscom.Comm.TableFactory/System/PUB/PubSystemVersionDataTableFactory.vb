Imports System.Data.SqlClient
Public Class PubSystemVersionDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:54
    Public Shared ReadOnly tableName as String="PUB_System_Version"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Version_No", "Seq_No", "System_Name", "Function_Name", "Problem_Description",   _
             "BringUp_Date", "Update_Date"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Int16", "System.String", "System.String", "System.String",   _
             "System.DateTime", "System.DateTime"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, -1, 20, 50, 4000,   _
             -1, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubSystemVersionDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Version_No") = New Object
        dataRow("Seq_No") = New Object
        dataRow("System_Name") = New Object
        dataRow("Function_Name") = New Object
        dataRow("Problem_Description") = New Object
        dataRow("BringUp_Date") = New Object
        dataRow("Update_Date") = New Object
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
            dt.Columns.Add("Version_No")
            dt.Columns.Add("Seq_No")
            dt.Columns.Add("System_Name")
            dt.Columns.Add("Function_Name")
            dt.Columns.Add("Problem_Description")
            dt.Columns.Add("BringUp_Date")
            dt.Columns.Add("Update_Date")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Version_No")
            pkColArray(1) = dt.Columns("Seq_No")
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
            dt.Columns.Add("Version_No")
            dt.Columns("Version_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Seq_No")
            dt.Columns("Seq_No").DataType = System.Type.GetType("System.Int16")
            dt.Columns.Add("System_Name")
            dt.Columns("System_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Function_Name")
            dt.Columns("Function_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Problem_Description")
            dt.Columns("Problem_Description").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("BringUp_Date")
            dt.Columns("BringUp_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Update_Date")
            dt.Columns("Update_Date").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Version_No")
            pkColArray(1) = dt.Columns("Seq_No")
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
            dt.Columns.Add("Version_No")
            dt.Columns.Add("Seq_No")
            dt.Columns.Add("System_Name")
            dt.Columns.Add("Function_Name")
            dt.Columns.Add("Problem_Description")
            dt.Columns.Add("BringUp_Date")
            dt.Columns.Add("Update_Date")
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

  Class PUBSystemVersionPt
    Private m_Version_No As String = "Version_No"
    Public ReadOnly Property Version_No() As System.String 
    Get
        Return m_Version_No
    End Get
    End Property

    Private m_Seq_No As String = "Seq_No"
    Public ReadOnly Property Seq_No() As System.String 
    Get
        Return m_Seq_No
    End Get
    End Property

    Private m_System_Name As String = "System_Name"
    Public ReadOnly Property System_Name() As System.String 
    Get
        Return m_System_Name
    End Get
    End Property

    Private m_Function_Name As String = "Function_Name"
    Public ReadOnly Property Function_Name() As System.String 
    Get
        Return m_Function_Name
    End Get
    End Property

    Private m_Problem_Description As String = "Problem_Description"
    Public ReadOnly Property Problem_Description() As System.String 
    Get
        Return m_Problem_Description
    End Get
    End Property

    Private m_BringUp_Date As String = "BringUp_Date"
    Public ReadOnly Property BringUp_Date() As System.String 
    Get
        Return m_BringUp_Date
    End Get
    End Property

    Private m_Update_Date As String = "Update_Date"
    Public ReadOnly Property Update_Date() As System.String 
    Get
        Return m_Update_Date
    End Get
    End Property

  End Class

End Class
