Imports System.Data.SqlClient
Public Class pubOphPharmacyBaseDataTableFactory
    'Roger's CodeGen Produced This VB Code @ 2012/9/18 上午 09:57:03
    Public Shared ReadOnly tableName As String = "OPH_Pharmacy_Base"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Pharmacy_12_Code", "Order_Code", "Insu_Code", "Scientific_Name", "Compositio_Name1", _
             "Compositio_Content1", "Compositio_Unit_Code1", "Compositio_Name2", "Compositio_Content2", "Compositio_Unit_Code2", _
             "Compositio_Name3", "Compositio_Content3", "Compositio_Unit_Code3", "Trade_Name", "Chinese_Name", _
             "Order_Name", "Pharmacy_Name", "Base_Dosage", "Specification", "Omo_Reminder_Id", _
             "Reminder_Id", "Percentage", "ATC_Code", "DDD", "DDD_Unit_Code", _
             "License", "Supplier_Id", "Origin_Id", "Usage_Code", "Frequency_Code", _
             "Transfer_Factor1", "Transfer_Factor_Unit1", "Transfer_Factor2", "Transfer_Factor_Unit2", "Transfer_Factor3", _
             "Transfer_Factor_Unit3", "Transfer_Factor4", "Transfer_Factor_Unit4", "Transfer_Factor5", "Transfer_Factor_Unit5", _
             "Base_Dosage_Unit", "Order_Unit1", "Order_Unit2", "Order_Unit3", "Order_Unit4", _
             "Order_Unit5", "Charge_Unit", "Deliver_Unit", "Dosage_unit", "Package_Qty", _
             "Package_Unit", "Is_Dosage_Accumulation", "Accumulation_Id", "Is_Total_Qty", "Package_Factor1", _
             "Package_Factor_Unit1", "Package_Factor2", "Package_Factor_Unit2", "Package_Factor3", "Package_Factor_Unit3", _
             "Package_Factor4", "Package_Factor_Unit4", "Supply_Method_Id", "Alias_Name", "Class_Code", _
             "Pregnancy_Class_Id", "Pregnancy_Class_Memo", "Lactation_Suggest_Id", "Non_Powder_Reason_Id", "Storage_Mode_Id", _
             "Madeup_Mode_Id", "PDF_Form_Path", "Is_FDA_Alert", "Else_Info", "Attention_Content", _
             "Salt_Base1", "Salt_Base_Content1", "Salt_Base_Unit_Code1", "Salt_Base2", "Salt_Base_Content2", _
             "Salt_Base_Unit_Code2", "Opd_Lack_Id", "Ipd_Lack_Id", "Emg_Lack_Id", "Supply_Status_Memo", _
             "Form_Kind_Id", "Is_Non_Powder", "Is_Non_Share", "Is_Non_Peel", "Is_Control_Rule", _
             "Dosage_Type_Code", "Is_Slice", "Is_Non_Display", "Dc", "Create_User", _
             "Create_Time", "Modified_User", "Modified_Time", "Is_Dosage_Accumulation_Epd", "Epd_Accumulation_Id", _
             "Is_Dosage_Accumulation_Ipd", "Ipd_Accumulation_Id", "Dilute_Type", "Is_Pvc", "Alert_Content", _
             "Drip_Content", "Concentration_Content", "Rate_Content", "Is_Non_Return"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.Decimal", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.Decimal", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.Decimal", "System.String", "System.Decimal", "System.String", "System.Decimal", _
             "System.String", "System.Decimal", "System.String", "System.Decimal", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.Decimal", _
             "System.String", "System.String", "System.String", "System.String", "System.Decimal", _
             "System.String", "System.Decimal", "System.String", "System.Decimal", "System.String", _
             "System.Decimal", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.DateTime", "System.String", "System.DateTime", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String", "System.String", _
             "System.String", "System.String", "System.String", "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             12, 20, 20, 200, 100, _
             50, 20, 100, 50, 20, _
             100, 50, 20, 150, 150, _
             300, 300, -1, 500, 6, _
             6, 10, 30, -1, 8, _
             30, 10, 6, 6, 10, _
             -1, 8, -1, 8, -1, _
             8, -1, 8, -1, 8, _
             8, 8, 8, 8, 8, _
             8, 8, 8, 8, -1, _
             8, 1, 6, 1, -1, _
             8, -1, 8, -1, 8, _
             -1, 8, 6, 100, 4, _
             6, 200, 6, 6, 6, _
             6, 100, 1, 1073741823, 300, _
             20, 50, 8, 20, 50, _
             8, 6, 6, 6, 200, _
             6, 1, 1, 1, 1, _
             10, 1, 1, 1, 10, _
             -1, 10, -1, 1, 6, _
             1, 6, 6, 1, 100, _
             50, 50, 50, 1}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub example()
        Dim dataSet As DataSet = New DataSet
        Dim dataTable As DataTable = pubOphPharmacyBaseDataTableFactory.getDataTableWithSchema
        Dim dataRow As DataRow = dataTable.NewRow()
        '使用自己的資料來源取代 New Object 
        dataRow("Pharmacy_12_Code") = New Object
        dataRow("Order_Code") = New Object
        dataRow("Insu_Code") = New Object
        dataRow("Scientific_Name") = New Object
        dataRow("Compositio_Name1") = New Object
        dataRow("Compositio_Content1") = New Object
        dataRow("Compositio_Unit_Code1") = New Object
        dataRow("Compositio_Name2") = New Object
        dataRow("Compositio_Content2") = New Object
        dataRow("Compositio_Unit_Code2") = New Object
        dataRow("Compositio_Name3") = New Object
        dataRow("Compositio_Content3") = New Object
        dataRow("Compositio_Unit_Code3") = New Object
        dataRow("Trade_Name") = New Object
        dataRow("Chinese_Name") = New Object
        dataRow("Order_Name") = New Object
        dataRow("Pharmacy_Name") = New Object
        dataRow("Base_Dosage") = New Object
        dataRow("Specification") = New Object
        dataRow("Omo_Reminder_Id") = New Object
        dataRow("Reminder_Id") = New Object
        dataRow("Percentage") = New Object
        dataRow("ATC_Code") = New Object
        dataRow("DDD") = New Object
        dataRow("DDD_Unit_Code") = New Object
        dataRow("License") = New Object
        dataRow("Supplier_Id") = New Object
        dataRow("Origin_Id") = New Object
        dataRow("Usage_Code") = New Object
        dataRow("Frequency_Code") = New Object
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
        dataRow("Base_Dosage_Unit") = New Object
        dataRow("Order_Unit1") = New Object
        dataRow("Order_Unit2") = New Object
        dataRow("Order_Unit3") = New Object
        dataRow("Order_Unit4") = New Object
        dataRow("Order_Unit5") = New Object
        dataRow("Charge_Unit") = New Object
        dataRow("Deliver_Unit") = New Object
        dataRow("Dosage_unit") = New Object
        dataRow("Package_Qty") = New Object
        dataRow("Package_Unit") = New Object
        dataRow("Is_Dosage_Accumulation") = New Object
        dataRow("Accumulation_Id") = New Object
        dataRow("Is_Total_Qty") = New Object
        dataRow("Package_Factor1") = New Object
        dataRow("Package_Factor_Unit1") = New Object
        dataRow("Package_Factor2") = New Object
        dataRow("Package_Factor_Unit2") = New Object
        dataRow("Package_Factor3") = New Object
        dataRow("Package_Factor_Unit3") = New Object
        dataRow("Package_Factor4") = New Object
        dataRow("Package_Factor_Unit4") = New Object
        dataRow("Supply_Method_Id") = New Object
        dataRow("Alias_Name") = New Object
        dataRow("Class_Code") = New Object
        dataRow("Pregnancy_Class_Id") = New Object
        dataRow("Pregnancy_Class_Memo") = New Object
        dataRow("Lactation_Suggest_Id") = New Object
        dataRow("Non_Powder_Reason_Id") = New Object
        dataRow("Storage_Mode_Id") = New Object
        dataRow("Madeup_Mode_Id") = New Object
        dataRow("PDF_Form_Path") = New Object
        dataRow("Is_FDA_Alert") = New Object
        dataRow("Else_Info") = New Object
        dataRow("Attention_Content") = New Object
        dataRow("Salt_Base1") = New Object
        dataRow("Salt_Base_Content1") = New Object
        dataRow("Salt_Base_Unit_Code1") = New Object
        dataRow("Salt_Base2") = New Object
        dataRow("Salt_Base_Content2") = New Object
        dataRow("Salt_Base_Unit_Code2") = New Object
        dataRow("Opd_Lack_Id") = New Object
        dataRow("Ipd_Lack_Id") = New Object
        dataRow("Emg_Lack_Id") = New Object
        dataRow("Supply_Status_Memo") = New Object
        dataRow("Form_Kind_Id") = New Object
        dataRow("Is_Non_Powder") = New Object
        dataRow("Is_Non_Share") = New Object
        dataRow("Is_Non_Peel") = New Object
        dataRow("Is_Control_Rule") = New Object
        dataRow("Dosage_Type_Code") = New Object
        dataRow("Is_Slice") = New Object
        dataRow("Is_Non_Display") = New Object
        dataRow("Dc") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Is_Dosage_Accumulation_Epd") = New Object
        dataRow("Epd_Accumulation_Id") = New Object
        dataRow("Is_Dosage_Accumulation_Ipd") = New Object
        dataRow("Ipd_Accumulation_Id") = New Object
        dataRow("Dilute_Type") = New Object
        dataRow("Is_Pvc") = New Object
        dataRow("Alert_Content") = New Object
        dataRow("Drip_Content") = New Object
        dataRow("Concentration_Content") = New Object
        dataRow("Rate_Content") = New Object
        dataRow("Is_Non_Return") = New Object
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
            dt.Columns.Add("Pharmacy_12_Code")
            dt.Columns.Add("Order_Code")
            dt.Columns.Add("Insu_Code")
            dt.Columns.Add("Scientific_Name")
            dt.Columns.Add("Compositio_Name1")
            dt.Columns.Add("Compositio_Content1")
            dt.Columns.Add("Compositio_Unit_Code1")
            dt.Columns.Add("Compositio_Name2")
            dt.Columns.Add("Compositio_Content2")
            dt.Columns.Add("Compositio_Unit_Code2")
            dt.Columns.Add("Compositio_Name3")
            dt.Columns.Add("Compositio_Content3")
            dt.Columns.Add("Compositio_Unit_Code3")
            dt.Columns.Add("Trade_Name")
            dt.Columns.Add("Chinese_Name")
            dt.Columns.Add("Order_Name")
            dt.Columns.Add("Pharmacy_Name")
            dt.Columns.Add("Base_Dosage")
            dt.Columns.Add("Specification")
            dt.Columns.Add("Omo_Reminder_Id")
            dt.Columns.Add("Reminder_Id")
            dt.Columns.Add("Percentage")
            dt.Columns.Add("ATC_Code")
            dt.Columns.Add("DDD")
            dt.Columns.Add("DDD_Unit_Code")
            dt.Columns.Add("License")
            dt.Columns.Add("Supplier_Id")
            dt.Columns.Add("Origin_Id")
            dt.Columns.Add("Usage_Code")
            dt.Columns.Add("Frequency_Code")
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
            dt.Columns.Add("Base_Dosage_Unit")
            dt.Columns.Add("Order_Unit1")
            dt.Columns.Add("Order_Unit2")
            dt.Columns.Add("Order_Unit3")
            dt.Columns.Add("Order_Unit4")
            dt.Columns.Add("Order_Unit5")
            dt.Columns.Add("Charge_Unit")
            dt.Columns.Add("Deliver_Unit")
            dt.Columns.Add("Dosage_unit")
            dt.Columns.Add("Package_Qty")
            dt.Columns.Add("Package_Unit")
            dt.Columns.Add("Is_Dosage_Accumulation")
            dt.Columns.Add("Accumulation_Id")
            dt.Columns.Add("Is_Total_Qty")
            dt.Columns.Add("Package_Factor1")
            dt.Columns.Add("Package_Factor_Unit1")
            dt.Columns.Add("Package_Factor2")
            dt.Columns.Add("Package_Factor_Unit2")
            dt.Columns.Add("Package_Factor3")
            dt.Columns.Add("Package_Factor_Unit3")
            dt.Columns.Add("Package_Factor4")
            dt.Columns.Add("Package_Factor_Unit4")
            dt.Columns.Add("Supply_Method_Id")
            dt.Columns.Add("Alias_Name")
            dt.Columns.Add("Class_Code")
            dt.Columns.Add("Pregnancy_Class_Id")
            dt.Columns.Add("Pregnancy_Class_Memo")
            dt.Columns.Add("Lactation_Suggest_Id")
            dt.Columns.Add("Non_Powder_Reason_Id")
            dt.Columns.Add("Storage_Mode_Id")
            dt.Columns.Add("Madeup_Mode_Id")
            dt.Columns.Add("PDF_Form_Path")
            dt.Columns.Add("Is_FDA_Alert")
            dt.Columns.Add("Else_Info")
            dt.Columns.Add("Attention_Content")
            dt.Columns.Add("Salt_Base1")
            dt.Columns.Add("Salt_Base_Content1")
            dt.Columns.Add("Salt_Base_Unit_Code1")
            dt.Columns.Add("Salt_Base2")
            dt.Columns.Add("Salt_Base_Content2")
            dt.Columns.Add("Salt_Base_Unit_Code2")
            dt.Columns.Add("Opd_Lack_Id")
            dt.Columns.Add("Ipd_Lack_Id")
            dt.Columns.Add("Emg_Lack_Id")
            dt.Columns.Add("Supply_Status_Memo")
            dt.Columns.Add("Form_Kind_Id")
            dt.Columns.Add("Is_Non_Powder")
            dt.Columns.Add("Is_Non_Share")
            dt.Columns.Add("Is_Non_Peel")
            dt.Columns.Add("Is_Control_Rule")
            dt.Columns.Add("Dosage_Type_Code")
            dt.Columns.Add("Is_Slice")
            dt.Columns.Add("Is_Non_Display")
            dt.Columns.Add("Dc")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Is_Dosage_Accumulation_Epd")
            dt.Columns.Add("Epd_Accumulation_Id")
            dt.Columns.Add("Is_Dosage_Accumulation_Ipd")
            dt.Columns.Add("Ipd_Accumulation_Id")
            dt.Columns.Add("Dilute_Type")
            dt.Columns.Add("Is_Pvc")
            dt.Columns.Add("Alert_Content")
            dt.Columns.Add("Drip_Content")
            dt.Columns.Add("Concentration_Content")
            dt.Columns.Add("Rate_Content")
            dt.Columns.Add("Is_Non_Return")
            Dim pkColArray(0) As DataColumn
            pkColArray(0) = dt.Columns("Pharmacy_12_Code")
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
            dt.Columns.Add("Pharmacy_12_Code")
            dt.Columns("Pharmacy_12_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Code")
            dt.Columns("Order_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Insu_Code")
            dt.Columns("Insu_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Scientific_Name")
            dt.Columns("Scientific_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Compositio_Name1")
            dt.Columns("Compositio_Name1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Compositio_Content1")
            dt.Columns("Compositio_Content1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Compositio_Unit_Code1")
            dt.Columns("Compositio_Unit_Code1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Compositio_Name2")
            dt.Columns("Compositio_Name2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Compositio_Content2")
            dt.Columns("Compositio_Content2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Compositio_Unit_Code2")
            dt.Columns("Compositio_Unit_Code2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Compositio_Name3")
            dt.Columns("Compositio_Name3").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Compositio_Content3")
            dt.Columns("Compositio_Content3").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Compositio_Unit_Code3")
            dt.Columns("Compositio_Unit_Code3").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Trade_Name")
            dt.Columns("Trade_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Chinese_Name")
            dt.Columns("Chinese_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Name")
            dt.Columns("Order_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Pharmacy_Name")
            dt.Columns("Pharmacy_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Base_Dosage")
            dt.Columns("Base_Dosage").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Specification")
            dt.Columns("Specification").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Omo_Reminder_Id")
            dt.Columns("Omo_Reminder_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Reminder_Id")
            dt.Columns("Reminder_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Percentage")
            dt.Columns("Percentage").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("ATC_Code")
            dt.Columns("ATC_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("DDD")
            dt.Columns("DDD").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("DDD_Unit_Code")
            dt.Columns("DDD_Unit_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("License")
            dt.Columns("License").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Supplier_Id")
            dt.Columns("Supplier_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Origin_Id")
            dt.Columns("Origin_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Usage_Code")
            dt.Columns("Usage_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Frequency_Code")
            dt.Columns("Frequency_Code").DataType = System.Type.GetType("System.String")
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
            dt.Columns.Add("Base_Dosage_Unit")
            dt.Columns("Base_Dosage_Unit").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Unit1")
            dt.Columns("Order_Unit1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Unit2")
            dt.Columns("Order_Unit2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Unit3")
            dt.Columns("Order_Unit3").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Unit4")
            dt.Columns("Order_Unit4").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Order_Unit5")
            dt.Columns("Order_Unit5").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Charge_Unit")
            dt.Columns("Charge_Unit").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Deliver_Unit")
            dt.Columns("Deliver_Unit").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dosage_unit")
            dt.Columns("Dosage_unit").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Package_Qty")
            dt.Columns("Package_Qty").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Package_Unit")
            dt.Columns("Package_Unit").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Dosage_Accumulation")
            dt.Columns("Is_Dosage_Accumulation").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Accumulation_Id")
            dt.Columns("Accumulation_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Total_Qty")
            dt.Columns("Is_Total_Qty").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Package_Factor1")
            dt.Columns("Package_Factor1").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Package_Factor_Unit1")
            dt.Columns("Package_Factor_Unit1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Package_Factor2")
            dt.Columns("Package_Factor2").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Package_Factor_Unit2")
            dt.Columns("Package_Factor_Unit2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Package_Factor3")
            dt.Columns("Package_Factor3").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Package_Factor_Unit3")
            dt.Columns("Package_Factor_Unit3").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Package_Factor4")
            dt.Columns("Package_Factor4").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Package_Factor_Unit4")
            dt.Columns("Package_Factor_Unit4").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Supply_Method_Id")
            dt.Columns("Supply_Method_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Alias_Name")
            dt.Columns("Alias_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Class_Code")
            dt.Columns("Class_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Pregnancy_Class_Id")
            dt.Columns("Pregnancy_Class_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Pregnancy_Class_Memo")
            dt.Columns("Pregnancy_Class_Memo").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Lactation_Suggest_Id")
            dt.Columns("Lactation_Suggest_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Non_Powder_Reason_Id")
            dt.Columns("Non_Powder_Reason_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Storage_Mode_Id")
            dt.Columns("Storage_Mode_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Madeup_Mode_Id")
            dt.Columns("Madeup_Mode_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("PDF_Form_Path")
            dt.Columns("PDF_Form_Path").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_FDA_Alert")
            dt.Columns("Is_FDA_Alert").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Else_Info")
            dt.Columns("Else_Info").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Attention_Content")
            dt.Columns("Attention_Content").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Salt_Base1")
            dt.Columns("Salt_Base1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Salt_Base_Content1")
            dt.Columns("Salt_Base_Content1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Salt_Base_Unit_Code1")
            dt.Columns("Salt_Base_Unit_Code1").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Salt_Base2")
            dt.Columns("Salt_Base2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Salt_Base_Content2")
            dt.Columns("Salt_Base_Content2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Salt_Base_Unit_Code2")
            dt.Columns("Salt_Base_Unit_Code2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Opd_Lack_Id")
            dt.Columns("Opd_Lack_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Ipd_Lack_Id")
            dt.Columns("Ipd_Lack_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Emg_Lack_Id")
            dt.Columns("Emg_Lack_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Supply_Status_Memo")
            dt.Columns("Supply_Status_Memo").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Form_Kind_Id")
            dt.Columns("Form_Kind_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Non_Powder")
            dt.Columns("Is_Non_Powder").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Non_Share")
            dt.Columns("Is_Non_Share").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Non_Peel")
            dt.Columns("Is_Non_Peel").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Control_Rule")
            dt.Columns("Is_Control_Rule").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dosage_Type_Code")
            dt.Columns("Dosage_Type_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Slice")
            dt.Columns("Is_Slice").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Non_Display")
            dt.Columns("Is_Non_Display").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dc")
            dt.Columns("Dc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Is_Dosage_Accumulation_Epd")
            dt.Columns("Is_Dosage_Accumulation_Epd").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Epd_Accumulation_Id")
            dt.Columns("Epd_Accumulation_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Dosage_Accumulation_Ipd")
            dt.Columns("Is_Dosage_Accumulation_Ipd").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Ipd_Accumulation_Id")
            dt.Columns("Ipd_Accumulation_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dilute_Type")
            dt.Columns("Dilute_Type").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Pvc")
            dt.Columns("Is_Pvc").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Alert_Content")
            dt.Columns("Alert_Content").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Drip_Content")
            dt.Columns("Drip_Content").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Concentration_Content")
            dt.Columns("Concentration_Content").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Rate_Content")
            dt.Columns("Rate_Content").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Non_Return")
            dt.Columns("Is_Non_Return").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn
            pkColArray(0) = dt.Columns("Pharmacy_12_Code")
            dt.PrimaryKey = pkColArray
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
