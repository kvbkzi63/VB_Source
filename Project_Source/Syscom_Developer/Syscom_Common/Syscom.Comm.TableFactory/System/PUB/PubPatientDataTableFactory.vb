Imports System.Data.SqlClient
Public Class PubPatientDataTableFactory
    'Syscom's CodeGen Produced This VB Code @ 2017/2/15 下午 05:35:11
    Public Shared ReadOnly tableName as String="PUB_Patient"
    '欄位名稱
    Public Shared ReadOnly columnsName As String() = New String() { _
             "Chart_No", "Patient_Name", "Patient_En_Name", "Idno_Type_Id", "Idno",   _
             "Birth_Date", "Sex_Id", "Blood_Type_Id", "Education_Id", "Marriage_Id",   _
             "Job_Id", "Nationality_Id", "Race_Id", "Area_Code", "Register_Postal_Code",   _
             "Register_Address", "Postal_Code", "Address", "Tel_Home", "Tel_Office",   _
             "Tel_Mobile", "Fax", "Email", "Postal_Code2", "Address2",   _
             "Tel2", "Tel2_Mobile", "Email2", "First_Visit_Date", "Latest_Visit_Date",   _
             "Latest_Admission_Date", "Latest_Discharge_Date", "Ipd_Times", "Latest_Xray_Date", "Latest_CT_Date",   _
             "Arrears_Times", "Opd_Arrears_Amt", "Emg_Arrears_Amt", "Ipd_Arrears_Amt", "Measure_Time",   _
             "Latest_Height", "Latest_Weight", "Mis_Register_Date1", "Mis_Register_Date2", "Mis_Register_Date3",   _
             "Mis_Register_Times", "Mis_Register_End_Date", "Is_Death", "Death_Time", "Is_Chart_Divide",   _
             "Is_Chart_Image", "Patient_Memo", "Is_Employee", "Reserve_Chart_No", "Latest_LMP_Date",   _
             "LIS_Blood_Report", "LIS_Blood_Report_Time", "LIS_BMT_Mark", "Student_Id", "Create_User",   _
             "Create_Time", "Modified_User", "Modified_Time", "Is_IPD", "Is_EMG",   _
             "Patient_Short_Name", "Reg_Notify_Id", "Register_Dist_Code", "Register_Vil_Code", "Dist_Code",   _
             "Vil_Code", "Dist_Code2", "Vil_Code2", "Not_Scrap", "Chart_No_Int",   _
             "Info_Confirm"}
    '欄位型態
    Public Shared ReadOnly columnsType As String() = New String() { _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.DateTime", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.DateTime", "System.DateTime",   _
             "System.DateTime", "System.DateTime", "System.Int32", "System.DateTime", "System.DateTime",   _
             "System.Int32", "System.Decimal", "System.Decimal", "System.Decimal", "System.DateTime",   _
             "System.Decimal", "System.Decimal", "System.DateTime", "System.DateTime", "System.DateTime",   _
             "System.Int32", "System.DateTime", "System.String", "System.DateTime", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.DateTime",   _
             "System.String", "System.DateTime", "System.String", "System.String", "System.String",   _
             "System.DateTime", "System.String", "System.DateTime", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.String",   _
             "System.String", "System.String", "System.String", "System.String", "System.Int64",   _
             "System.String"}
    '欄位字串長度，非字串形態為-1
    Public Shared ReadOnly columnsLength As Integer() = New Integer() { _
             10, 50, 50, 5, 20,   _
             -1, 5, 5, 5, 5,   _
             5, 5, 5, 4, 5,   _
             100, 5, 100, 20, 20,   _
             20, 20, 50, 5, 100,   _
             20, 20, 50, -1, -1,   _
             -1, -1, -1, -1, -1,   _
             -1, -1, -1, -1, -1,   _
             -1, -1, -1, -1, -1,   _
             -1, -1, 1, -1, 1,   _
             1, 100, 1, 10, -1,   _
             20, -1, 1, 9, 10,   _
             -1, 10, -1, 1, 1,   _
             12, 5, 7, 11, 7,   _
             11, 7, 11, 1, -1,   _
             10}

    ''' <summary>
    '''操作 data table 的程式範例，copy 程式碼使用之....
    ''' </summary>
    ''' <remarks></remarks>
    Private sub example() 
        Dim dataSet As DataSet = New DataSet 
        Dim dataTable As DataTable = PubPatientDataTableFactory.getDataTableWithSchema 
        Dim dataRow As DataRow = dataTable.NewRow() 
        '使用自己的資料來源取代 New Object 
        dataRow("Chart_No") = New Object
        dataRow("Patient_Name") = New Object
        dataRow("Patient_En_Name") = New Object
        dataRow("Idno_Type_Id") = New Object
        dataRow("Idno") = New Object
        dataRow("Birth_Date") = New Object
        dataRow("Sex_Id") = New Object
        dataRow("Blood_Type_Id") = New Object
        dataRow("Education_Id") = New Object
        dataRow("Marriage_Id") = New Object
        dataRow("Job_Id") = New Object
        dataRow("Nationality_Id") = New Object
        dataRow("Race_Id") = New Object
        dataRow("Area_Code") = New Object
        dataRow("Register_Postal_Code") = New Object
        dataRow("Register_Address") = New Object
        dataRow("Postal_Code") = New Object
        dataRow("Address") = New Object
        dataRow("Tel_Home") = New Object
        dataRow("Tel_Office") = New Object
        dataRow("Tel_Mobile") = New Object
        dataRow("Fax") = New Object
        dataRow("Email") = New Object
        dataRow("Postal_Code2") = New Object
        dataRow("Address2") = New Object
        dataRow("Tel2") = New Object
        dataRow("Tel2_Mobile") = New Object
        dataRow("Email2") = New Object
        dataRow("First_Visit_Date") = New Object
        dataRow("Latest_Visit_Date") = New Object
        dataRow("Latest_Admission_Date") = New Object
        dataRow("Latest_Discharge_Date") = New Object
        dataRow("Ipd_Times") = New Object
        dataRow("Latest_Xray_Date") = New Object
        dataRow("Latest_CT_Date") = New Object
        dataRow("Arrears_Times") = New Object
        dataRow("Opd_Arrears_Amt") = New Object
        dataRow("Emg_Arrears_Amt") = New Object
        dataRow("Ipd_Arrears_Amt") = New Object
        dataRow("Measure_Time") = New Object
        dataRow("Latest_Height") = New Object
        dataRow("Latest_Weight") = New Object
        dataRow("Mis_Register_Date1") = New Object
        dataRow("Mis_Register_Date2") = New Object
        dataRow("Mis_Register_Date3") = New Object
        dataRow("Mis_Register_Times") = New Object
        dataRow("Mis_Register_End_Date") = New Object
        dataRow("Is_Death") = New Object
        dataRow("Death_Time") = New Object
        dataRow("Is_Chart_Divide") = New Object
        dataRow("Is_Chart_Image") = New Object
        dataRow("Patient_Memo") = New Object
        dataRow("Is_Employee") = New Object
        dataRow("Reserve_Chart_No") = New Object
        dataRow("Latest_LMP_Date") = New Object
        dataRow("LIS_Blood_Report") = New Object
        dataRow("LIS_Blood_Report_Time") = New Object
        dataRow("LIS_BMT_Mark") = New Object
        dataRow("Student_Id") = New Object
        dataRow("Create_User") = New Object
        dataRow("Create_Time") = New Object
        dataRow("Modified_User") = New Object
        dataRow("Modified_Time") = New Object
        dataRow("Is_IPD") = New Object
        dataRow("Is_EMG") = New Object
        dataRow("Patient_Short_Name") = New Object
        dataRow("Reg_Notify_Id") = New Object
        dataRow("Register_Dist_Code") = New Object
        dataRow("Register_Vil_Code") = New Object
        dataRow("Dist_Code") = New Object
        dataRow("Vil_Code") = New Object
        dataRow("Dist_Code2") = New Object
        dataRow("Vil_Code2") = New Object
        dataRow("Not_Scrap") = New Object
        dataRow("Chart_No_Int") = New Object
        dataRow("Info_Confirm") = New Object
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
            dt.Columns.Add("Chart_No")
            dt.Columns.Add("Patient_Name")
            dt.Columns.Add("Patient_En_Name")
            dt.Columns.Add("Idno_Type_Id")
            dt.Columns.Add("Idno")
            dt.Columns.Add("Birth_Date")
            dt.Columns.Add("Sex_Id")
            dt.Columns.Add("Blood_Type_Id")
            dt.Columns.Add("Education_Id")
            dt.Columns.Add("Marriage_Id")
            dt.Columns.Add("Job_Id")
            dt.Columns.Add("Nationality_Id")
            dt.Columns.Add("Race_Id")
            dt.Columns.Add("Area_Code")
            dt.Columns.Add("Register_Postal_Code")
            dt.Columns.Add("Register_Address")
            dt.Columns.Add("Postal_Code")
            dt.Columns.Add("Address")
            dt.Columns.Add("Tel_Home")
            dt.Columns.Add("Tel_Office")
            dt.Columns.Add("Tel_Mobile")
            dt.Columns.Add("Fax")
            dt.Columns.Add("Email")
            dt.Columns.Add("Postal_Code2")
            dt.Columns.Add("Address2")
            dt.Columns.Add("Tel2")
            dt.Columns.Add("Tel2_Mobile")
            dt.Columns.Add("Email2")
            dt.Columns.Add("First_Visit_Date")
            dt.Columns.Add("Latest_Visit_Date")
            dt.Columns.Add("Latest_Admission_Date")
            dt.Columns.Add("Latest_Discharge_Date")
            dt.Columns.Add("Ipd_Times")
            dt.Columns.Add("Latest_Xray_Date")
            dt.Columns.Add("Latest_CT_Date")
            dt.Columns.Add("Arrears_Times")
            dt.Columns.Add("Opd_Arrears_Amt")
            dt.Columns.Add("Emg_Arrears_Amt")
            dt.Columns.Add("Ipd_Arrears_Amt")
            dt.Columns.Add("Measure_Time")
            dt.Columns.Add("Latest_Height")
            dt.Columns.Add("Latest_Weight")
            dt.Columns.Add("Mis_Register_Date1")
            dt.Columns.Add("Mis_Register_Date2")
            dt.Columns.Add("Mis_Register_Date3")
            dt.Columns.Add("Mis_Register_Times")
            dt.Columns.Add("Mis_Register_End_Date")
            dt.Columns.Add("Is_Death")
            dt.Columns.Add("Death_Time")
            dt.Columns.Add("Is_Chart_Divide")
            dt.Columns.Add("Is_Chart_Image")
            dt.Columns.Add("Patient_Memo")
            dt.Columns.Add("Is_Employee")
            dt.Columns.Add("Reserve_Chart_No")
            dt.Columns.Add("Latest_LMP_Date")
            dt.Columns.Add("LIS_Blood_Report")
            dt.Columns.Add("LIS_Blood_Report_Time")
            dt.Columns.Add("LIS_BMT_Mark")
            dt.Columns.Add("Student_Id")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Is_IPD")
            dt.Columns.Add("Is_EMG")
            dt.Columns.Add("Patient_Short_Name")
            dt.Columns.Add("Reg_Notify_Id")
            dt.Columns.Add("Register_Dist_Code")
            dt.Columns.Add("Register_Vil_Code")
            dt.Columns.Add("Dist_Code")
            dt.Columns.Add("Vil_Code")
            dt.Columns.Add("Dist_Code2")
            dt.Columns.Add("Vil_Code2")
            dt.Columns.Add("Not_Scrap")
            dt.Columns.Add("Chart_No_Int")
            dt.Columns.Add("Info_Confirm")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
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
            dt.Columns.Add("Chart_No")
            dt.Columns("Chart_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Patient_Name")
            dt.Columns("Patient_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Patient_En_Name")
            dt.Columns("Patient_En_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Idno_Type_Id")
            dt.Columns("Idno_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Idno")
            dt.Columns("Idno").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Birth_Date")
            dt.Columns("Birth_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Sex_Id")
            dt.Columns("Sex_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Blood_Type_Id")
            dt.Columns("Blood_Type_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Education_Id")
            dt.Columns("Education_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Marriage_Id")
            dt.Columns("Marriage_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Job_Id")
            dt.Columns("Job_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Nationality_Id")
            dt.Columns("Nationality_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Race_Id")
            dt.Columns("Race_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Area_Code")
            dt.Columns("Area_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Register_Postal_Code")
            dt.Columns("Register_Postal_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Register_Address")
            dt.Columns("Register_Address").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Postal_Code")
            dt.Columns("Postal_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Address")
            dt.Columns("Address").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Tel_Home")
            dt.Columns("Tel_Home").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Tel_Office")
            dt.Columns("Tel_Office").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Tel_Mobile")
            dt.Columns("Tel_Mobile").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Fax")
            dt.Columns("Fax").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Email")
            dt.Columns("Email").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Postal_Code2")
            dt.Columns("Postal_Code2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Address2")
            dt.Columns("Address2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Tel2")
            dt.Columns("Tel2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Tel2_Mobile")
            dt.Columns("Tel2_Mobile").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Email2")
            dt.Columns("Email2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("First_Visit_Date")
            dt.Columns("First_Visit_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Latest_Visit_Date")
            dt.Columns("Latest_Visit_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Latest_Admission_Date")
            dt.Columns("Latest_Admission_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Latest_Discharge_Date")
            dt.Columns("Latest_Discharge_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Ipd_Times")
            dt.Columns("Ipd_Times").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Latest_Xray_Date")
            dt.Columns("Latest_Xray_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Latest_CT_Date")
            dt.Columns("Latest_CT_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Arrears_Times")
            dt.Columns("Arrears_Times").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Opd_Arrears_Amt")
            dt.Columns("Opd_Arrears_Amt").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Emg_Arrears_Amt")
            dt.Columns("Emg_Arrears_Amt").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Ipd_Arrears_Amt")
            dt.Columns("Ipd_Arrears_Amt").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Measure_Time")
            dt.Columns("Measure_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Latest_Height")
            dt.Columns("Latest_Height").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Latest_Weight")
            dt.Columns("Latest_Weight").DataType = System.Type.GetType("System.Decimal")
            dt.Columns.Add("Mis_Register_Date1")
            dt.Columns("Mis_Register_Date1").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Mis_Register_Date2")
            dt.Columns("Mis_Register_Date2").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Mis_Register_Date3")
            dt.Columns("Mis_Register_Date3").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Mis_Register_Times")
            dt.Columns("Mis_Register_Times").DataType = System.Type.GetType("System.Int32")
            dt.Columns.Add("Mis_Register_End_Date")
            dt.Columns("Mis_Register_End_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Is_Death")
            dt.Columns("Is_Death").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Death_Time")
            dt.Columns("Death_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Is_Chart_Divide")
            dt.Columns("Is_Chart_Divide").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Chart_Image")
            dt.Columns("Is_Chart_Image").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Patient_Memo")
            dt.Columns("Patient_Memo").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_Employee")
            dt.Columns("Is_Employee").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Reserve_Chart_No")
            dt.Columns("Reserve_Chart_No").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Latest_LMP_Date")
            dt.Columns("Latest_LMP_Date").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("LIS_Blood_Report")
            dt.Columns("LIS_Blood_Report").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("LIS_Blood_Report_Time")
            dt.Columns("LIS_Blood_Report_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("LIS_BMT_Mark")
            dt.Columns("LIS_BMT_Mark").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Student_Id")
            dt.Columns("Student_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_User")
            dt.Columns("Create_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Create_Time")
            dt.Columns("Create_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Modified_User")
            dt.Columns("Modified_User").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Modified_Time")
            dt.Columns("Modified_Time").DataType = System.Type.GetType("System.DateTime")
            dt.Columns.Add("Is_IPD")
            dt.Columns("Is_IPD").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Is_EMG")
            dt.Columns("Is_EMG").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Patient_Short_Name")
            dt.Columns("Patient_Short_Name").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Reg_Notify_Id")
            dt.Columns("Reg_Notify_Id").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Register_Dist_Code")
            dt.Columns("Register_Dist_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Register_Vil_Code")
            dt.Columns("Register_Vil_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dist_Code")
            dt.Columns("Dist_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Vil_Code")
            dt.Columns("Vil_Code").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Dist_Code2")
            dt.Columns("Dist_Code2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Vil_Code2")
            dt.Columns("Vil_Code2").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Not_Scrap")
            dt.Columns("Not_Scrap").DataType = System.Type.GetType("System.String")
            dt.Columns.Add("Chart_No_Int")
            dt.Columns("Chart_No_Int").DataType = System.Type.GetType("System.Int64")
            dt.Columns.Add("Info_Confirm")
            dt.Columns("Info_Confirm").DataType = System.Type.GetType("System.String")
            Dim pkColArray(0) As DataColumn 
            pkColArray(0) = dt.Columns("Chart_No")
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
            dt.Columns.Add("Chart_No")
            dt.Columns.Add("Patient_Name")
            dt.Columns.Add("Patient_En_Name")
            dt.Columns.Add("Idno_Type_Id")
            dt.Columns.Add("Idno")
            dt.Columns.Add("Birth_Date")
            dt.Columns.Add("Sex_Id")
            dt.Columns.Add("Blood_Type_Id")
            dt.Columns.Add("Education_Id")
            dt.Columns.Add("Marriage_Id")
            dt.Columns.Add("Job_Id")
            dt.Columns.Add("Nationality_Id")
            dt.Columns.Add("Race_Id")
            dt.Columns.Add("Area_Code")
            dt.Columns.Add("Register_Postal_Code")
            dt.Columns.Add("Register_Address")
            dt.Columns.Add("Postal_Code")
            dt.Columns.Add("Address")
            dt.Columns.Add("Tel_Home")
            dt.Columns.Add("Tel_Office")
            dt.Columns.Add("Tel_Mobile")
            dt.Columns.Add("Fax")
            dt.Columns.Add("Email")
            dt.Columns.Add("Postal_Code2")
            dt.Columns.Add("Address2")
            dt.Columns.Add("Tel2")
            dt.Columns.Add("Tel2_Mobile")
            dt.Columns.Add("Email2")
            dt.Columns.Add("First_Visit_Date")
            dt.Columns.Add("Latest_Visit_Date")
            dt.Columns.Add("Latest_Admission_Date")
            dt.Columns.Add("Latest_Discharge_Date")
            dt.Columns.Add("Ipd_Times")
            dt.Columns.Add("Latest_Xray_Date")
            dt.Columns.Add("Latest_CT_Date")
            dt.Columns.Add("Arrears_Times")
            dt.Columns.Add("Opd_Arrears_Amt")
            dt.Columns.Add("Emg_Arrears_Amt")
            dt.Columns.Add("Ipd_Arrears_Amt")
            dt.Columns.Add("Measure_Time")
            dt.Columns.Add("Latest_Height")
            dt.Columns.Add("Latest_Weight")
            dt.Columns.Add("Mis_Register_Date1")
            dt.Columns.Add("Mis_Register_Date2")
            dt.Columns.Add("Mis_Register_Date3")
            dt.Columns.Add("Mis_Register_Times")
            dt.Columns.Add("Mis_Register_End_Date")
            dt.Columns.Add("Is_Death")
            dt.Columns.Add("Death_Time")
            dt.Columns.Add("Is_Chart_Divide")
            dt.Columns.Add("Is_Chart_Image")
            dt.Columns.Add("Patient_Memo")
            dt.Columns.Add("Is_Employee")
            dt.Columns.Add("Reserve_Chart_No")
            dt.Columns.Add("Latest_LMP_Date")
            dt.Columns.Add("LIS_Blood_Report")
            dt.Columns.Add("LIS_Blood_Report_Time")
            dt.Columns.Add("LIS_BMT_Mark")
            dt.Columns.Add("Student_Id")
            dt.Columns.Add("Create_User")
            dt.Columns.Add("Create_Time")
            dt.Columns.Add("Modified_User")
            dt.Columns.Add("Modified_Time")
            dt.Columns.Add("Is_IPD")
            dt.Columns.Add("Is_EMG")
            dt.Columns.Add("Patient_Short_Name")
            dt.Columns.Add("Reg_Notify_Id")
            dt.Columns.Add("Register_Dist_Code")
            dt.Columns.Add("Register_Vil_Code")
            dt.Columns.Add("Dist_Code")
            dt.Columns.Add("Vil_Code")
            dt.Columns.Add("Dist_Code2")
            dt.Columns.Add("Vil_Code2")
            dt.Columns.Add("Not_Scrap")
            dt.Columns.Add("Chart_No_Int")
            dt.Columns.Add("Info_Confirm")
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

  Class PUBPatientPt
    Private m_Chart_No As String = "Chart_No"
    Public ReadOnly Property Chart_No() As System.String 
    Get
        Return m_Chart_No
    End Get
    End Property

    Private m_Patient_Name As String = "Patient_Name"
    Public ReadOnly Property Patient_Name() As System.String 
    Get
        Return m_Patient_Name
    End Get
    End Property

    Private m_Patient_En_Name As String = "Patient_En_Name"
    Public ReadOnly Property Patient_En_Name() As System.String 
    Get
        Return m_Patient_En_Name
    End Get
    End Property

    Private m_Idno_Type_Id As String = "Idno_Type_Id"
    Public ReadOnly Property Idno_Type_Id() As System.String 
    Get
        Return m_Idno_Type_Id
    End Get
    End Property

    Private m_Idno As String = "Idno"
    Public ReadOnly Property Idno() As System.String 
    Get
        Return m_Idno
    End Get
    End Property

    Private m_Birth_Date As String = "Birth_Date"
    Public ReadOnly Property Birth_Date() As System.String 
    Get
        Return m_Birth_Date
    End Get
    End Property

    Private m_Sex_Id As String = "Sex_Id"
    Public ReadOnly Property Sex_Id() As System.String 
    Get
        Return m_Sex_Id
    End Get
    End Property

    Private m_Blood_Type_Id As String = "Blood_Type_Id"
    Public ReadOnly Property Blood_Type_Id() As System.String 
    Get
        Return m_Blood_Type_Id
    End Get
    End Property

    Private m_Education_Id As String = "Education_Id"
    Public ReadOnly Property Education_Id() As System.String 
    Get
        Return m_Education_Id
    End Get
    End Property

    Private m_Marriage_Id As String = "Marriage_Id"
    Public ReadOnly Property Marriage_Id() As System.String 
    Get
        Return m_Marriage_Id
    End Get
    End Property

    Private m_Job_Id As String = "Job_Id"
    Public ReadOnly Property Job_Id() As System.String 
    Get
        Return m_Job_Id
    End Get
    End Property

    Private m_Nationality_Id As String = "Nationality_Id"
    Public ReadOnly Property Nationality_Id() As System.String 
    Get
        Return m_Nationality_Id
    End Get
    End Property

    Private m_Race_Id As String = "Race_Id"
    Public ReadOnly Property Race_Id() As System.String 
    Get
        Return m_Race_Id
    End Get
    End Property

    Private m_Area_Code As String = "Area_Code"
    Public ReadOnly Property Area_Code() As System.String 
    Get
        Return m_Area_Code
    End Get
    End Property

    Private m_Register_Postal_Code As String = "Register_Postal_Code"
    Public ReadOnly Property Register_Postal_Code() As System.String 
    Get
        Return m_Register_Postal_Code
    End Get
    End Property

    Private m_Register_Address As String = "Register_Address"
    Public ReadOnly Property Register_Address() As System.String 
    Get
        Return m_Register_Address
    End Get
    End Property

    Private m_Postal_Code As String = "Postal_Code"
    Public ReadOnly Property Postal_Code() As System.String 
    Get
        Return m_Postal_Code
    End Get
    End Property

    Private m_Address As String = "Address"
    Public ReadOnly Property Address() As System.String 
    Get
        Return m_Address
    End Get
    End Property

    Private m_Tel_Home As String = "Tel_Home"
    Public ReadOnly Property Tel_Home() As System.String 
    Get
        Return m_Tel_Home
    End Get
    End Property

    Private m_Tel_Office As String = "Tel_Office"
    Public ReadOnly Property Tel_Office() As System.String 
    Get
        Return m_Tel_Office
    End Get
    End Property

    Private m_Tel_Mobile As String = "Tel_Mobile"
    Public ReadOnly Property Tel_Mobile() As System.String 
    Get
        Return m_Tel_Mobile
    End Get
    End Property

    Private m_Fax As String = "Fax"
    Public ReadOnly Property Fax() As System.String 
    Get
        Return m_Fax
    End Get
    End Property

    Private m_Email As String = "Email"
    Public ReadOnly Property Email() As System.String 
    Get
        Return m_Email
    End Get
    End Property

    Private m_Postal_Code2 As String = "Postal_Code2"
    Public ReadOnly Property Postal_Code2() As System.String 
    Get
        Return m_Postal_Code2
    End Get
    End Property

    Private m_Address2 As String = "Address2"
    Public ReadOnly Property Address2() As System.String 
    Get
        Return m_Address2
    End Get
    End Property

    Private m_Tel2 As String = "Tel2"
    Public ReadOnly Property Tel2() As System.String 
    Get
        Return m_Tel2
    End Get
    End Property

    Private m_Tel2_Mobile As String = "Tel2_Mobile"
    Public ReadOnly Property Tel2_Mobile() As System.String 
    Get
        Return m_Tel2_Mobile
    End Get
    End Property

    Private m_Email2 As String = "Email2"
    Public ReadOnly Property Email2() As System.String 
    Get
        Return m_Email2
    End Get
    End Property

    Private m_First_Visit_Date As String = "First_Visit_Date"
    Public ReadOnly Property First_Visit_Date() As System.String 
    Get
        Return m_First_Visit_Date
    End Get
    End Property

    Private m_Latest_Visit_Date As String = "Latest_Visit_Date"
    Public ReadOnly Property Latest_Visit_Date() As System.String 
    Get
        Return m_Latest_Visit_Date
    End Get
    End Property

    Private m_Latest_Admission_Date As String = "Latest_Admission_Date"
    Public ReadOnly Property Latest_Admission_Date() As System.String 
    Get
        Return m_Latest_Admission_Date
    End Get
    End Property

    Private m_Latest_Discharge_Date As String = "Latest_Discharge_Date"
    Public ReadOnly Property Latest_Discharge_Date() As System.String 
    Get
        Return m_Latest_Discharge_Date
    End Get
    End Property

    Private m_Ipd_Times As String = "Ipd_Times"
    Public ReadOnly Property Ipd_Times() As System.String 
    Get
        Return m_Ipd_Times
    End Get
    End Property

    Private m_Latest_Xray_Date As String = "Latest_Xray_Date"
    Public ReadOnly Property Latest_Xray_Date() As System.String 
    Get
        Return m_Latest_Xray_Date
    End Get
    End Property

    Private m_Latest_CT_Date As String = "Latest_CT_Date"
    Public ReadOnly Property Latest_CT_Date() As System.String 
    Get
        Return m_Latest_CT_Date
    End Get
    End Property

    Private m_Arrears_Times As String = "Arrears_Times"
    Public ReadOnly Property Arrears_Times() As System.String 
    Get
        Return m_Arrears_Times
    End Get
    End Property

    Private m_Opd_Arrears_Amt As String = "Opd_Arrears_Amt"
    Public ReadOnly Property Opd_Arrears_Amt() As System.String 
    Get
        Return m_Opd_Arrears_Amt
    End Get
    End Property

    Private m_Emg_Arrears_Amt As String = "Emg_Arrears_Amt"
    Public ReadOnly Property Emg_Arrears_Amt() As System.String 
    Get
        Return m_Emg_Arrears_Amt
    End Get
    End Property

    Private m_Ipd_Arrears_Amt As String = "Ipd_Arrears_Amt"
    Public ReadOnly Property Ipd_Arrears_Amt() As System.String 
    Get
        Return m_Ipd_Arrears_Amt
    End Get
    End Property

    Private m_Measure_Time As String = "Measure_Time"
    Public ReadOnly Property Measure_Time() As System.String 
    Get
        Return m_Measure_Time
    End Get
    End Property

    Private m_Latest_Height As String = "Latest_Height"
    Public ReadOnly Property Latest_Height() As System.String 
    Get
        Return m_Latest_Height
    End Get
    End Property

    Private m_Latest_Weight As String = "Latest_Weight"
    Public ReadOnly Property Latest_Weight() As System.String 
    Get
        Return m_Latest_Weight
    End Get
    End Property

    Private m_Mis_Register_Date1 As String = "Mis_Register_Date1"
    Public ReadOnly Property Mis_Register_Date1() As System.String 
    Get
        Return m_Mis_Register_Date1
    End Get
    End Property

    Private m_Mis_Register_Date2 As String = "Mis_Register_Date2"
    Public ReadOnly Property Mis_Register_Date2() As System.String 
    Get
        Return m_Mis_Register_Date2
    End Get
    End Property

    Private m_Mis_Register_Date3 As String = "Mis_Register_Date3"
    Public ReadOnly Property Mis_Register_Date3() As System.String 
    Get
        Return m_Mis_Register_Date3
    End Get
    End Property

    Private m_Mis_Register_Times As String = "Mis_Register_Times"
    Public ReadOnly Property Mis_Register_Times() As System.String 
    Get
        Return m_Mis_Register_Times
    End Get
    End Property

    Private m_Mis_Register_End_Date As String = "Mis_Register_End_Date"
    Public ReadOnly Property Mis_Register_End_Date() As System.String 
    Get
        Return m_Mis_Register_End_Date
    End Get
    End Property

    Private m_Is_Death As String = "Is_Death"
    Public ReadOnly Property Is_Death() As System.String 
    Get
        Return m_Is_Death
    End Get
    End Property

    Private m_Death_Time As String = "Death_Time"
    Public ReadOnly Property Death_Time() As System.String 
    Get
        Return m_Death_Time
    End Get
    End Property

    Private m_Is_Chart_Divide As String = "Is_Chart_Divide"
    Public ReadOnly Property Is_Chart_Divide() As System.String 
    Get
        Return m_Is_Chart_Divide
    End Get
    End Property

    Private m_Is_Chart_Image As String = "Is_Chart_Image"
    Public ReadOnly Property Is_Chart_Image() As System.String 
    Get
        Return m_Is_Chart_Image
    End Get
    End Property

    Private m_Patient_Memo As String = "Patient_Memo"
    Public ReadOnly Property Patient_Memo() As System.String 
    Get
        Return m_Patient_Memo
    End Get
    End Property

    Private m_Is_Employee As String = "Is_Employee"
    Public ReadOnly Property Is_Employee() As System.String 
    Get
        Return m_Is_Employee
    End Get
    End Property

    Private m_Reserve_Chart_No As String = "Reserve_Chart_No"
    Public ReadOnly Property Reserve_Chart_No() As System.String 
    Get
        Return m_Reserve_Chart_No
    End Get
    End Property

    Private m_Latest_LMP_Date As String = "Latest_LMP_Date"
    Public ReadOnly Property Latest_LMP_Date() As System.String 
    Get
        Return m_Latest_LMP_Date
    End Get
    End Property

    Private m_LIS_Blood_Report As String = "LIS_Blood_Report"
    Public ReadOnly Property LIS_Blood_Report() As System.String 
    Get
        Return m_LIS_Blood_Report
    End Get
    End Property

    Private m_LIS_Blood_Report_Time As String = "LIS_Blood_Report_Time"
    Public ReadOnly Property LIS_Blood_Report_Time() As System.String 
    Get
        Return m_LIS_Blood_Report_Time
    End Get
    End Property

    Private m_LIS_BMT_Mark As String = "LIS_BMT_Mark"
    Public ReadOnly Property LIS_BMT_Mark() As System.String 
    Get
        Return m_LIS_BMT_Mark
    End Get
    End Property

    Private m_Student_Id As String = "Student_Id"
    Public ReadOnly Property Student_Id() As System.String 
    Get
        Return m_Student_Id
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

    Private m_Is_IPD As String = "Is_IPD"
    Public ReadOnly Property Is_IPD() As System.String 
    Get
        Return m_Is_IPD
    End Get
    End Property

    Private m_Is_EMG As String = "Is_EMG"
    Public ReadOnly Property Is_EMG() As System.String 
    Get
        Return m_Is_EMG
    End Get
    End Property

    Private m_Patient_Short_Name As String = "Patient_Short_Name"
    Public ReadOnly Property Patient_Short_Name() As System.String 
    Get
        Return m_Patient_Short_Name
    End Get
    End Property

    Private m_Reg_Notify_Id As String = "Reg_Notify_Id"
    Public ReadOnly Property Reg_Notify_Id() As System.String 
    Get
        Return m_Reg_Notify_Id
    End Get
    End Property

    Private m_Register_Dist_Code As String = "Register_Dist_Code"
    Public ReadOnly Property Register_Dist_Code() As System.String 
    Get
        Return m_Register_Dist_Code
    End Get
    End Property

    Private m_Register_Vil_Code As String = "Register_Vil_Code"
    Public ReadOnly Property Register_Vil_Code() As System.String 
    Get
        Return m_Register_Vil_Code
    End Get
    End Property

    Private m_Dist_Code As String = "Dist_Code"
    Public ReadOnly Property Dist_Code() As System.String 
    Get
        Return m_Dist_Code
    End Get
    End Property

    Private m_Vil_Code As String = "Vil_Code"
    Public ReadOnly Property Vil_Code() As System.String 
    Get
        Return m_Vil_Code
    End Get
    End Property

    Private m_Dist_Code2 As String = "Dist_Code2"
    Public ReadOnly Property Dist_Code2() As System.String 
    Get
        Return m_Dist_Code2
    End Get
    End Property

    Private m_Vil_Code2 As String = "Vil_Code2"
    Public ReadOnly Property Vil_Code2() As System.String 
    Get
        Return m_Vil_Code2
    End Get
    End Property

    Private m_Not_Scrap As String = "Not_Scrap"
    Public ReadOnly Property Not_Scrap() As System.String 
    Get
        Return m_Not_Scrap
    End Get
    End Property

    Private m_Chart_No_Int As String = "Chart_No_Int"
    Public ReadOnly Property Chart_No_Int() As System.String 
    Get
        Return m_Chart_No_Int
    End Get
    End Property

    Private m_Info_Confirm As String = "Info_Confirm"
    Public ReadOnly Property Info_Confirm() As System.String 
    Get
        Return m_Info_Confirm
    End Get
    End Property

  End Class

End Class
