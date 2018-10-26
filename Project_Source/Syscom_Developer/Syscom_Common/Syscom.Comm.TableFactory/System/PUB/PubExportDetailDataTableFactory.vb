Imports System.Data.SqlClient
Public Class PubExportDetailDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/12/6 上午 08:41:14
    Public Shared ReadOnly tableName as String="PUB_Export_Detail"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Report_Id", "Sort_No", "Field_Name", "Field_Code", "Field_Description",   _
             "Form_Control_Type", "Is_Nreq", "Field_Nreq_Cond", "Field_Nreq_Code", "Default_Value",   _
             "Cbo_Source_Data"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Decimal", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             50, -1, 20, 20, 50,   _
             20, 1, 300, 300, 30,   _
             2147483647}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubExportDetailDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Report_Id") = New Object
        dataRow("Sort_No") = New Object
        dataRow("Field_Name") = New Object
        dataRow("Field_Code") = New Object
        dataRow("Field_Description") = New Object
        dataRow("Form_Control_Type") = New Object
        dataRow("Is_Nreq") = New Object
        dataRow("Field_Nreq_Cond") = New Object
        dataRow("Field_Nreq_Code") = New Object
        dataRow("Default_Value") = New Object
        dataRow("Cbo_Source_Data") = New Object
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
            dt.Columns.Add("Sort_No")
            dt.Columns.Add("Field_Name")
            dt.Columns.Add("Field_Code")
            dt.Columns.Add("Field_Description")
            dt.Columns.Add("Form_Control_Type")
            dt.Columns.Add("Is_Nreq")
            dt.Columns.Add("Field_Nreq_Cond")
            dt.Columns.Add("Field_Nreq_Code")
            dt.Columns.Add("Default_Value")
            dt.Columns.Add("Cbo_Source_Data")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Report_Id")
            pkColArray(1) = dt.Columns("Sort_No")
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
            dt.Columns.Add("Sort_No")
            dt.Columns("Sort_No").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Field_Name")
            dt.Columns("Field_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Field_Code")
            dt.Columns("Field_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Field_Description")
            dt.Columns("Field_Description").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Form_Control_Type")
            dt.Columns("Form_Control_Type").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Nreq")
            dt.Columns("Is_Nreq").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Field_Nreq_Cond")
            dt.Columns("Field_Nreq_Cond").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Field_Nreq_Code")
            dt.Columns("Field_Nreq_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Default_Value")
            dt.Columns("Default_Value").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cbo_Source_Data")
            dt.Columns("Cbo_Source_Data").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Report_Id")
            pkColArray(1) = dt.Columns("Sort_No")
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
            dt.Columns.Add("Sort_No")
            dt.Columns.Add("Field_Name")
            dt.Columns.Add("Field_Code")
            dt.Columns.Add("Field_Description")
            dt.Columns.Add("Form_Control_Type")
            dt.Columns.Add("Is_Nreq")
            dt.Columns.Add("Field_Nreq_Cond")
            dt.Columns.Add("Field_Nreq_Code")
            dt.Columns.Add("Default_Value")
            dt.Columns.Add("Cbo_Source_Data")
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

  Class PUBExportDetailPt
    Private m_Report_Id As String = "Report_Id"
    Public ReadOnly Property Report_Id() As System.String 
    Get
        Return m_Report_Id
    End Get
    End Property

    Private m_Sort_No As String = "Sort_No"
    Public ReadOnly Property Sort_No() As System.String 
    Get
        Return m_Sort_No
    End Get
    End Property

    Private m_Field_Name As String = "Field_Name"
    Public ReadOnly Property Field_Name() As System.String 
    Get
        Return m_Field_Name
    End Get
    End Property

    Private m_Field_Code As String = "Field_Code"
    Public ReadOnly Property Field_Code() As System.String 
    Get
        Return m_Field_Code
    End Get
    End Property

    Private m_Field_Description As String = "Field_Description"
    Public ReadOnly Property Field_Description() As System.String 
    Get
        Return m_Field_Description
    End Get
    End Property

    Private m_Form_Control_Type As String = "Form_Control_Type"
    Public ReadOnly Property Form_Control_Type() As System.String 
    Get
        Return m_Form_Control_Type
    End Get
    End Property

    Private m_Is_Nreq As String = "Is_Nreq"
    Public ReadOnly Property Is_Nreq() As System.String 
    Get
        Return m_Is_Nreq
    End Get
    End Property

    Private m_Field_Nreq_Cond As String = "Field_Nreq_Cond"
    Public ReadOnly Property Field_Nreq_Cond() As System.String 
    Get
        Return m_Field_Nreq_Cond
    End Get
    End Property

    Private m_Field_Nreq_Code As String = "Field_Nreq_Code"
    Public ReadOnly Property Field_Nreq_Code() As System.String 
    Get
        Return m_Field_Nreq_Code
    End Get
    End Property

    Private m_Default_Value As String = "Default_Value"
    Public ReadOnly Property Default_Value() As System.String 
    Get
        Return m_Default_Value
    End Get
    End Property

    Private m_Cbo_Source_Data As String = "Cbo_Source_Data"
    Public ReadOnly Property Cbo_Source_Data() As System.String 
    Get
        Return m_Cbo_Source_Data
    End Get
    End Property

  End Class
  Class DBColumnName 
    Private Shared ReadOnly m_Report_Id As String = "Report_Id"
    Public Shared ReadOnly Property Report_Id() As System.String 
    Get
        Return m_Report_Id
    End Get
    End Property

    Private Shared ReadOnly m_Sort_No As String = "Sort_No"
    Public Shared ReadOnly Property Sort_No() As System.String 
    Get
        Return m_Sort_No
    End Get
    End Property

    Private Shared ReadOnly m_Field_Name As String = "Field_Name"
    Public Shared ReadOnly Property Field_Name() As System.String 
    Get
        Return m_Field_Name
    End Get
    End Property

    Private Shared ReadOnly m_Field_Code As String = "Field_Code"
    Public Shared ReadOnly Property Field_Code() As System.String 
    Get
        Return m_Field_Code
    End Get
    End Property

    Private Shared ReadOnly m_Field_Description As String = "Field_Description"
    Public Shared ReadOnly Property Field_Description() As System.String 
    Get
        Return m_Field_Description
    End Get
    End Property

    Private Shared ReadOnly m_Form_Control_Type As String = "Form_Control_Type"
    Public Shared ReadOnly Property Form_Control_Type() As System.String 
    Get
        Return m_Form_Control_Type
    End Get
    End Property

    Private Shared ReadOnly m_Is_Nreq As String = "Is_Nreq"
    Public Shared ReadOnly Property Is_Nreq() As System.String 
    Get
        Return m_Is_Nreq
    End Get
    End Property

    Private Shared ReadOnly m_Field_Nreq_Cond As String = "Field_Nreq_Cond"
    Public Shared ReadOnly Property Field_Nreq_Cond() As System.String 
    Get
        Return m_Field_Nreq_Cond
    End Get
    End Property

    Private Shared ReadOnly m_Field_Nreq_Code As String = "Field_Nreq_Code"
    Public Shared ReadOnly Property Field_Nreq_Code() As System.String 
    Get
        Return m_Field_Nreq_Code
    End Get
    End Property

    Private Shared ReadOnly m_Default_Value As String = "Default_Value"
    Public Shared ReadOnly Property Default_Value() As System.String 
    Get
        Return m_Default_Value
    End Get
    End Property

    Private Shared ReadOnly m_Cbo_Source_Data As String = "Cbo_Source_Data"
    Public Shared ReadOnly Property Cbo_Source_Data() As System.String 
    Get
        Return m_Cbo_Source_Data
    End Get
    End Property

  End Class

End Class
