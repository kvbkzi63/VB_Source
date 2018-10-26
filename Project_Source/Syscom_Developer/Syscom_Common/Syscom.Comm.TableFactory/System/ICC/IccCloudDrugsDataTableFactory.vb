Imports System.Data.SqlClient
Public Class IccCloudDrugsDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2015/11/11 下午 05:55:50
    Public Shared ReadOnly tableName As String = "ICC_Cloud_Drugs"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "ID_No", "Drug_No", "Source", "Icd_Code", "Icd_Name", _
             "ATC5_Code", "ATC5_Name", "Element_Code", "Element_Name", "Insu_Code", _
             "Drug_Name", "Spec_Qty", "Spec_Qty_Unit", "Dosage_Method", "Medical_Date", _
             "Chronic_Receive_Date", "Dosage", "Days", "Left_Days", "Download_Time", _
             "Chart_No"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.Int32", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.Decimal", "System.String", "System.String", "System.DateTime", _
             "System.DateTime", "System.Decimal", "System.Decimal", "System.Decimal", "System.DateTime", _
             "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, -1, 8, 10, 600, _
             7, 600, 10, 320, 10, _
             120, -1, 320, 360, -1, _
             -1, -1, -1, -1, -1, _
             10}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub example()
        Dim dataSet As DataSet = New DataSet
        Dim dataTable As DataTable = IccCloudDrugsDataTableFactory.getDataTableWithSchema
        Dim dataRow As DataRow = dataTable.NewRow()
        '使用自己的資料來源取代 New Object 
        dataRow("ID_No") = New Object
        dataRow("Drug_No") = New Object
        dataRow("Source") = New Object
        dataRow("Icd_Code") = New Object
        dataRow("Icd_Name") = New Object
        dataRow("ATC5_Code") = New Object
        dataRow("ATC5_Name") = New Object
        dataRow("Element_Code") = New Object
        dataRow("Element_Name") = New Object
        dataRow("Insu_Code") = New Object
        dataRow("Drug_Name") = New Object
        dataRow("Spec_Qty") = New Object
        dataRow("Spec_Qty_Unit") = New Object
        dataRow("Dosage_Method") = New Object
        dataRow("Medical_Date") = New Object
        dataRow("Chronic_Receive_Date") = New Object
        dataRow("Dosage") = New Object
        dataRow("Days") = New Object
        dataRow("Left_Days") = New Object
        dataRow("Download_Time") = New Object
        dataRow("Chart_No") = New Object
        dataTable.Rows.Add(dataRow)
        dataSet.Tables.Add(dataTable)
    End Sub

    ''' <summary>
    '''取得資料庫表格的 DataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function getDataTable() As DataTable
        Try
            Dim dt As DataTable = New DataTable(tableName)
            dt.Columns.Add("ID_No")
            dt.Columns.Add("Drug_No")
            dt.Columns.Add("Source")
            dt.Columns.Add("Icd_Code")
            dt.Columns.Add("Icd_Name")
            dt.Columns.Add("ATC5_Code")
            dt.Columns.Add("ATC5_Name")
            dt.Columns.Add("Element_Code")
            dt.Columns.Add("Element_Name")
            dt.Columns.Add("Insu_Code")
            dt.Columns.Add("Drug_Name")
            dt.Columns.Add("Spec_Qty")
            dt.Columns.Add("Spec_Qty_Unit")
            dt.Columns.Add("Dosage_Method")
            dt.Columns.Add("Medical_Date")
            dt.Columns.Add("Chronic_Receive_Date")
            dt.Columns.Add("Dosage")
            dt.Columns.Add("Days")
            dt.Columns.Add("Left_Days")
            dt.Columns.Add("Download_Time")
            dt.Columns.Add("Chart_No")
            Dim pkColArray(1) As DataColumn
            pkColArray(0) = dt.Columns("ID_No")
            pkColArray(1) = dt.Columns("Drug_No")
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
            dt.Columns.Add("ID_No")
            dt.Columns("ID_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Drug_No")
            dt.Columns("Drug_No").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Source")
            dt.Columns("Source").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Icd_Code")
            dt.Columns("Icd_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Icd_Name")
            dt.Columns("Icd_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ATC5_Code")
            dt.Columns("ATC5_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ATC5_Name")
            dt.Columns("ATC5_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Element_Code")
            dt.Columns("Element_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Element_Name")
            dt.Columns("Element_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Code")
            dt.Columns("Insu_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Drug_Name")
            dt.Columns("Drug_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Spec_Qty")
            dt.Columns("Spec_Qty").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Spec_Qty_Unit")
            dt.Columns("Spec_Qty_Unit").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dosage_Method")
            dt.Columns("Dosage_Method").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Medical_Date")
            dt.Columns("Medical_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Chronic_Receive_Date")
            dt.Columns("Chronic_Receive_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Dosage")
            dt.Columns("Dosage").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Days")
            dt.Columns("Days").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Left_Days")
            dt.Columns("Left_Days").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Download_Time")
            dt.Columns("Download_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Chart_No")
            dt.Columns("Chart_No").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn
            pkColArray(0) = dt.Columns("ID_No")
            pkColArray(1) = dt.Columns("Drug_No")
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
            dt.Columns.Add("ID_No")
            dt.Columns.Add("Drug_No")
            dt.Columns.Add("Source")
            dt.Columns.Add("Icd_Code")
            dt.Columns.Add("Icd_Name")
            dt.Columns.Add("ATC5_Code")
            dt.Columns.Add("ATC5_Name")
            dt.Columns.Add("Element_Code")
            dt.Columns.Add("Element_Name")
            dt.Columns.Add("Insu_Code")
            dt.Columns.Add("Drug_Name")
            dt.Columns.Add("Spec_Qty")
            dt.Columns.Add("Spec_Qty_Unit")
            dt.Columns.Add("Dosage_Method")
            dt.Columns.Add("Medical_Date")
            dt.Columns.Add("Chronic_Receive_Date")
            dt.Columns.Add("Dosage")
            dt.Columns.Add("Days")
            dt.Columns.Add("Left_Days")
            dt.Columns.Add("Download_Time")
            dt.Columns.Add("Chart_No")
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

    Class ICCCloudDrugsPt
        Private m_ID_No As String = "ID_No"
        Public ReadOnly Property ID_No() As System.String
            Get
                Return m_ID_No
            End Get
        End Property

        Private m_Drug_No As String = "Drug_No"
        Public ReadOnly Property Drug_No() As System.String
            Get
                Return m_Drug_No
            End Get
        End Property

        Private m_Source As String = "Source"
        Public ReadOnly Property Source() As System.String
            Get
                Return m_Source
            End Get
        End Property

        Private m_Icd_Code As String = "Icd_Code"
        Public ReadOnly Property Icd_Code() As System.String
            Get
                Return m_Icd_Code
            End Get
        End Property

        Private m_Icd_Name As String = "Icd_Name"
        Public ReadOnly Property Icd_Name() As System.String
            Get
                Return m_Icd_Name
            End Get
        End Property

        Private m_ATC5_Code As String = "ATC5_Code"
        Public ReadOnly Property ATC5_Code() As System.String
            Get
                Return m_ATC5_Code
            End Get
        End Property

        Private m_ATC5_Name As String = "ATC5_Name"
        Public ReadOnly Property ATC5_Name() As System.String
            Get
                Return m_ATC5_Name
            End Get
        End Property

        Private m_Element_Code As String = "Element_Code"
        Public ReadOnly Property Element_Code() As System.String
            Get
                Return m_Element_Code
            End Get
        End Property

        Private m_Element_Name As String = "Element_Name"
        Public ReadOnly Property Element_Name() As System.String
            Get
                Return m_Element_Name
            End Get
        End Property

        Private m_Insu_Code As String = "Insu_Code"
        Public ReadOnly Property Insu_Code() As System.String
            Get
                Return m_Insu_Code
            End Get
        End Property

        Private m_Drug_Name As String = "Drug_Name"
        Public ReadOnly Property Drug_Name() As System.String
            Get
                Return m_Drug_Name
            End Get
        End Property

        Private m_Spec_Qty As String = "Spec_Qty"
        Public ReadOnly Property Spec_Qty() As System.String
            Get
                Return m_Spec_Qty
            End Get
        End Property

        Private m_Spec_Qty_Unit As String = "Spec_Qty_Unit"
        Public ReadOnly Property Spec_Qty_Unit() As System.String
            Get
                Return m_Spec_Qty_Unit
            End Get
        End Property

        Private m_Dosage_Method As String = "Dosage_Method"
        Public ReadOnly Property Dosage_Method() As System.String
            Get
                Return m_Dosage_Method
            End Get
        End Property

        Private m_Medical_Date As String = "Medical_Date"
        Public ReadOnly Property Medical_Date() As System.String
            Get
                Return m_Medical_Date
            End Get
        End Property

        Private m_Chronic_Receive_Date As String = "Chronic_Receive_Date"
        Public ReadOnly Property Chronic_Receive_Date() As System.String
            Get
                Return m_Chronic_Receive_Date
            End Get
        End Property

        Private m_Dosage As String = "Dosage"
        Public ReadOnly Property Dosage() As System.String
            Get
                Return m_Dosage
            End Get
        End Property

        Private m_Days As String = "Days"
        Public ReadOnly Property Days() As System.String
            Get
                Return m_Days
            End Get
        End Property

        Private m_Left_Days As String = "Left_Days"
        Public ReadOnly Property Left_Days() As System.String
            Get
                Return m_Left_Days
            End Get
        End Property

        Private m_Download_Time As String = "Download_Time"
        Public ReadOnly Property Download_Time() As System.String
            Get
                Return m_Download_Time
            End Get
        End Property

        Private m_Chart_No As String = "Chart_No"
        Public ReadOnly Property Chart_No() As System.String
            Get
                Return m_Chart_No
            End Get
        End Property

    End Class

End Class
