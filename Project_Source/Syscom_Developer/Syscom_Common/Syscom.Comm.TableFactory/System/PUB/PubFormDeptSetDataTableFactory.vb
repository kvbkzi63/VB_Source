Imports System.Data.SqlClient
Public Class PubFormDeptSetDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:49
    Public Shared ReadOnly tableName as String="PUB_Form_Dept_Set"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Dept_Code", "Form_Type_Id", "Form_Code", "Form_Sort_Value"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.Int32"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             6, 5, 10, -1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubFormDeptSetDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Dept_Code") = New Object
        dataRow("Form_Type_Id") = New Object
        dataRow("Form_Code") = New Object
        dataRow("Form_Sort_Value") = New Object
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
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Form_Type_Id")
            dt.Columns.Add("Form_Code")
            dt.Columns.Add("Form_Sort_Value")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Dept_Code")
            pkColArray(1) = dt.Columns("Form_Type_Id")
            pkColArray(2) = dt.Columns("Form_Code")
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
            dt.Columns.Add("Dept_Code")
            dt.Columns("Dept_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Form_Type_Id")
            dt.Columns("Form_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Form_Code")
            dt.Columns("Form_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Form_Sort_Value")
            dt.Columns("Form_Sort_Value").DataType = System.Type.GetType("System.Int32")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Dept_Code")
            pkColArray(1) = dt.Columns("Form_Type_Id")
            pkColArray(2) = dt.Columns("Form_Code")
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
            dt.Columns.Add("Dept_Code")
            dt.Columns.Add("Form_Type_Id")
            dt.Columns.Add("Form_Code")
            dt.Columns.Add("Form_Sort_Value")
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

  Class PUBFormDeptSetPt
    Private m_Dept_Code As String = "Dept_Code"
    Public ReadOnly Property Dept_Code() As System.String 
    Get
        Return m_Dept_Code
    End Get
    End Property

    Private m_Form_Type_Id As String = "Form_Type_Id"
    Public ReadOnly Property Form_Type_Id() As System.String 
    Get
        Return m_Form_Type_Id
    End Get
    End Property

    Private m_Form_Code As String = "Form_Code"
    Public ReadOnly Property Form_Code() As System.String 
    Get
        Return m_Form_Code
    End Get
    End Property

    Private m_Form_Sort_Value As String = "Form_Sort_Value"
    Public ReadOnly Property Form_Sort_Value() As System.String 
    Get
        Return m_Form_Sort_Value
    End Get
    End Property

  End Class

End Class
