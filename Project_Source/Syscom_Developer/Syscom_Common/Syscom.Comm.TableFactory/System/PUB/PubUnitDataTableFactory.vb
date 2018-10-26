Imports System.Data.SqlClient
Public Class PubUnitDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/7/24 上午 07:48:54
    Public Shared ReadOnly tableName as String="PUB_Unit"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Unit_Code", "Unit_En_Name", "Unit_Name", "System_Name", "Transfer_Factor1",   _
             "Transfer_Factor_Unit1", "Transfer_Factor2", "Transfer_Factor_Unit2", "Transfer_Factor3", "Transfer_Factor_Unit3",   _
             "Transfer_Factor4", "Transfer_Factor_Unit4", "Transfer_Factor5", "Transfer_Factor_Unit5"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.Decimal",   _
             "System.String", "System.Decimal", "System.String", "System.Decimal", "System.String",   _
             "System.Decimal", "System.String", "System.Decimal", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             8, 50, 50, 10, -1,   _
             8, -1, 8, -1, 8,   _
             -1, 8, -1, 8}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubUnitDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Unit_Code") = New Object
        dataRow("Unit_En_Name") = New Object
        dataRow("Unit_Name") = New Object
        dataRow("System_Name") = New Object
        dataRow("Transfer_Factor1") = New Object
        dataRow("Transfer_Factor_Unit1") = New Object
        dataRow("Transfer_Factor2") = New Object
        dataRow("Transfer_Factor_Unit2") = New Object
        dataRow("Transfer_Factor3") = New Object
        dataRow("Transfer_Factor_Unit3") = New Object
        dataRow("Transfer_Factor4") = New Object
        dataRow("Transfer_Factor_Unit4") = New Object
        dataRow("Transfer_Factor5") = New Object
        dataRow("Transfer_Factor_Unit5") = New Object
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
            dt.Columns.Add("Unit_Code")
            dt.Columns.Add("Unit_En_Name")
            dt.Columns.Add("Unit_Name")
            dt.Columns.Add("System_Name")
            dt.Columns.Add("Transfer_Factor1")
            dt.Columns.Add("Transfer_Factor_Unit1")
            dt.Columns.Add("Transfer_Factor2")
            dt.Columns.Add("Transfer_Factor_Unit2")
            dt.Columns.Add("Transfer_Factor3")
            dt.Columns.Add("Transfer_Factor_Unit3")
            dt.Columns.Add("Transfer_Factor4")
            dt.Columns.Add("Transfer_Factor_Unit4")
            dt.Columns.Add("Transfer_Factor5")
            dt.Columns.Add("Transfer_Factor_Unit5")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Unit_Code")
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
            dt.Columns.Add("Unit_Code")
            dt.Columns("Unit_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Unit_En_Name")
            dt.Columns("Unit_En_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Unit_Name")
            dt.Columns("Unit_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("System_Name")
            dt.Columns("System_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Transfer_Factor1")
            dt.Columns("Transfer_Factor1").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Transfer_Factor_Unit1")
            dt.Columns("Transfer_Factor_Unit1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Transfer_Factor2")
            dt.Columns("Transfer_Factor2").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Transfer_Factor_Unit2")
            dt.Columns("Transfer_Factor_Unit2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Transfer_Factor3")
            dt.Columns("Transfer_Factor3").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Transfer_Factor_Unit3")
            dt.Columns("Transfer_Factor_Unit3").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Transfer_Factor4")
            dt.Columns("Transfer_Factor4").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Transfer_Factor_Unit4")
            dt.Columns("Transfer_Factor_Unit4").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Transfer_Factor5")
            dt.Columns("Transfer_Factor5").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Transfer_Factor_Unit5")
            dt.Columns("Transfer_Factor_Unit5").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Unit_Code")
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
            dt.Columns.Add("Unit_Code")
            dt.Columns.Add("Unit_En_Name")
            dt.Columns.Add("Unit_Name")
            dt.Columns.Add("System_Name")
            dt.Columns.Add("Transfer_Factor1")
            dt.Columns.Add("Transfer_Factor_Unit1")
            dt.Columns.Add("Transfer_Factor2")
            dt.Columns.Add("Transfer_Factor_Unit2")
            dt.Columns.Add("Transfer_Factor3")
            dt.Columns.Add("Transfer_Factor_Unit3")
            dt.Columns.Add("Transfer_Factor4")
            dt.Columns.Add("Transfer_Factor_Unit4")
            dt.Columns.Add("Transfer_Factor5")
            dt.Columns.Add("Transfer_Factor_Unit5")
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

  Class PUBUnitPt
    Private m_Unit_Code As String = "Unit_Code"
    Public ReadOnly Property Unit_Code() As System.String 
    Get
        Return m_Unit_Code
    End Get
    End Property

    Private m_Unit_En_Name As String = "Unit_En_Name"
    Public ReadOnly Property Unit_En_Name() As System.String 
    Get
        Return m_Unit_En_Name
    End Get
    End Property

    Private m_Unit_Name As String = "Unit_Name"
    Public ReadOnly Property Unit_Name() As System.String 
    Get
        Return m_Unit_Name
    End Get
    End Property

    Private m_System_Name As String = "System_Name"
    Public ReadOnly Property System_Name() As System.String 
    Get
        Return m_System_Name
    End Get
    End Property

    Private m_Transfer_Factor1 As String = "Transfer_Factor1"
    Public ReadOnly Property Transfer_Factor1() As System.String 
    Get
        Return m_Transfer_Factor1
    End Get
    End Property

    Private m_Transfer_Factor_Unit1 As String = "Transfer_Factor_Unit1"
    Public ReadOnly Property Transfer_Factor_Unit1() As System.String 
    Get
        Return m_Transfer_Factor_Unit1
    End Get
    End Property

    Private m_Transfer_Factor2 As String = "Transfer_Factor2"
    Public ReadOnly Property Transfer_Factor2() As System.String 
    Get
        Return m_Transfer_Factor2
    End Get
    End Property

    Private m_Transfer_Factor_Unit2 As String = "Transfer_Factor_Unit2"
    Public ReadOnly Property Transfer_Factor_Unit2() As System.String 
    Get
        Return m_Transfer_Factor_Unit2
    End Get
    End Property

    Private m_Transfer_Factor3 As String = "Transfer_Factor3"
    Public ReadOnly Property Transfer_Factor3() As System.String 
    Get
        Return m_Transfer_Factor3
    End Get
    End Property

    Private m_Transfer_Factor_Unit3 As String = "Transfer_Factor_Unit3"
    Public ReadOnly Property Transfer_Factor_Unit3() As System.String 
    Get
        Return m_Transfer_Factor_Unit3
    End Get
    End Property

    Private m_Transfer_Factor4 As String = "Transfer_Factor4"
    Public ReadOnly Property Transfer_Factor4() As System.String 
    Get
        Return m_Transfer_Factor4
    End Get
    End Property

    Private m_Transfer_Factor_Unit4 As String = "Transfer_Factor_Unit4"
    Public ReadOnly Property Transfer_Factor_Unit4() As System.String 
    Get
        Return m_Transfer_Factor_Unit4
    End Get
    End Property

    Private m_Transfer_Factor5 As String = "Transfer_Factor5"
    Public ReadOnly Property Transfer_Factor5() As System.String 
    Get
        Return m_Transfer_Factor5
    End Get
    End Property

    Private m_Transfer_Factor_Unit5 As String = "Transfer_Factor_Unit5"
    Public ReadOnly Property Transfer_Factor_Unit5() As System.String 
    Get
        Return m_Transfer_Factor_Unit5
    End Get
    End Property

  End Class

End Class
