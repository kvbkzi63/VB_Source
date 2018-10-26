Imports System.Data.SqlClient
Public Class PubSheetDisplayDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/5/20 下午 02:20:27
    Public Shared ReadOnly tableName as String="PUB_Sheet_Display"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Sheet_Type_Id", "Sheet_Main_Display", "Sheet_Main_Display_Name", "Sheet_Sub_Display", "Sheet_Sub_Display_Name"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             5, 10, 30, 10, 30  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubSheetDisplayDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Sheet_Type_Id") = New Object
        dataRow("Sheet_Main_Display") = New Object
        dataRow("Sheet_Main_Display_Name") = New Object
        dataRow("Sheet_Sub_Display") = New Object
        dataRow("Sheet_Sub_Display_Name") = New Object
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
            dt.Columns.Add("Sheet_Type_Id")
            dt.Columns.Add("Sheet_Main_Display")
            dt.Columns.Add("Sheet_Main_Display_Name")
            dt.Columns.Add("Sheet_Sub_Display")
            dt.Columns.Add("Sheet_Sub_Display_Name")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Sheet_Type_Id")
            pkColArray(1) = dt.Columns("Sheet_Main_Display")
            pkColArray(2) = dt.Columns("Sheet_Sub_Display")
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
            dt.Columns.Add("Sheet_Type_Id")
            dt.Columns("Sheet_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sheet_Main_Display")
            dt.Columns("Sheet_Main_Display").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sheet_Main_Display_Name")
            dt.Columns("Sheet_Main_Display_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sheet_Sub_Display")
            dt.Columns("Sheet_Sub_Display").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Sheet_Sub_Display_Name")
            dt.Columns("Sheet_Sub_Display_Name").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Sheet_Type_Id")
            pkColArray(1) = dt.Columns("Sheet_Main_Display")
            pkColArray(2) = dt.Columns("Sheet_Sub_Display")
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
            dt.Columns.Add("Sheet_Type_Id")
            dt.Columns.Add("Sheet_Main_Display")
            dt.Columns.Add("Sheet_Main_Display_Name")
            dt.Columns.Add("Sheet_Sub_Display")
            dt.Columns.Add("Sheet_Sub_Display_Name")
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

  Class PUBSheetDisplayPt
    Private m_Sheet_Type_Id As String = "Sheet_Type_Id"
    Public ReadOnly Property Sheet_Type_Id() As System.String 
    Get
        Return m_Sheet_Type_Id
    End Get
    End Property

    Private m_Sheet_Main_Display As String = "Sheet_Main_Display"
    Public ReadOnly Property Sheet_Main_Display() As System.String 
    Get
        Return m_Sheet_Main_Display
    End Get
    End Property

    Private m_Sheet_Main_Display_Name As String = "Sheet_Main_Display_Name"
    Public ReadOnly Property Sheet_Main_Display_Name() As System.String 
    Get
        Return m_Sheet_Main_Display_Name
    End Get
    End Property

    Private m_Sheet_Sub_Display As String = "Sheet_Sub_Display"
    Public ReadOnly Property Sheet_Sub_Display() As System.String 
    Get
        Return m_Sheet_Sub_Display
    End Get
    End Property

    Private m_Sheet_Sub_Display_Name As String = "Sheet_Sub_Display_Name"
    Public ReadOnly Property Sheet_Sub_Display_Name() As System.String 
    Get
        Return m_Sheet_Sub_Display_Name
    End Get
    End Property

  End Class

End Class
