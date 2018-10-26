Imports System.Data.SqlClient
Public Class ArmRecordDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/7/5 上午 10:36:13
    Public Shared ReadOnly tableName as String="ARM_Record"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Rec_User", "Rec_DateTime", "Sub_System_No", "fun_function_no", "Fun_Function_Name"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.DateTime", "System.String", "System.String", "System.String"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, -1, 10, 40, 60  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = ArmRecordDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Rec_User") = New Object
        dataRow("Rec_DateTime") = New Object
        dataRow("Sub_System_No") = New Object
        dataRow("fun_function_no") = New Object
        dataRow("Fun_Function_Name") = New Object
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
            dt.Columns.Add("Rec_User")
            dt.Columns.Add("Rec_DateTime")
            dt.Columns.Add("Sub_System_No")
            dt.Columns.Add("fun_function_no")
            dt.Columns.Add("Fun_Function_Name")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Rec_User")
            pkColArray(1) = dt.Columns("Rec_DateTime")
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
            dt.Columns.Add("Rec_User")
            dt.Columns("Rec_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Rec_DateTime")
            dt.Columns("Rec_DateTime").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Sub_System_No")
            dt.Columns("Sub_System_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("fun_function_no")
            dt.Columns("fun_function_no").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Fun_Function_Name")
            dt.Columns("Fun_Function_Name").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Rec_User")
            pkColArray(1) = dt.Columns("Rec_DateTime")
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
            dt.Columns.Add("Rec_User")
            dt.Columns.Add("Rec_DateTime")
            dt.Columns.Add("Sub_System_No")
            dt.Columns.Add("fun_function_no")
            dt.Columns.Add("Fun_Function_Name")
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

  Class ARMRecordPt
    Private m_Rec_User As String = "Rec_User"
    Public ReadOnly Property Rec_User() As System.String 
    Get
        Return m_Rec_User
    End Get
    End Property

    Private m_Rec_DateTime As String = "Rec_DateTime"
    Public ReadOnly Property Rec_DateTime() As System.String 
    Get
        Return m_Rec_DateTime
    End Get
    End Property

    Private m_Sub_System_No As String = "Sub_System_No"
    Public ReadOnly Property Sub_System_No() As System.String 
    Get
        Return m_Sub_System_No
    End Get
    End Property

    Private m_fun_function_no As String = "fun_function_no"
    Public ReadOnly Property fun_function_no() As System.String 
    Get
        Return m_fun_function_no
    End Get
    End Property

    Private m_Fun_Function_Name As String = "Fun_Function_Name"
    Public ReadOnly Property Fun_Function_Name() As System.String 
    Get
        Return m_Fun_Function_Name
    End Get
    End Property

  End Class

End Class
