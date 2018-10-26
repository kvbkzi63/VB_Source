Imports System.Data.SqlClient
Public Class PubPrintConfigDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:53
    Public Shared ReadOnly tableName as String="PUB_Print_Config"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Report_Id", "Print_Type", "Print_Cond", "Printer_Name", "Paper_Size"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             13, 1, 30, 50, 1  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubPrintConfigDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Report_Id") = New Object
        dataRow("Print_Type") = New Object
        dataRow("Print_Cond") = New Object
        dataRow("Printer_Name") = New Object
        dataRow("Paper_Size") = New Object
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
            dt.Columns.Add("Report_Id")
            dt.Columns.Add("Print_Type")
            dt.Columns.Add("Print_Cond")
            dt.Columns.Add("Printer_Name")
            dt.Columns.Add("Paper_Size")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Report_Id")
            pkColArray(1) = dt.Columns("Print_Type")
            pkColArray(2) = dt.Columns("Print_Cond")
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
            dt.Columns.Add("Report_Id")
            dt.Columns("Report_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Print_Type")
            dt.Columns("Print_Type").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Print_Cond")
            dt.Columns("Print_Cond").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Printer_Name")
            dt.Columns("Printer_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Paper_Size")
            dt.Columns("Paper_Size").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Report_Id")
            pkColArray(1) = dt.Columns("Print_Type")
            pkColArray(2) = dt.Columns("Print_Cond")
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
            dt.Columns.Add("Report_Id")
            dt.Columns.Add("Print_Type")
            dt.Columns.Add("Print_Cond")
            dt.Columns.Add("Printer_Name")
            dt.Columns.Add("Paper_Size")
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

  Class PUBPrintConfigPt
    Private m_Report_Id As String = "Report_Id"
    Public ReadOnly Property Report_Id() As System.String 
    Get
        Return m_Report_Id
    End Get
    End Property

    Private m_Print_Type As String = "Print_Type"
    Public ReadOnly Property Print_Type() As System.String 
    Get
        Return m_Print_Type
    End Get
    End Property

    Private m_Print_Cond As String = "Print_Cond"
    Public ReadOnly Property Print_Cond() As System.String 
    Get
        Return m_Print_Cond
    End Get
    End Property

    Private m_Printer_Name As String = "Printer_Name"
    Public ReadOnly Property Printer_Name() As System.String 
    Get
        Return m_Printer_Name
    End Get
    End Property

    Private m_Paper_Size As String = "Paper_Size"
    Public ReadOnly Property Paper_Size() As System.String 
    Get
        Return m_Paper_Size
    End Get
    End Property

  End Class

End Class
