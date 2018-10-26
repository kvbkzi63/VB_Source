Imports System.Data.SqlClient
Public Class PubOrderDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/1/16 上午 09:59:47
    Public Shared ReadOnly tableName as String="PUB_Order"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Effect_Date", "Order_Code", "Order_En_Name", "Order_Name", "Order_En_Short_Name",   _
             "Order_Short_Name", "Order_Type_Id", "Account_Id", "Is_Cure", "Cure_Type_Id",   _
             "Treatment_Type_Id", "Charge_Unit", "Nhi_Transrate", "Nhi_Unit", "Is_Order_Check",   _
             "Fix_Order_Id", "Is_Exclude_Drug", "Order_Note", "Order_Memo", "Is_Agree_Sheet",   _
             "Is_Nhi_Sheet", "Is_Prior_Review", "Is_IC_Card_Order", "Is_Order_Price_Special", "Dc_Reason",   _
             "Dc", "End_Date", "Create_User", "Create_Time", "Modified_User",   _
             "Modified_Time", "Old_Order_Code", "Material_Used_Cnt", "Include_Order_Mark", "Insu_Cover_Opd",   _
             "Insu_Cover_Emg", "Insu_Cover_Ipd", "Is_Icd_Check", "Is_Emg_Nursing_Charge", "Majorcare_Code",   _
             "Cost_Price", "Is_Alternative"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.DateTime", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.Decimal", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.DateTime", "System.String", "System.DateTime", "System.String",   _
             "System.DateTime", "System.String", "System.Int32", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.Decimal", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             -1, 20, 100, 100, 50,   _
             50, 5, 5, 1, 5,   _
             5, 8, -1, 8, 1,   _
             5, 1, 1073741823, 100, 1,   _
             1, 1, 1, 1, 50,   _
             1, -1, 10, -1, 10,   _
             -1, 10, -1, 1, 1,   _
             1, 1, 1, 1, 2,   _
             -1, 1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubOrderDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Effect_Date") = New Object
        dataRow("Order_Code") = New Object
        dataRow("Order_En_Name") = New Object
        dataRow("Order_Name") = New Object
        dataRow("Order_En_Short_Name") = New Object
        dataRow("Order_Short_Name") = New Object
        dataRow("Order_Type_Id") = New Object
        dataRow("Account_Id") = New Object
        dataRow("Is_Cure") = New Object
        dataRow("Cure_Type_Id") = New Object
        dataRow("Treatment_Type_Id") = New Object
        dataRow("Charge_Unit") = New Object
        dataRow("Nhi_Transrate") = New Object
        dataRow("Nhi_Unit") = New Object
        dataRow("Is_Order_Check") = New Object
        dataRow("Fix_Order_Id") = New Object
        dataRow("Is_Exclude_Drug") = New Object
        dataRow("Order_Note") = New Object
        dataRow("Order_Memo") = New Object
        dataRow("Is_Agree_Sheet") = New Object
        dataRow("Is_Nhi_Sheet") = New Object
        dataRow("Is_Prior_Review") = New Object
        dataRow("Is_IC_Card_Order") = New Object
        dataRow("Is_Order_Price_Special") = New Object
        dataRow("Dc_Reason") = New Object
        dataRow("Dc") = New Object
        dataRow("End_Date") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Old_Order_Code") = New Object
        dataRow("Material_Used_Cnt") = New Object
        dataRow("Include_Order_Mark") = New Object
        dataRow("Insu_Cover_Opd") = New Object
        dataRow("Insu_Cover_Emg") = New Object
        dataRow("Insu_Cover_Ipd") = New Object
        dataRow("Is_Icd_Check") = New Object
        dataRow("Is_Emg_Nursing_Charge") = New Object
        dataRow("Majorcare_Code") = New Object
        dataRow("Cost_Price") = New Object
        dataRow("Is_Alternative") = New Object
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
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Order_En_Name")
            dt.Columns.Add("Order_Name")
            dt.Columns.Add("Order_En_Short_Name")
            dt.Columns.Add("Order_Short_Name")
            dt.Columns.Add("Order_Type_Id")
            dt.Columns.Add("Account_Id")
            dt.Columns.Add("Is_Cure")
            dt.Columns.Add("Cure_Type_Id")
            dt.Columns.Add("Treatment_Type_Id")
            dt.Columns.Add("Charge_Unit")
            dt.Columns.Add("Nhi_Transrate")
            dt.Columns.Add("Nhi_Unit")
            dt.Columns.Add("Is_Order_Check")
            dt.Columns.Add("Fix_Order_Id")
            dt.Columns.Add("Is_Exclude_Drug")
            dt.Columns.Add("Order_Note")
            dt.Columns.Add("Order_Memo")
            dt.Columns.Add("Is_Agree_Sheet")
            dt.Columns.Add("Is_Nhi_Sheet")
            dt.Columns.Add("Is_Prior_Review")
            dt.Columns.Add("Is_IC_Card_Order")
            dt.Columns.Add("Is_Order_Price_Special")
            dt.Columns.Add("Dc_Reason")
            dt.Columns.Add("Dc")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Old_Order_Code")
            dt.Columns.Add("Material_Used_Cnt")
            dt.Columns.Add("Include_Order_Mark")
            dt.Columns.Add("Insu_Cover_Opd")
            dt.Columns.Add("Insu_Cover_Emg")
            dt.Columns.Add("Insu_Cover_Ipd")
            dt.Columns.Add("Is_Icd_Check")
            dt.Columns.Add("Is_Emg_Nursing_Charge")
            dt.Columns.Add("Majorcare_Code")
            dt.Columns.Add("Cost_Price")
            dt.Columns.Add("Is_Alternative")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Effect_Date")
            pkColArray(1) = dt.Columns("Order_Code")
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
            dt.Columns.Add("Effect_Date")
            dt.Columns("Effect_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_En_Name")
            dt.Columns("Order_En_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Name")
            dt.Columns("Order_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_En_Short_Name")
            dt.Columns("Order_En_Short_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Short_Name")
            dt.Columns("Order_Short_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Type_Id")
            dt.Columns("Order_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Account_Id")
            dt.Columns("Account_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Cure")
            dt.Columns("Is_Cure").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cure_Type_Id")
            dt.Columns("Cure_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Treatment_Type_Id")
            dt.Columns("Treatment_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Charge_Unit")
            dt.Columns("Charge_Unit").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Nhi_Transrate")
            dt.Columns("Nhi_Transrate").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Nhi_Unit")
            dt.Columns("Nhi_Unit").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Order_Check")
            dt.Columns("Is_Order_Check").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Fix_Order_Id")
            dt.Columns("Fix_Order_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Exclude_Drug")
            dt.Columns("Is_Exclude_Drug").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Note")
            dt.Columns("Order_Note").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Memo")
            dt.Columns("Order_Memo").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Agree_Sheet")
            dt.Columns("Is_Agree_Sheet").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Nhi_Sheet")
            dt.Columns("Is_Nhi_Sheet").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Prior_Review")
            dt.Columns("Is_Prior_Review").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_IC_Card_Order")
            dt.Columns("Is_IC_Card_Order").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Order_Price_Special")
            dt.Columns("Is_Order_Price_Special").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dc_Reason")
            dt.Columns("Dc_Reason").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dc")
            dt.Columns("Dc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("End_Date")
            dt.Columns("End_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Old_Order_Code")
            dt.Columns("Old_Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Material_Used_Cnt")
            dt.Columns("Material_Used_Cnt").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Include_Order_Mark")
            dt.Columns("Include_Order_Mark").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Cover_Opd")
            dt.Columns("Insu_Cover_Opd").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Cover_Emg")
            dt.Columns("Insu_Cover_Emg").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Cover_Ipd")
            dt.Columns("Insu_Cover_Ipd").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Icd_Check")
            dt.Columns("Is_Icd_Check").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Emg_Nursing_Charge")
            dt.Columns("Is_Emg_Nursing_Charge").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Majorcare_Code")
            dt.Columns("Majorcare_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Cost_Price")
            dt.Columns("Cost_Price").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Is_Alternative")
            dt.Columns("Is_Alternative").DataType = System.Type.GetType("System.String")
            Dim pkColArray(1) As DataColumn 
            pkColArray(0) = dt.Columns("Effect_Date")
            pkColArray(1) = dt.Columns("Order_Code")
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
            dt.Columns.Add("Effect_Date")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Order_En_Name")
            dt.Columns.Add("Order_Name")
            dt.Columns.Add("Order_En_Short_Name")
            dt.Columns.Add("Order_Short_Name")
            dt.Columns.Add("Order_Type_Id")
            dt.Columns.Add("Account_Id")
            dt.Columns.Add("Is_Cure")
            dt.Columns.Add("Cure_Type_Id")
            dt.Columns.Add("Treatment_Type_Id")
            dt.Columns.Add("Charge_Unit")
            dt.Columns.Add("Nhi_Transrate")
            dt.Columns.Add("Nhi_Unit")
            dt.Columns.Add("Is_Order_Check")
            dt.Columns.Add("Fix_Order_Id")
            dt.Columns.Add("Is_Exclude_Drug")
            dt.Columns.Add("Order_Note")
            dt.Columns.Add("Order_Memo")
            dt.Columns.Add("Is_Agree_Sheet")
            dt.Columns.Add("Is_Nhi_Sheet")
            dt.Columns.Add("Is_Prior_Review")
            dt.Columns.Add("Is_IC_Card_Order")
            dt.Columns.Add("Is_Order_Price_Special")
            dt.Columns.Add("Dc_Reason")
            dt.Columns.Add("Dc")
            dt.Columns.Add("End_Date")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Old_Order_Code")
            dt.Columns.Add("Material_Used_Cnt")
            dt.Columns.Add("Include_Order_Mark")
            dt.Columns.Add("Insu_Cover_Opd")
            dt.Columns.Add("Insu_Cover_Emg")
            dt.Columns.Add("Insu_Cover_Ipd")
            dt.Columns.Add("Is_Icd_Check")
            dt.Columns.Add("Is_Emg_Nursing_Charge")
            dt.Columns.Add("Majorcare_Code")
            dt.Columns.Add("Cost_Price")
            dt.Columns.Add("Is_Alternative")
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

  Class PUBOrderPt
    Private m_Effect_Date As String = "Effect_Date"
    Public ReadOnly Property Effect_Date() As System.String 
    Get
        Return m_Effect_Date
    End Get
    End Property

    Private m_Order_Code As String = "Order_Code"
    Public ReadOnly Property Order_Code() As System.String 
    Get
        Return m_Order_Code
    End Get
    End Property

    Private m_Order_En_Name As String = "Order_En_Name"
    Public ReadOnly Property Order_En_Name() As System.String 
    Get
        Return m_Order_En_Name
    End Get
    End Property

    Private m_Order_Name As String = "Order_Name"
    Public ReadOnly Property Order_Name() As System.String 
    Get
        Return m_Order_Name
    End Get
    End Property

    Private m_Order_En_Short_Name As String = "Order_En_Short_Name"
    Public ReadOnly Property Order_En_Short_Name() As System.String 
    Get
        Return m_Order_En_Short_Name
    End Get
    End Property

    Private m_Order_Short_Name As String = "Order_Short_Name"
    Public ReadOnly Property Order_Short_Name() As System.String 
    Get
        Return m_Order_Short_Name
    End Get
    End Property

    Private m_Order_Type_Id As String = "Order_Type_Id"
    Public ReadOnly Property Order_Type_Id() As System.String 
    Get
        Return m_Order_Type_Id
    End Get
    End Property

    Private m_Account_Id As String = "Account_Id"
    Public ReadOnly Property Account_Id() As System.String 
    Get
        Return m_Account_Id
    End Get
    End Property

    Private m_Is_Cure As String = "Is_Cure"
    Public ReadOnly Property Is_Cure() As System.String 
    Get
        Return m_Is_Cure
    End Get
    End Property

    Private m_Cure_Type_Id As String = "Cure_Type_Id"
    Public ReadOnly Property Cure_Type_Id() As System.String 
    Get
        Return m_Cure_Type_Id
    End Get
    End Property

    Private m_Treatment_Type_Id As String = "Treatment_Type_Id"
    Public ReadOnly Property Treatment_Type_Id() As System.String 
    Get
        Return m_Treatment_Type_Id
    End Get
    End Property

    Private m_Charge_Unit As String = "Charge_Unit"
    Public ReadOnly Property Charge_Unit() As System.String 
    Get
        Return m_Charge_Unit
    End Get
    End Property

    Private m_Nhi_Transrate As String = "Nhi_Transrate"
    Public ReadOnly Property Nhi_Transrate() As System.String 
    Get
        Return m_Nhi_Transrate
    End Get
    End Property

    Private m_Nhi_Unit As String = "Nhi_Unit"
    Public ReadOnly Property Nhi_Unit() As System.String 
    Get
        Return m_Nhi_Unit
    End Get
    End Property

    Private m_Is_Order_Check As String = "Is_Order_Check"
    Public ReadOnly Property Is_Order_Check() As System.String 
    Get
        Return m_Is_Order_Check
    End Get
    End Property

    Private m_Fix_Order_Id As String = "Fix_Order_Id"
    Public ReadOnly Property Fix_Order_Id() As System.String 
    Get
        Return m_Fix_Order_Id
    End Get
    End Property

    Private m_Is_Exclude_Drug As String = "Is_Exclude_Drug"
    Public ReadOnly Property Is_Exclude_Drug() As System.String 
    Get
        Return m_Is_Exclude_Drug
    End Get
    End Property

    Private m_Order_Note As String = "Order_Note"
    Public ReadOnly Property Order_Note() As System.String 
    Get
        Return m_Order_Note
    End Get
    End Property

    Private m_Order_Memo As String = "Order_Memo"
    Public ReadOnly Property Order_Memo() As System.String 
    Get
        Return m_Order_Memo
    End Get
    End Property

    Private m_Is_Agree_Sheet As String = "Is_Agree_Sheet"
    Public ReadOnly Property Is_Agree_Sheet() As System.String 
    Get
        Return m_Is_Agree_Sheet
    End Get
    End Property

    Private m_Is_Nhi_Sheet As String = "Is_Nhi_Sheet"
    Public ReadOnly Property Is_Nhi_Sheet() As System.String 
    Get
        Return m_Is_Nhi_Sheet
    End Get
    End Property

    Private m_Is_Prior_Review As String = "Is_Prior_Review"
    Public ReadOnly Property Is_Prior_Review() As System.String 
    Get
        Return m_Is_Prior_Review
    End Get
    End Property

    Private m_Is_IC_Card_Order As String = "Is_IC_Card_Order"
    Public ReadOnly Property Is_IC_Card_Order() As System.String 
    Get
        Return m_Is_IC_Card_Order
    End Get
    End Property

    Private m_Is_Order_Price_Special As String = "Is_Order_Price_Special"
    Public ReadOnly Property Is_Order_Price_Special() As System.String 
    Get
        Return m_Is_Order_Price_Special
    End Get
    End Property

    Private m_Dc_Reason As String = "Dc_Reason"
    Public ReadOnly Property Dc_Reason() As System.String 
    Get
        Return m_Dc_Reason
    End Get
    End Property

    Private m_Dc As String = "Dc"
    Public ReadOnly Property Dc() As System.String 
    Get
        Return m_Dc
    End Get
    End Property

    Private m_End_Date As String = "End_Date"
    Public ReadOnly Property End_Date() As System.String 
    Get
        Return m_End_Date
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

    Private m_Old_Order_Code As String = "Old_Order_Code"
    Public ReadOnly Property Old_Order_Code() As System.String 
    Get
        Return m_Old_Order_Code
    End Get
    End Property

    Private m_Material_Used_Cnt As String = "Material_Used_Cnt"
    Public ReadOnly Property Material_Used_Cnt() As System.String 
    Get
        Return m_Material_Used_Cnt
    End Get
    End Property

    Private m_Include_Order_Mark As String = "Include_Order_Mark"
    Public ReadOnly Property Include_Order_Mark() As System.String 
    Get
        Return m_Include_Order_Mark
    End Get
    End Property

    Private m_Insu_Cover_Opd As String = "Insu_Cover_Opd"
    Public ReadOnly Property Insu_Cover_Opd() As System.String 
    Get
        Return m_Insu_Cover_Opd
    End Get
    End Property

    Private m_Insu_Cover_Emg As String = "Insu_Cover_Emg"
    Public ReadOnly Property Insu_Cover_Emg() As System.String 
    Get
        Return m_Insu_Cover_Emg
    End Get
    End Property

    Private m_Insu_Cover_Ipd As String = "Insu_Cover_Ipd"
    Public ReadOnly Property Insu_Cover_Ipd() As System.String 
    Get
        Return m_Insu_Cover_Ipd
    End Get
    End Property

    Private m_Is_Icd_Check As String = "Is_Icd_Check"
    Public ReadOnly Property Is_Icd_Check() As System.String 
    Get
        Return m_Is_Icd_Check
    End Get
    End Property

    Private m_Is_Emg_Nursing_Charge As String = "Is_Emg_Nursing_Charge"
    Public ReadOnly Property Is_Emg_Nursing_Charge() As System.String 
    Get
        Return m_Is_Emg_Nursing_Charge
    End Get
    End Property

    Private m_Majorcare_Code As String = "Majorcare_Code"
    Public ReadOnly Property Majorcare_Code() As System.String 
    Get
        Return m_Majorcare_Code
    End Get
    End Property

    Private m_Cost_Price As String = "Cost_Price"
    Public ReadOnly Property Cost_Price() As System.String 
    Get
        Return m_Cost_Price
    End Get
    End Property

    Private m_Is_Alternative As String = "Is_Alternative"
    Public ReadOnly Property Is_Alternative() As System.String 
    Get
        Return m_Is_Alternative
    End Get
    End Property

  End Class

End Class
