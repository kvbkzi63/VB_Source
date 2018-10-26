Imports System.Data.SqlClient
Public Class PubOrderMappingSpecimenDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:51
    Public Shared ReadOnly tableName as String="PUB_Order_Mapping_Specimen"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Order_Code", "Specimen_Id", "Vessel_Id", "Is_Default", "Specimen_Sort_Value",   _
             "Control_Value", "Time_Control_Id", "Is_Default_Vessel"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.Int32",   _
             "System.Int32", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             20, 5, 5, 1, -1,   _
             -1, 5, 1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubOrderMappingSpecimenDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Order_Code") = New Object
        dataRow("Specimen_Id") = New Object
        dataRow("Vessel_Id") = New Object
        dataRow("Is_Default") = New Object
        dataRow("Specimen_Sort_Value") = New Object
        dataRow("Control_Value") = New Object
        dataRow("Time_Control_Id") = New Object
        dataRow("Is_Default_Vessel") = New Object
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
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Specimen_Id")
            dt.Columns.Add("Vessel_Id")
            dt.Columns.Add("Is_Default")
            dt.Columns.Add("Specimen_Sort_Value")
            dt.Columns.Add("Control_Value")
            dt.Columns.Add("Time_Control_Id")
            dt.Columns.Add("Is_Default_Vessel")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Order_Code")
            pkColArray(1) = dt.Columns("Specimen_Id")
            pkColArray(2) = dt.Columns("Vessel_Id")
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
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Specimen_Id")
            dt.Columns("Specimen_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Vessel_Id")
            dt.Columns("Vessel_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Default")
            dt.Columns("Is_Default").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Specimen_Sort_Value")
            dt.Columns("Specimen_Sort_Value").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Control_Value")
            dt.Columns("Control_Value").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Time_Control_Id")
            dt.Columns("Time_Control_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Default_Vessel")
            dt.Columns("Is_Default_Vessel").DataType = System.Type.GetType("System.String")
            Dim pkColArray(2) As DataColumn 
            pkColArray(0) = dt.Columns("Order_Code")
            pkColArray(1) = dt.Columns("Specimen_Id")
            pkColArray(2) = dt.Columns("Vessel_Id")
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
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Specimen_Id")
            dt.Columns.Add("Vessel_Id")
            dt.Columns.Add("Is_Default")
            dt.Columns.Add("Specimen_Sort_Value")
            dt.Columns.Add("Control_Value")
            dt.Columns.Add("Time_Control_Id")
            dt.Columns.Add("Is_Default_Vessel")
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

  Class PUBOrderMappingSpecimenPt
    Private m_Order_Code As String = "Order_Code"
    Public ReadOnly Property Order_Code() As System.String 
    Get
        Return m_Order_Code
    End Get
    End Property

    Private m_Specimen_Id As String = "Specimen_Id"
    Public ReadOnly Property Specimen_Id() As System.String 
    Get
        Return m_Specimen_Id
    End Get
    End Property

    Private m_Vessel_Id As String = "Vessel_Id"
    Public ReadOnly Property Vessel_Id() As System.String 
    Get
        Return m_Vessel_Id
    End Get
    End Property

    Private m_Is_Default As String = "Is_Default"
    Public ReadOnly Property Is_Default() As System.String 
    Get
        Return m_Is_Default
    End Get
    End Property

    Private m_Specimen_Sort_Value As String = "Specimen_Sort_Value"
    Public ReadOnly Property Specimen_Sort_Value() As System.String 
    Get
        Return m_Specimen_Sort_Value
    End Get
    End Property

    Private m_Control_Value As String = "Control_Value"
    Public ReadOnly Property Control_Value() As System.String 
    Get
        Return m_Control_Value
    End Get
    End Property

    Private m_Time_Control_Id As String = "Time_Control_Id"
    Public ReadOnly Property Time_Control_Id() As System.String 
    Get
        Return m_Time_Control_Id
    End Get
    End Property

    Private m_Is_Default_Vessel As String = "Is_Default_Vessel"
    Public ReadOnly Property Is_Default_Vessel() As System.String 
    Get
        Return m_Is_Default_Vessel
    End Get
    End Property

  End Class

End Class
