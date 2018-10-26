Imports System.Data.SqlClient
Public Class ArmProfileDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/7/5 上午 10:36:13
    Public Shared ReadOnly tableName as String="ARM_ProFile"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "System_No", "Employee_Code", "Sub_File_Name", "Sub_Xml", "Is_Default"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 10, 50, 1073741823, 1  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = ArmProfileDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("System_No") = New Object
        dataRow("Employee_Code") = New Object
        dataRow("Sub_File_Name") = New Object
        dataRow("Sub_Xml") = New Object
        dataRow("Is_Default") = New Object
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
            dt.Columns.Add("System_No")
            dt.Columns.Add("Employee_Code")
            dt.Columns.Add("Sub_File_Name")
            dt.Columns.Add("Sub_Xml")
            dt.Columns.Add("Is_Default")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("System_No")
            pkColArray(1) = dt.Columns("Employee_Code")
            pkColArray(2) = dt.Columns("Sub_File_Name")
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
            dt.Columns.Add("System_No")
            dt.Columns("System_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Employee_Code")
            dt.Columns("Employee_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sub_File_Name")
            dt.Columns("Sub_File_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sub_Xml")
            dt.Columns("Sub_Xml").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Default")
            dt.Columns("Is_Default").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("System_No")
            pkColArray(1) = dt.Columns("Employee_Code")
            pkColArray(2) = dt.Columns("Sub_File_Name")
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
            dt.Columns.Add("System_No")
            dt.Columns.Add("Employee_Code")
            dt.Columns.Add("Sub_File_Name")
            dt.Columns.Add("Sub_Xml")
            dt.Columns.Add("Is_Default")
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

  Class ARMProFilePt
    Private m_System_No As String = "System_No"
    Public ReadOnly Property System_No() As System.String 
    Get
        Return m_System_No
    End Get
    End Property

    Private m_Employee_Code As String = "Employee_Code"
    Public ReadOnly Property Employee_Code() As System.String 
    Get
        Return m_Employee_Code
    End Get
    End Property

    Private m_Sub_File_Name As String = "Sub_File_Name"
    Public ReadOnly Property Sub_File_Name() As System.String 
    Get
        Return m_Sub_File_Name
    End Get
    End Property

    Private m_Sub_Xml As String = "Sub_Xml"
    Public ReadOnly Property Sub_Xml() As System.String 
    Get
        Return m_Sub_Xml
    End Get
    End Property

    Private m_Is_Default As String = "Is_Default"
    Public ReadOnly Property Is_Default() As System.String 
    Get
        Return m_Is_Default
    End Get
    End Property

  End Class

End Class
