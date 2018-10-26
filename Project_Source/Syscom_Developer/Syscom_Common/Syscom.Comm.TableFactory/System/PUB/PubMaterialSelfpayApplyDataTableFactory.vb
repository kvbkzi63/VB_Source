Imports System.Data.SqlClient
Public Class PubMaterialSelfpayApplyDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2016/10/21 上午 10:17:56
    Public Shared ReadOnly tableName as String="PUB_Material_Selfpay_Apply"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Order_Code", "Effect_Date", "End_Date", "Self_Insu_Code", "Apply_Status_Id",   _
             "Equipment_License", "Equipment_License_No", "Product_Features", "Use_Reason", "Precautions",   _
             "Side_Effect", "Efficacy_Comparison", "Insu_Order_Type_Id", "Is_Alter", "Alternative_Insu_Code_1",   _
             "Alternative_Insu_Code_2", "Alternative_Insu_Code_3", "Alternative_Insu_Code_4", "Alternative_Insu_Code_5", "Alternative_Insu_Code_6",   _
             "Alternative_Insu_Code_7", "Alternative_Insu_Code_8", "Alternative_Insu_Code_9", "Alternative_Insu_Code_10", "Is_Agreement_Print",   _
             "Is_Instruction_Print", "Create_User", "Create_Time", "Modified_User", "Modified_Time"  _
             }
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.DateTime", "System.DateTime", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.DateTime", "System.String", "System.DateTime"  _
             }
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             20, -1, -1, 20, 5,   _
             50, 20, 4000, 4000, 4000,   _
             4000, 4000, 1, 1, 20,   _
             20, 20, 20, 20, 20,   _
             20, 20, 20, 20, 1,   _
             1, 10, -1, 10, -1  _
             }

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubMaterialSelfpayApplyDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Order_Code") = New Object
        dataRow("Effect_Date") = New Object
        dataRow("End_Date") = New Object
        dataRow("Self_Insu_Code") = New Object
        dataRow("Apply_Status_Id") = New Object
        dataRow("Equipment_License") = New Object
        dataRow("Equipment_License_No") = New Object
        dataRow("Product_Features") = New Object
        dataRow("Use_Reason") = New Object
        dataRow("Precautions") = New Object
        dataRow("Side_Effect") = New Object
        dataRow("Efficacy_Comparison") = New Object
        dataRow("Insu_Order_Type_Id") = New Object
        dataRow("Is_Alter") = New Object
        dataRow("Alternative_Insu_Code_1") = New Object
        dataRow("Alternative_Insu_Code_2") = New Object
        dataRow("Alternative_Insu_Code_3") = New Object
        dataRow("Alternative_Insu_Code_4") = New Object
        dataRow("Alternative_Insu_Code_5") = New Object
        dataRow("Alternative_Insu_Code_6") = New Object
        dataRow("Alternative_Insu_Code_7") = New Object
        dataRow("Alternative_Insu_Code_8") = New Object
        dataRow("Alternative_Insu_Code_9") = New Object
        dataRow("Alternative_Insu_Code_10") = New Object
        dataRow("Is_Agreement_Print") = New Object
        dataRow("Is_Instruction_Print") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
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
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Self_Insu_Code")
            dt.Columns.Add("Apply_Status_Id")
            dt.Columns.Add("Equipment_License")
            dt.Columns.Add("Equipment_License_No")
            dt.Columns.Add("Product_Features")
            dt.Columns.Add("Use_Reason")
            dt.Columns.Add("Precautions")
            dt.Columns.Add("Side_Effect")
            dt.Columns.Add("Efficacy_Comparison")
            dt.Columns.Add("Insu_Order_Type_Id")
            dt.Columns.Add("Is_Alter")
            dt.Columns.Add("Alternative_Insu_Code_1")
            dt.Columns.Add("Alternative_Insu_Code_2")
            dt.Columns.Add("Alternative_Insu_Code_3")
            dt.Columns.Add("Alternative_Insu_Code_4")
            dt.Columns.Add("Alternative_Insu_Code_5")
            dt.Columns.Add("Alternative_Insu_Code_6")
            dt.Columns.Add("Alternative_Insu_Code_7")
            dt.Columns.Add("Alternative_Insu_Code_8")
            dt.Columns.Add("Alternative_Insu_Code_9")
            dt.Columns.Add("Alternative_Insu_Code_10")
            dt.Columns.Add("Is_Agreement_Print")
            dt.Columns.Add("Is_Instruction_Print")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Order_Code")
            pkColArray(1) = dt.Columns("Effect_Date")
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
            dt.Columns.Add("Effect_Date")
            dt.Columns("Effect_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("End_Date")
            dt.Columns("End_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Self_Insu_Code")
            dt.Columns("Self_Insu_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Apply_Status_Id")
            dt.Columns("Apply_Status_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Equipment_License")
            dt.Columns("Equipment_License").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Equipment_License_No")
            dt.Columns("Equipment_License_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Product_Features")
            dt.Columns("Product_Features").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Use_Reason")
            dt.Columns("Use_Reason").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Precautions")
            dt.Columns("Precautions").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Side_Effect")
            dt.Columns("Side_Effect").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Efficacy_Comparison")
            dt.Columns("Efficacy_Comparison").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Order_Type_Id")
            dt.Columns("Insu_Order_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Alter")
            dt.Columns("Is_Alter").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Alternative_Insu_Code_1")
            dt.Columns("Alternative_Insu_Code_1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Alternative_Insu_Code_2")
            dt.Columns("Alternative_Insu_Code_2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Alternative_Insu_Code_3")
            dt.Columns("Alternative_Insu_Code_3").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Alternative_Insu_Code_4")
            dt.Columns("Alternative_Insu_Code_4").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Alternative_Insu_Code_5")
            dt.Columns("Alternative_Insu_Code_5").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Alternative_Insu_Code_6")
            dt.Columns("Alternative_Insu_Code_6").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Alternative_Insu_Code_7")
            dt.Columns("Alternative_Insu_Code_7").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Alternative_Insu_Code_8")
            dt.Columns("Alternative_Insu_Code_8").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Alternative_Insu_Code_9")
            dt.Columns("Alternative_Insu_Code_9").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Alternative_Insu_Code_10")
            dt.Columns("Alternative_Insu_Code_10").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Agreement_Print")
            dt.Columns("Is_Agreement_Print").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Instruction_Print")
            dt.Columns("Is_Instruction_Print").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Order_Code")
            pkColArray(1) = dt.Columns("Effect_Date")
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
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Self_Insu_Code")
            dt.Columns.Add("Apply_Status_Id")
            dt.Columns.Add("Equipment_License")
            dt.Columns.Add("Equipment_License_No")
            dt.Columns.Add("Product_Features")
            dt.Columns.Add("Use_Reason")
            dt.Columns.Add("Precautions")
            dt.Columns.Add("Side_Effect")
            dt.Columns.Add("Efficacy_Comparison")
            dt.Columns.Add("Insu_Order_Type_Id")
            dt.Columns.Add("Is_Alter")
            dt.Columns.Add("Alternative_Insu_Code_1")
            dt.Columns.Add("Alternative_Insu_Code_2")
            dt.Columns.Add("Alternative_Insu_Code_3")
            dt.Columns.Add("Alternative_Insu_Code_4")
            dt.Columns.Add("Alternative_Insu_Code_5")
            dt.Columns.Add("Alternative_Insu_Code_6")
            dt.Columns.Add("Alternative_Insu_Code_7")
            dt.Columns.Add("Alternative_Insu_Code_8")
            dt.Columns.Add("Alternative_Insu_Code_9")
            dt.Columns.Add("Alternative_Insu_Code_10")
            dt.Columns.Add("Is_Agreement_Print")
            dt.Columns.Add("Is_Instruction_Print")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
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

  Class PUBMaterialSelfpayApplyPt
    Private m_Order_Code As String = "Order_Code"
    Public ReadOnly Property Order_Code() As System.String 
    Get
        Return m_Order_Code
    End Get
    End Property

    Private m_Effect_Date As String = "Effect_Date"
    Public ReadOnly Property Effect_Date() As System.String 
    Get
        Return m_Effect_Date
    End Get
    End Property

    Private m_End_Date As String = "End_Date"
    Public ReadOnly Property End_Date() As System.String 
    Get
        Return m_End_Date
    End Get
    End Property

    Private m_Self_Insu_Code As String = "Self_Insu_Code"
    Public ReadOnly Property Self_Insu_Code() As System.String 
    Get
        Return m_Self_Insu_Code
    End Get
    End Property

    Private m_Apply_Status_Id As String = "Apply_Status_Id"
    Public ReadOnly Property Apply_Status_Id() As System.String 
    Get
        Return m_Apply_Status_Id
    End Get
    End Property

    Private m_Equipment_License As String = "Equipment_License"
    Public ReadOnly Property Equipment_License() As System.String 
    Get
        Return m_Equipment_License
    End Get
    End Property

    Private m_Equipment_License_No As String = "Equipment_License_No"
    Public ReadOnly Property Equipment_License_No() As System.String 
    Get
        Return m_Equipment_License_No
    End Get
    End Property

    Private m_Product_Features As String = "Product_Features"
    Public ReadOnly Property Product_Features() As System.String 
    Get
        Return m_Product_Features
    End Get
    End Property

    Private m_Use_Reason As String = "Use_Reason"
    Public ReadOnly Property Use_Reason() As System.String 
    Get
        Return m_Use_Reason
    End Get
    End Property

    Private m_Precautions As String = "Precautions"
    Public ReadOnly Property Precautions() As System.String 
    Get
        Return m_Precautions
    End Get
    End Property

    Private m_Side_Effect As String = "Side_Effect"
    Public ReadOnly Property Side_Effect() As System.String 
    Get
        Return m_Side_Effect
    End Get
    End Property

    Private m_Efficacy_Comparison As String = "Efficacy_Comparison"
    Public ReadOnly Property Efficacy_Comparison() As System.String 
    Get
        Return m_Efficacy_Comparison
    End Get
    End Property

    Private m_Insu_Order_Type_Id As String = "Insu_Order_Type_Id"
    Public ReadOnly Property Insu_Order_Type_Id() As System.String 
    Get
        Return m_Insu_Order_Type_Id
    End Get
    End Property

    Private m_Is_Alter As String = "Is_Alter"
    Public ReadOnly Property Is_Alter() As System.String 
    Get
        Return m_Is_Alter
    End Get
    End Property

    Private m_Alternative_Insu_Code_1 As String = "Alternative_Insu_Code_1"
    Public ReadOnly Property Alternative_Insu_Code_1() As System.String 
    Get
        Return m_Alternative_Insu_Code_1
    End Get
    End Property

    Private m_Alternative_Insu_Code_2 As String = "Alternative_Insu_Code_2"
    Public ReadOnly Property Alternative_Insu_Code_2() As System.String 
    Get
        Return m_Alternative_Insu_Code_2
    End Get
    End Property

    Private m_Alternative_Insu_Code_3 As String = "Alternative_Insu_Code_3"
    Public ReadOnly Property Alternative_Insu_Code_3() As System.String 
    Get
        Return m_Alternative_Insu_Code_3
    End Get
    End Property

    Private m_Alternative_Insu_Code_4 As String = "Alternative_Insu_Code_4"
    Public ReadOnly Property Alternative_Insu_Code_4() As System.String 
    Get
        Return m_Alternative_Insu_Code_4
    End Get
    End Property

    Private m_Alternative_Insu_Code_5 As String = "Alternative_Insu_Code_5"
    Public ReadOnly Property Alternative_Insu_Code_5() As System.String 
    Get
        Return m_Alternative_Insu_Code_5
    End Get
    End Property

    Private m_Alternative_Insu_Code_6 As String = "Alternative_Insu_Code_6"
    Public ReadOnly Property Alternative_Insu_Code_6() As System.String 
    Get
        Return m_Alternative_Insu_Code_6
    End Get
    End Property

    Private m_Alternative_Insu_Code_7 As String = "Alternative_Insu_Code_7"
    Public ReadOnly Property Alternative_Insu_Code_7() As System.String 
    Get
        Return m_Alternative_Insu_Code_7
    End Get
    End Property

    Private m_Alternative_Insu_Code_8 As String = "Alternative_Insu_Code_8"
    Public ReadOnly Property Alternative_Insu_Code_8() As System.String 
    Get
        Return m_Alternative_Insu_Code_8
    End Get
    End Property

    Private m_Alternative_Insu_Code_9 As String = "Alternative_Insu_Code_9"
    Public ReadOnly Property Alternative_Insu_Code_9() As System.String 
    Get
        Return m_Alternative_Insu_Code_9
    End Get
    End Property

    Private m_Alternative_Insu_Code_10 As String = "Alternative_Insu_Code_10"
    Public ReadOnly Property Alternative_Insu_Code_10() As System.String 
    Get
        Return m_Alternative_Insu_Code_10
    End Get
    End Property

    Private m_Is_Agreement_Print As String = "Is_Agreement_Print"
    Public ReadOnly Property Is_Agreement_Print() As System.String 
    Get
        Return m_Is_Agreement_Print
    End Get
    End Property

    Private m_Is_Instruction_Print As String = "Is_Instruction_Print"
    Public ReadOnly Property Is_Instruction_Print() As System.String 
    Get
        Return m_Is_Instruction_Print
    End Get
    End Property

    Private m_Create_User As String = "Create_User"
    Public ReadOnly Property Create_User() As System.String 
    Get
        Return m_Create_User
    End Get
    End Property

    Private m_Create_Time As String = "Create_Time"
    Public ReadOnly Property Create_Time() As System.String 
    Get
        Return m_Create_Time
    End Get
    End Property

    Private m_Modified_User As String = "Modified_User"
    Public ReadOnly Property Modified_User() As System.String 
    Get
        Return m_Modified_User
    End Get
    End Property

    Private m_Modified_Time As String = "Modified_Time"
    Public ReadOnly Property Modified_Time() As System.String 
    Get
        Return m_Modified_Time
    End Get
    End Property

  End Class

End Class
