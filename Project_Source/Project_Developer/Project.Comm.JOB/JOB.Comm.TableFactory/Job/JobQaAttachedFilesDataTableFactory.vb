Imports System.Data.SqlClient
Public Class JobQaAttachedFilesDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/11/3 上午 10:30:15
    Public Shared ReadOnly tableName as String="Job_QA_Attached_Files"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Bug_Id", "Version_Id", "Sort_Value", "File_Name", "FID"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.Int32", "System.String", "System.String"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             20, 20, -1, 50, 200  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = JobQaAttachedFilesDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Bug_Id") = New Object
        dataRow("Version_Id") = New Object
        dataRow("Sort_Value") = New Object
        dataRow("File_Name") = New Object
        dataRow("FID") = New Object
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
            dt.Columns.Add("Bug_Id")
            dt.Columns.Add("Version_Id")
            dt.Columns.Add("Sort_Value")
            dt.Columns.Add("File_Name")
            dt.Columns.Add("FID")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Bug_Id")
            pkColArray(1) = dt.Columns("Version_Id")
            pkColArray(2) = dt.Columns("Sort_Value")
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
            dt.Columns.Add("Bug_Id")
            dt.Columns("Bug_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Version_Id")
            dt.Columns("Version_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sort_Value")
            dt.Columns("Sort_Value").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("File_Name")
            dt.Columns("File_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("FID")
            dt.Columns("FID").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Bug_Id")
            pkColArray(1) = dt.Columns("Version_Id")
            pkColArray(2) = dt.Columns("Sort_Value")
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
            dt.Columns.Add("Bug_Id")
            dt.Columns.Add("Version_Id")
            dt.Columns.Add("Sort_Value")
            dt.Columns.Add("File_Name")
            dt.Columns.Add("FID")
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

  Class JobQAAttachedFilesPt
    Private m_Bug_Id As String = "Bug_Id"
    Public ReadOnly Property Bug_Id() As System.String 
    Get
        Return m_Bug_Id
    End Get
    End Property

    Private m_Version_Id As String = "Version_Id"
    Public ReadOnly Property Version_Id() As System.String 
    Get
        Return m_Version_Id
    End Get
    End Property

    Private m_Sort_Value As String = "Sort_Value"
    Public ReadOnly Property Sort_Value() As System.String 
    Get
        Return m_Sort_Value
    End Get
    End Property

    Private m_File_Name As String = "File_Name"
    Public ReadOnly Property File_Name() As System.String 
    Get
        Return m_File_Name
    End Get
    End Property

    Private m_FID As String = "FID"
    Public ReadOnly Property FID() As System.String 
    Get
        Return m_FID
    End Get
    End Property

  End Class
  Class DBColumnName 
    Private Shared ReadOnly m_Bug_Id As String = "Bug_Id"
    Public Shared ReadOnly Property Bug_Id() As System.String 
    Get
        Return m_Bug_Id
    End Get
    End Property

    Private Shared ReadOnly m_Version_Id As String = "Version_Id"
    Public Shared ReadOnly Property Version_Id() As System.String 
    Get
        Return m_Version_Id
    End Get
    End Property

    Private Shared ReadOnly m_Sort_Value As String = "Sort_Value"
    Public Shared ReadOnly Property Sort_Value() As System.String 
    Get
        Return m_Sort_Value
    End Get
    End Property

    Private Shared ReadOnly m_File_Name As String = "File_Name"
    Public Shared ReadOnly Property File_Name() As System.String 
    Get
        Return m_File_Name
    End Get
    End Property

    Private Shared ReadOnly m_FID As String = "FID"
    Public Shared ReadOnly Property FID() As System.String 
    Get
        Return m_FID
    End Get
    End Property

  End Class

End Class
